using Stripe;
using Diaspora.Application.Exceptions;
using Diaspora.Domain.Abstractions;
using Diaspora.Domain.Entities.Service;
using Diaspora.Domain.Entities.User;
using Diaspora.Infrastructure.Abstractions;
using MediatR;
using System;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using AddressEntity = Diaspora.Domain.Entities.Address.Address;
using PersonEntity = Diaspora.Domain.Entities.Person.Person;
using Diaspora.Application.Address.DTOs;
using Diaspora.Application.Person.DTOs;
using Diaspora.Domain.Events;


namespace Diaspora.Application.Services.Commands.CreateService
{
    public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHashingService _hashingService;
        private readonly IPaymentService _paymentService;
        private readonly IMediator _mediator;

        public CreateServiceCommandHandler(IUnitOfWork unitOfWork, IHashingService hashingService, IPaymentService paymentService, IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _hashingService = hashingService;
            _paymentService = paymentService;
            _mediator = mediator;
        }

        public async Task<int> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Procesar el pago
                var paymentResult = await ProcessPaymentAsync(request);

                // Crear entidades del sender y receiver
                var senderEntities = await CreateSenderEntitiesAsync(request);
                var receiverEntities = await CreateReceiverEntitiesAsync(request);

                // Confirmar los cambios en la base de datos
                await _unitOfWork.CompleteAsync();

                // Sincronizar entidades de dominio con la base de datos
                SyncDomainEntitiesWithDatabase(senderEntities, receiverEntities);

                // Actualizar IDs de las entidades
                await UpdateEntityIdsAsync(senderEntities, receiverEntities);

                // Crear el servicio con los IDs actualizados
                var serviceEntity = await CreateServiceAsync(request, paymentResult, senderEntities.SenderPersonEntity.Id.Value, receiverEntities.ReceiverPersonEntity.Id.Value);

                // Confirmar nuevamente para guardar el servicio creado
                await _unitOfWork.CompleteAsync();

                // Sincronizar entidad de servicio para obtener el ID
                _unitOfWork.Services.SyncDomainEntityWithDatabase(serviceEntity);

                await _mediator.Publish(new ServiceCreatedEvent(serviceEntity.Id.Value, paymentResult, senderEntities.SenderPersonEntity.Email.Value), cancellationToken);

