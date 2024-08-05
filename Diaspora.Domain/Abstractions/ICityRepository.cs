using Diaspora.Domain.Entities.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Abstractions
{
    public interface ICityRepository
    {
        Task<City> GetCityById(int id);
        Task<List<City>> GetOriginAndDestinationCitiesById(int originCity, int destinationCity);
    }
}
