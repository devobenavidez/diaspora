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

namespace Diaspora.Infrastructure.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly DBContext _context;

        public ServiceRepository(DBContext context)
        {
            _context = context;
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

        
    }
}
