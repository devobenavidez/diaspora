using Diaspora.Domain.Entities.ServiceType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Abstractions
{
    public interface ICargoTypeRepository
    {
        Task<CargoType> GetServiceTypeById(int id);
    }
}
