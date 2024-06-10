using Diaspora.Application.Exceptions;
using Diaspora.Domain.Abstractions;
using Diaspora.Domain.Entities.User;
using Diaspora.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly IUser _userRepository;
        private readonly IHashingService _hashingService;

        public CreateUserCommandHandler(IUser userRepository, IHashingService hashingService)
        {
            _userRepository = userRepository;
            _hashingService = hashingService;
        }

        public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {

            User userExists = await _userRepository.GetByUserNameAsync(request.UserName);
            if (userExists != null)
            {
                throw new UserNameAlreadyExistsException(request.UserName);
            }

            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            string hashedPassword = _hashingService.HashPassword(request.Password, salt);


            var user = User.Create(request.UserName, hashedPassword, request.CreatedById, DateTime.UtcNow, salt);


            await _userRepository.CreateUser(user);
        }
    }
}
