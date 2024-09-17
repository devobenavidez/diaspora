using Diaspora.Domain.Abstractions;
using AddressEntity = Diaspora.Domain.Entities.Address.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diaspora.Infrastructure.Models;
using Diaspora.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Diaspora.Infrastructure.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly DBContext _dbContext;

        public AddressRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AddressEntity> AddAsync(AddressEntity address)
        {


            var addressModel = MapEntityToModel(address);
            var addressResult = await _dbContext.Addresses.AddAsync(addressModel);
            //await _dbContext.SaveChangesAsync();
            return MapModelToEntity(addressResult.Entity);
        }

        public void SyncDomainEntityWithDatabase(AddressEntity addressEntity)
        {
            var addressModel = _dbContext.Addresses.Local.FirstOrDefault(p => p.AddressIdentifier == addressEntity.AddressIdentifier);
            if (addressModel != null)
            {
                addressEntity.Id = AddressEntity.SetAddressId(addressModel.Id);
            }
        }

        private Address MapEntityToModel(AddressEntity addressEntity)
        {
            return new Address
            {
                Address1 = addressEntity.Address1.Value,
                Address2 = addressEntity.Address2.Value,
                Address3 = addressEntity.Address3.Value,
                CityId = addressEntity.CityId.Value,
                AddressIdentifier = addressEntity.AddressIdentifier,
                PostalCode = addressEntity.PostalCode.Value,
                IsActive = addressEntity.IsActive,
                CreatedAt = addressEntity.AuditInfo.CreatedAt,
                CreatedBy = addressEntity.AuditInfo.CreatedBy,
                UpdatedAt = addressEntity.AuditInfo.UpdatedAt,
                UpdatedBy = addressEntity.AuditInfo.UpdatedBy
            };
        }

        private AddressEntity MapModelToEntity(Address address)
        {
            AddressEntity addressEntity = AddressEntity.FromPrimitives(
                                                address.Id,
                                                address.Address1,
                                                address.Address2,
                                                address.Address3,
                                                address.PostalCode,
                                                address.CityId,
                                                address.AddressIdentifier,
                                                address.IsActive,
                                                address.CreatedAt,
                                                address.CreatedBy,
                                                address.UpdatedAt,
                                                address.UpdatedBy
                                                );
            return addressEntity;
        }
    }
}
