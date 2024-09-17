using Diaspora.Domain.Abstractions;
using Diaspora.Domain.Entities.UnitTariff;
using Diaspora.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using UnitTariffEntity = Diaspora.Domain.Entities.UnitTariff.UnitRate;
using Diaspora.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceEntity = Diaspora.Domain.Entities.Service.Service;

namespace Diaspora.Infrastructure.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly DBContext _context;

        public ServiceRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<ServiceEntity> AddService(ServiceEntity serviceEntity)
        {
            var service = MapEntityToModel(serviceEntity);
            var serviceResult = await _context.Services.AddAsync(service);

            return MapModelToEntity(serviceResult.Entity);
        }

        public void SyncDomainEntityWithDatabase(ServiceEntity serviceEntity)
        {
            var serviceModel = _context.Services.Local.FirstOrDefault(p => p.PaymentId == serviceEntity.PaymentId);
            if (serviceModel != null)
            {
                serviceEntity.Id = ServiceEntity.SetServiceId(serviceModel.Id);
            }
        }

        public async Task<decimal> GetCheapestService(int originCity, int destinationCity, int serviceTypeId, int minimalUnits)
        {
            var minimalPrice = await _context.Unitrates
                .Where(ut => ut.OriginCityId == originCity && ut.DestinationCityId == destinationCity
                             && ut.ServiceTypeId == serviceTypeId && !ut.DeletedAt.HasValue && ut.IsActive == true)
                .OrderBy(ut => ut.UnitPrice)
                .Select(ut => minimalUnits * ut.UnitPrice)
                .FirstOrDefaultAsync();

            return minimalPrice;
        }

        private ServiceEntity MapModelToEntity(Service service)
        {
            return ServiceEntity.FromPrimitives(
                                service.Id,
                                service.OriginCity,
                                service.DestinationCity,
                                service.CourierId,
                                service.SenderId,
                                service.ReceiverId,
                                service.PickupDate,
                                service.IsActive,
                                service.PaymentId,
                                service.ServiceTypeId,
                                service.CreatedAt,
                                service.CreatedBy,
                                service.UpdatedAt,
                                service.UpdatedBy
                                );
        }

        private Service MapEntityToModel(ServiceEntity serviceEntity)
        {
            return new Service
            {
                OriginCity = serviceEntity.OriginCity.Value,
                DestinationCity = serviceEntity.DestinationCity.Value,
                CourierId = serviceEntity.CourierId.Value,
                SenderId = serviceEntity.SenderId.Value ?? 0,
                ReceiverId = serviceEntity.ReceiverId.Value ?? 0,
                PickupDate = serviceEntity.PickupDate.Value,
                IsActive = serviceEntity.IsActive,
                PaymentId = serviceEntity.PaymentId,
                ServiceTypeId = serviceEntity.ServiceTypeId,
                CreatedAt = serviceEntity.AuditInfo.CreatedAt,
                CreatedBy = serviceEntity.AuditInfo.CreatedBy,
                UpdatedAt = serviceEntity.AuditInfo.UpdatedAt,
                UpdatedBy = serviceEntity.AuditInfo.UpdatedBy,
            };
        }
    }
}
