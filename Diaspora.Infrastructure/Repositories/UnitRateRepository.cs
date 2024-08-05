using Diaspora.Domain.Abstractions;
using UnitRateEntity = Diaspora.Domain.Entities.UnitTariff.UnitRate;
using Diaspora.Infrastructure.Data;
using Diaspora.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Infrastructure.Repositories
{
    public class UnitRateRepository : IUnitRateRepository
    {
        private readonly DBContext _context;

        public UnitRateRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<UnitRateEntity> GetUnitRateService(int originCity, int destinationCity, int serviceTypeId)
        {
            var unitRate = await _context.Unitrates
                .Where(ut => ut.OriginCityId == originCity && ut.DestinationCityId == destinationCity
                             && ut.ServiceTypeId == serviceTypeId && !ut.DeletedAt.HasValue && ut.IsActive == true)
                .FirstOrDefaultAsync();

            return MapUnitTariffToEntity(unitRate);
        }

        private UnitRateEntity MapUnitTariffToEntity(Unitrate unitTariff)
        {
            UnitRateEntity unitTariffEntity = UnitRateEntity.FromPrimitives(
                                                    unitTariff.Id,
                                                    unitTariff.OriginCityId,
                                                    unitTariff.DestinationCityId,
                                                    unitTariff.ServiceTypeId,
                                                    unitTariff.UnitPrice,
                                                    unitTariff.IsActive,
                                                    unitTariff.CreatedAt,
                                                    unitTariff.CreatedBy,
                                                    unitTariff.UpdatedAt,
                                                    unitTariff.UpdatedBy);
            return unitTariffEntity;
        }
    }
}
