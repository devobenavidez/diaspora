using Diaspora.Domain.Entities.Service;
using Diaspora.Domain.Entities.UnitTariff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Abstractions
{
    public interface IServiceRepository
    {
        Task<Service> AddService(Service service);

        Task<decimal> GetCheapestService(int originCity, int destinationCity, int serviceTypeId, int minimalUnits);

        void SyncDomainEntityWithDatabase(Service serviceEntity);
    }
}
