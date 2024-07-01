using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Exceptions
{
    public class InvalidIdErrorException : Exception
    {
        public InvalidIdErrorException(string value) : base($"The ID value '{value}' is not a valid Guid.")
        {
        }

        public static InvalidIdErrorException WithInvalidValue(string value)
        {
            return new InvalidIdErrorException(value);
        }
    }
}
