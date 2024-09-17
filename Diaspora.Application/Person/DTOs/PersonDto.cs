using Diaspora.Application.Address.DTOs;
using Diaspora.Application.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Application.Person.DTOs
{
    public class PersonDto
    {
        public int Id { get; set; }

        public string DocumentIdentifier { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string? LastName { get; set; }

        public string Email { get; set; } = null!;

        public DateTime? BirthDate { get; set; }

        public int DocumentTypeId { get; set; }

        public int PersonTypeId { get; set; }

        public int? AddressId { get; set; }

        public int? UserId { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime? DeletedAt { get; set; }

        public AddressDto? Address { get; set; }
    }
}
