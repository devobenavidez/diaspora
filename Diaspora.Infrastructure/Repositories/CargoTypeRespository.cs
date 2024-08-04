using Diaspora.Domain.Abstractions;
using CargoTypeEntity = Diaspora.Domain.Entities.ServiceType.CargoType;
using Diaspora.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diaspora.Infrastructure.Models;

namespace Diaspora.Infrastructure.Repositories
{
    public class CargoTypeRespository : ICargoTypeRepository
    {
        private readonly DBContext _context;

        public CargoTypeRespository(DBContext context)
        {
            _context = context;
        }

        public async Task<CargoTypeEntity> GetServiceTypeById(int id)
        {
            var serviceType = await _context.Cargotypes.FindAsync(id);

            if (serviceType == null)
            {
                return null;
            }

            return MapServiceTypeToEntity(serviceType);
        }

        private CargoTypeEntity MapServiceTypeToEntity(Cargotype serviceType)
        {
            CargoTypeEntity serviceTypeEntity = CargoTypeEntity.FromPrimitives(
                                                                    serviceType.Id,
                                                                    serviceType.Description,
                                                                    serviceType.IsActive,
                                                                    serviceType.CreatedAt,
                                                                    serviceType.CreatedBy,
                                                                    serviceType.UpdatedAt,
                                                                    serviceType.UpdatedBy);

            return serviceTypeEntity;
        }
    }
}