                return serviceEntity.Id.Value;
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error creating the service", ex);
            }
        }

        private async Task<string> ProcessPaymentAsync(CreateServiceCommand request)
        {
            try
            {
                var paymentResult = await _paymentService.ProcessPaymentAsync(
                    request.Payment.Amount,
                    request.Payment.Currency,
                    request.Payment.Source,
                    request.Payment.Description
                );

                if (string.IsNullOrEmpty(paymentResult))
                {
                    throw new PaymentProcessingException("The payment could not be processed.", null);
                }

                return paymentResult;
            }
            catch (Exception ex)
            {
                throw new PaymentProcessingException("There was an error processing the payment.", ex);
            }
        }

        private async Task<(PersonEntity SenderPersonEntity, AddressEntity SenderAddressEntity, User UserEntity)> CreateSenderEntitiesAsync(CreateServiceCommand request)
        {
            try
            {
                var senderAddressEntity = CreateAddressEntity(request.Sender.Address, request.CreatedBy);
                await _unitOfWork.Addresses.AddAsync(senderAddressEntity);

                await CheckIfUserExistsAsync(request.Sender.Email);

                var userEntity = CreateUserEntity(request.Sender.Email, request.Sender.DocumentIdentifier, request.CreatedBy);
                await _unitOfWork.Users.AddAsync(userEntity);

                var senderPersonEntity = CreatePersonEntity(request.Sender, null, null, request.CreatedBy);
                await _unitOfWork.Persons.AddAsync(senderPersonEntity);

                return (senderPersonEntity, senderAddressEntity, userEntity);
            }
            catch (Exception ex)
            {
                throw new EntityCreationException("sender", ex);
            }
        }

        private async Task<(PersonEntity ReceiverPersonEntity, AddressEntity ReceiverAddressEntity)> CreateReceiverEntitiesAsync(CreateServiceCommand request)
        {
            try
            {
                var receiverAddressEntity = CreateAddressEntity(request.Receiver.Address, request.CreatedBy);
                await _unitOfWork.Addresses.AddAsync(receiverAddressEntity);

                var receiverPersonEntity = CreatePersonEntity(request.Receiver, null, null, request.CreatedBy);
                await _unitOfWork.Persons.AddAsync(receiverPersonEntity);

                return (receiverPersonEntity, receiverAddressEntity);
            }
            catch (Exception ex)
            {
                throw new EntityCreationException("receiver", ex);
            }
        }

        private void SyncDomainEntitiesWithDatabase(
            (PersonEntity SenderPersonEntity, AddressEntity SenderAddressEntity, User UserEntity) senderEntities,
            (PersonEntity ReceiverPersonEntity, AddressEntity ReceiverAddressEntity) receiverEntities)
        {
            try
            {
                _unitOfWork.Persons.SyncDomainEntityWithDatabase(senderEntities.SenderPersonEntity);
                _unitOfWork.Addresses.SyncDomainEntityWithDatabase(senderEntities.SenderAddressEntity);
                _unitOfWork.Users.SyncDomainEntityWithDatabase(senderEntities.UserEntity);
                _unitOfWork.Persons.SyncDomainEntityWithDatabase(receiverEntities.ReceiverPersonEntity);
                _unitOfWork.Addresses.SyncDomainEntityWithDatabase(receiverEntities.ReceiverAddressEntity);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error synchronizing entities with the database", ex);
            }
        }

        private async Task UpdateEntityIdsAsync(
            (PersonEntity SenderPersonEntity, AddressEntity SenderAddressEntity, User UserEntity) senderEntities,
            (PersonEntity ReceiverPersonEntity, AddressEntity ReceiverAddressEntity) receiverEntities)
        {
            try
            {
                // Obtener los IDs generados
                int senderAddressId = senderEntities.SenderAddressEntity.Id.Value;
                int userId = senderEntities.UserEntity.Id.Value;
                int senderPersonId = senderEntities.SenderPersonEntity.Id.Value;
                int receiverAddressId = receiverEntities.ReceiverAddressEntity.Id.Value;
                int receiverPersonId = receiverEntities.ReceiverPersonEntity.Id.Value;

                senderEntities.SenderPersonEntity.UpdateAddressAndUserId(senderAddressId, userId);
                receiverEntities.ReceiverPersonEntity.UpdateAddressId(receiverAddressId);

                await _unitOfWork.Persons.UpdateAsync(senderEntities.SenderPersonEntity);
                await _unitOfWork.Persons.UpdateAsync(receiverEntities.ReceiverPersonEntity);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error updating entity IDs", ex);
            }
        }

        private async Task<Service> CreateServiceAsync(CreateServiceCommand request, string paymentResult, int senderPersonId, int receiverPersonId)
        {
            try
            {
                var serviceEntity = Service.Create(
                    request.OriginCity,
                    request.DestinationCity,
                    request.CourierId,
                    senderPersonId,
                    receiverPersonId,
                    request.PickupDate,
                    true,
                    DateTime.UtcNow,
                    request.CreatedBy,
                    paymentResult,
                    request.ServiceTypeId
                );

                await _unitOfWork.Services.AddService(serviceEntity);
                return serviceEntity;
            }
            catch (Exception ex)
            {
                throw new EntityCreationException("service", ex);
            }
        }

        private AddressEntity CreateAddressEntity(AddressDto addressDto, int createdBy)
        {
            return AddressEntity.Create(
                addressDto.Address1,
                addressDto.Address2,
                addressDto.Address3,
                addressDto.PostalCode,
                addressDto.CityId,
                Guid.NewGuid(),
                true,
                DateTime.UtcNow,
                createdBy
            );
        }

        private PersonEntity CreatePersonEntity(PersonDto personDto, int? addressId, int? userId, int createdBy)
        {
            return PersonEntity.Create(
                personDto.DocumentIdentifier,
                personDto.FirstName,
                personDto.LastName,
                personDto.Email,
                personDto.BirthDate,
                personDto.DocumentTypeId,
                personDto.PersonTypeId,
                addressId,
                userId,
                true,
                DateTime.UtcNow,
                createdBy
            );
        }

        private User CreateUserEntity(string email, string documentIdentifier, int createdBy)
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            string hashedPassword = _hashingService.HashPassword(documentIdentifier, salt);
            return User.Create(email, hashedPassword, createdBy, DateTime.UtcNow, salt);
        }

        private async Task CheckIfUserExistsAsync(string email)
        {
            var userExists = await _unitOfWork.Users.GetByUserNameAsync(email);
            if (userExists != null)
            {
                throw new UserNameAlreadyExistsException(email);
            }
        }
    }
}
