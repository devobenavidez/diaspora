using Diaspora.Application.Exceptions;
using Diaspora.Application.Services.DTOs;
using Diaspora.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Application.Services.Queries.GetServiceQuote
{
    public class GetServiceQuoteQueryHandler : IRequestHandler<GetServiceQuoteQuery, ServiceQuoteDto>
    {

        private readonly IUnitRateRepository _unitRateRepository;
        private readonly string NotFoundExceptionLabel = "Unit rate";

        public GetServiceQuoteQueryHandler(IUnitRateRepository unitRateRepository)
        {
            _unitRateRepository = unitRateRepository;
        }

        public async Task<ServiceQuoteDto> Handle(GetServiceQuoteQuery request, CancellationToken cancellationToken)
        {

            var unitRate = await _unitRateRepository.GetUnitRateService(request.OriginCityId, request.DestinationCityId, request.ServiceTypeId);

            if (unitRate == null)
                throw NotFoundException.ForResource(NotFoundExceptionLabel, request.ServiceTypeId);

            var serviceQuotePrice = unitRate.CalculatePrice(request.Weight);
            var serviceImportDuties = unitRate.CalculateImportDuties(request.DeclaredValue);

            var serviceQuoteDto = new ServiceQuoteDto
            {
                OriginCityId = request.OriginCityId,
                DestinationCityId = request.DestinationCityId,
                ServiceTypeId = request.ServiceTypeId,
                Price = serviceQuotePrice,
                ImportDuties = serviceImportDuties,
            };

            return serviceQuoteDto;
        }
    }
}
