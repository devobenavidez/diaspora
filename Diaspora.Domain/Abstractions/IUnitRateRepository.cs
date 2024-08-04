using Diaspora.Domain.Entities.UnitTariff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Abstractions
{
    public interface IUnitRateRepository
    {
        Task<UnitRate> GetUnitRateService(int originCity, int destinationCity, int serviceTypeId);
    }
}
