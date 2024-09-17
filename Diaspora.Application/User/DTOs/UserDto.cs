using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Application.Users.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
