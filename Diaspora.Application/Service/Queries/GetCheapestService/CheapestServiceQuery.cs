using Diaspora.Application.Services.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Application.Services.Queries.GetCheapestService
{
    public class CheapestServiceQuery : IRequest<CheapestServiceDto>
    {
        public int OriginCityId { get; }
        public int DestinationCityId { get; }
        public int ServiceTypeId { get; }

        public CheapestServiceQuery(int originCityId, int destinationCityId, int serviceTypeId)
        {
            OriginCityId = originCityId;
            DestinationCityId = destinationCityId;
            ServiceTypeId = serviceTypeId;
        }
    }
}
