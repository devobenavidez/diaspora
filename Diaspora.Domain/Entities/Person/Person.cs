using Diaspora.Domain.Shared.ValueObjects;
using AddressEntity = Diaspora.Domain.Entities.Address.Address;
using UserEntity = Diaspora.Domain.Entities.User.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Entities.Person
{
    public class Person
    {
        public PersonId Id { get; set; }

        public DocumentIdentifier DocumentIdentifier { get; set; } = null!;

        public Name FirstName { get; set; } = null!;

        public Name? LastName { get; set; }

        public Email Email { get; set; } = null!;

        public GenericDate? BirthDate { get; set; }

        public DocumentTypeId DocumentTypeId { get; set; }

        public PersonTypeId PersonTypeId { get; set; }

        public AddressId? AddressId { get; set; }

        public UserId? UserId { get; set; }

        public bool IsActive { get; set; }

        public AuditInfo AuditInfo { get; set; }

        public AddressEntity Address { get; set; }
        public UserEntity User { get; set; }

        private Person(PersonId id, DocumentIdentifier documentIdentifier, Name firstName, Name? lastName, Email email, GenericDate? birthDate, DocumentTypeId documentTypeId, PersonTypeId personTypeId, AddressId? addressId, UserId? userId, bool isActive, AuditInfo auditInfo)
        {
            Id = id;
            DocumentIdentifier = documentIdentifier;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            BirthDate = birthDate;
            DocumentTypeId = documentTypeId;
            PersonTypeId = personTypeId;
            AddressId = addressId;
            UserId = userId;
            IsActive = isActive;
            AuditInfo = auditInfo;
        }

        private Person(DocumentIdentifier documentIdentifier, Name firstName, Name? lastName, Email email, GenericDate? birthDate, DocumentTypeId documentTypeId, PersonTypeId personTypeId, AddressId? addressId, UserId? userId, bool isActive, AuditInfo auditInfo)
        {
            DocumentIdentifier = documentIdentifier;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            BirthDate = birthDate;
            DocumentTypeId = documentTypeId;
            PersonTypeId = personTypeId;
            AddressId = addressId;
            UserId = userId;
            IsActive = isActive;
            AuditInfo = auditInfo;
        }

        public static Person Create(string documentIdentifier, string firstName, string? lastName, string email, DateTime? birthDate, int documentTypeId, int personTypeId, int? addressId, int? userId, bool isActive, DateTime createdAt, int createdBy)
        {
            var document = DocumentIdentifier.Create(documentIdentifier);
            var firstNameObject = Name.CreateRequired(firstName);
            var lastNameObject = Name.CreateNotRequired(lastName);
            var emailObj = Email.Create(email);
            var fechaNacimientoObj = birthDate.HasValue ? GenericDate.Create(birthDate.Value) : null;
            var documentType = DocumentTypeId.Create(documentTypeId);
            var personType = PersonTypeId.Create(personTypeId);
            var address = addressId.HasValue ? AddressId.CreateRequired(addressId.Value) : null;
            var user = userId.HasValue ? UserId.CreateRequired(userId.Value) : null;
            var auditInfo = AuditInfo.Create(createdAt, createdBy, createdAt, createdBy);
            return new Person(document, firstNameObject, lastNameObject, emailObj, fechaNacimientoObj, documentType, personType, address, user, isActive, auditInfo);
        }

        public static Person FromPrimitives(int id, string documentIdentifier, string firstName, string? lastName, string email, DateTime? birthDate, int documentTypeId, int personTypeId, int? addressId, int? userId, bool isActive, DateTime createdAt, int createdBy, DateTime updatedAt, int updatedBy)
        {
            var personId = new PersonId(id);
            var document = DocumentIdentifier.Create(documentIdentifier);
            var firstNameObject = Name.CreateRequired(firstName);
            var lastNameObject = Name.CreateNotRequired(lastName);
            var emailObj = Email.Create(email);
            var fechaNacimientoObj = birthDate.HasValue ? GenericDate.Create(birthDate.Value) : null;
            var documentType = DocumentTypeId.Create(documentTypeId);
            var personType = PersonTypeId.Create(personTypeId);
            var address = addressId.HasValue ? AddressId.CreateRequired(addressId.Value) : null;
            var user = userId.HasValue ? UserId.CreateRequired(userId.Value) : null;
            var auditInfo = AuditInfo.Create(createdAt, createdBy, updatedAt, updatedBy);
            return new Person(personId, document, firstNameObject, lastNameObject, emailObj, fechaNacimientoObj, documentType, personType, address, user, isActive, auditInfo);
        }

        public void UpdateAddressAndUserId(int? addressId, int? userId)
        {
            if (addressId.HasValue)
            {
                AddressId = AddressId.CreateOptional(addressId.Value);
            }

            if (userId.HasValue)
            {
                UserId = UserId.CreateRequired(userId.Value);
            }
        }

        public void UpdateAddressId(int? addressId)
        {
            if (addressId.HasValue)
            {
                AddressId = AddressId.CreateOptional(addressId.Value);
            }
        }

        public static PersonId SetPersonId(int id)
        {
            return new PersonId(id);
        }
    }
}
