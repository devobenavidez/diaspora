using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Exceptions
{
    public class InvalidEmailFormatException : Exception
    {
        public InvalidEmailFormatException(string email)
            : base($"The email '{email}' is not in a valid format.")
        {
        }

        public static InvalidEmailFormatException ForEmail(string email)
        {
            return new InvalidEmailFormatException(email);
        }
    }
}
