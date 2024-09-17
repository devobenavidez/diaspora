using Diaspora.Domain.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Entities.Address
{
    public class Address
    {
        public AddressId Id { get; set; }

        public AddressDescription Address1 { get; set; } = null!;

        public AddressDescription? Address2 { get; set; }

        public AddressDescription? Address3 { get; set; }

        public PostalCode PostalCode { get; set; }

        public CityId CityId { get; set; }

        public Guid AddressIdentifier { get; set; }

        public bool IsActive { get; set; }

        public AuditInfo AuditInfo { get; set; } = null!;

        private Address(AddressId id, AddressDescription address1, AddressDescription address2, AddressDescription address3, PostalCode postalCode, CityId cityId, Guid addressIdentifier, bool isActive, AuditInfo auditInfo)
        {
            Id = id;
            Address1 = address1;
            Address2 = address2;
            Address3 = address3;
            PostalCode = postalCode;
            CityId = cityId;
            AddressIdentifier = addressIdentifier;
            IsActive = isActive;
            AuditInfo = auditInfo;
        }

        private Address(AddressDescription address1, AddressDescription address2, AddressDescription address3, PostalCode postalCode, CityId cityId, Guid addressIdentifier, bool isActive, AuditInfo auditInfo)
        {
            Address1 = address1;
            Address2 = address2;
            Address3 = address3;
            PostalCode = postalCode;
            CityId = cityId;
            AddressIdentifier = addressIdentifier;
            IsActive = isActive;
            AuditInfo = auditInfo;
        }

        public static Address Create(string address1, string? address2, string? address3, string postalCode, int cityId, Guid addressIdentifier, bool isActive, DateTime createdAt, int createdBy)
        {
            var addressDescription1 = AddressDescription.CreateRequired(address1);
            var addressDescription2 = AddressDescription.CreateOptional(address2);
            var addressDescription3 = AddressDescription.CreateOptional(address3);
            var postalCodeValue = PostalCode.Create(postalCode);
            var city = new CityId(cityId);
            var auditInfo = AuditInfo.Create(createdAt, createdBy, createdAt, createdBy);
            return new Address(addressDescription1, addressDescription2, addressDescription3, postalCodeValue, city, addressIdentifier, isActive, auditInfo);
        }

        public static Address FromPrimitives(int id, string address1, string? address2, string? address3, string postalCode, int cityId, Guid addressIdentifier, bool isActive, DateTime createdAt, int createdBy, DateTime updatedAt, int updatedBy)
        {
            var addressId = new AddressId(id);
            var addressDescription1 = AddressDescription.CreateRequired(address1);
            var addressDescription2 = AddressDescription.CreateOptional(address2);
            var addressDescription3 = AddressDescription.CreateOptional(address3);
            var postalCodeValue = PostalCode.Create(postalCode);
            var city = new CityId(cityId);
            var auditInfo = AuditInfo.Create(createdAt, createdBy, updatedAt, updatedBy);
            return new Address(addressId, addressDescription1, addressDescription2, addressDescription3, postalCodeValue, city, addressIdentifier, isActive, auditInfo);
        }

        public static AddressId SetAddressId(int id)
        {
            return new AddressId(id);
        }
    }
}
