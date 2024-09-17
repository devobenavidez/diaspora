using Diaspora.Application.Exceptions;
using Diaspora.Application.Services.DTOs;
using Diaspora.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Application.Services.Queries.GetCheapestService
{
    public class CheapestServiceQueryHandler : IRequestHandler<CheapestServiceQuery, CheapestServiceDto>
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly ICityRepository _cityRepository;
        private readonly ICargoTypeRepository _serviceTypeRepository;
        private readonly int MinimalUnits = 1;

        public CheapestServiceQueryHandler(IServiceRepository serviceRepository, ICityRepository cityRepository, ICargoTypeRepository serviceTypeRepository)
        {
            _serviceRepository = serviceRepository;
            _cityRepository = cityRepository;
            _serviceTypeRepository = serviceTypeRepository;
        }

        public async Task<CheapestServiceDto> Handle(CheapestServiceQuery request, CancellationToken cancellationToken)
        {
            var originDestinationList = await _cityRepository.GetOriginAndDestinationCitiesById(request.OriginCityId, request.DestinationCityId);

            if (originDestinationList.Count == 0)
            {
                List<int> citiesList = new List<int> { request.OriginCityId, request.DestinationCityId };
                throw NotFoundException.ForResources("Cities", citiesList.Cast<object>());
            }

            if (originDestinationList.Count == 1)
            {
                var originCity = originDestinationList.Where(x => x.Id.Value == request.OriginCityId).FirstOrDefault();
                if (originCity == null)
                    throw NotFoundException.ForResource("Origin city", request.OriginCityId);
                else
                    throw NotFoundException.ForResource("Destination city", request.DestinationCityId);
            }

            var serviceType = await _serviceTypeRepository.GetServiceTypeById(request.ServiceTypeId);
            if (serviceType == null)
                throw NotFoundException.ForResource("Service type", request.ServiceTypeId);

            var cheapestService = await _serviceRepository.GetCheapestService(request.OriginCityId, request.DestinationCityId, request.ServiceTypeId, MinimalUnits);

            var cheapestServiceDto = new CheapestServiceDto
            {
                OriginCityId = request.OriginCityId,
                DestinationCityId = request.DestinationCityId,
                ServiceTypeId = request.ServiceTypeId,
                Price = cheapestService,
            };

            return cheapestServiceDto;
        }
    }
}
