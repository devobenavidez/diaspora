using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Exceptions
{
    public class InvalidIdErrorException : Exception
    {
        public InvalidIdErrorException(string value) : base($"{value}")
        {
        }

        public static InvalidIdErrorException WithInvalidValue(string value)
        {
            return new InvalidIdErrorException(value);
        }
    }
}
