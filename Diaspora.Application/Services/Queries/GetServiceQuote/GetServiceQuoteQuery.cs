using Diaspora.Application.Services.DTOs;
using Diaspora.Application.Services.Queries.GetCheapestService;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Application.Services.Queries.GetServiceQuote
{
    public class GetServiceQuoteQuery : IRequest<ServiceQuoteDto>
    {
        public int OriginCityId { get; }
        public int DestinationCityId { get; }
        public int ServiceTypeId { get; }
        public decimal Weight { get; }

        public decimal Height { get; }

        public decimal Width { get; }

        public decimal Length { get; }
        public decimal DeclaredValue { get; }

        public GetServiceQuoteQuery(
            int originCityId,
            int destinationCityId,
            int serviceTypeId,
            decimal weight,
            decimal height,
            decimal width,
            decimal length,
            decimal declaredValue)
        {
            OriginCityId = originCityId;
            DestinationCityId = destinationCityId;
            ServiceTypeId = serviceTypeId;
            Weight = weight;
            Height = height;
            Width = width;
            Length = length;
            DeclaredValue = declaredValue;
        }
    }
}
