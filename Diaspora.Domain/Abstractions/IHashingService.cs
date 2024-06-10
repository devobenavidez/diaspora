using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Abstractions
{
    public interface IHashingService
    {
        string HashPassword(string password, byte[] salt);
        bool VerifyPassword(string hashedPassword, string password, byte[] salt);
    }
}
