using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Application.Services.DTOs
{
    public class CheapestServiceDto
    {
        public int OriginCityId { get; set; }
        public int DestinationCityId { get; set; }
        public int ServiceTypeId { get; set; }
        public decimal Price { get; set; }
    }
}
