using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Application.Address.DTOs
{
    public class AddressDto
    {
        public int Id { get; set; }

        public string Address1 { get; set; }

        public string? Address2 { get; set; }

        public string? Address3 { get; set; }

        public string PostalCode { get; set; }

        public int CityId { get; set; }

        public Guid AddressIdentifier { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime? DeletedAt { get; set; }
    }
}
