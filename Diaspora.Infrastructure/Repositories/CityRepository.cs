using Diaspora.Domain.Abstractions;
using CityEntity = Diaspora.Domain.Entities.City.City;
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
    public class CityRepository : ICityRepository
    {
        private readonly DBContext _context;

        public CityRepository(DBContext context)
        {
            _context = context;
        }

        public Task<CityEntity> GetCityById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CityEntity>> GetOriginAndDestinationCitiesById(int originCity, int destinationCity)
        {
            List<int> cityIds = new List<int> { originCity, destinationCity };
            var cities = await _context.Cities.Where(c => cityIds.Contains(c.Id)).ToListAsync();

            return cities.Select(c => MapCityToEntity(c)).ToList();
        }

        private CityEntity MapCityToEntity(City city)
        {
            CityEntity cityEntity = CityEntity.FromPrimitives(
                                                  city.Id,
                                                  city.Name,
                                                  city.ProvinceId,
                                                  city.GeoNameId,
                                                  city.IsActive,
                                                  city.CreatedAt,
                                                  city.CreatedBy,
                                                  city.UpdatedAt,
                                                  city.UpdatedBy);

            return cityEntity;
        }
    }
}
