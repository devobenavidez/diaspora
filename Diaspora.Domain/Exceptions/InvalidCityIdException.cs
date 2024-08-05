using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Exceptions
{
    public class InvalidCityIdException : Exception
    {
        public InvalidCityIdException(int value)
            : base($"City ID '{value}' is invalid. City ID must be a positive integer.")
        {
        }

        public InvalidCityIdException(string message)
            : base(message)
        {
        }

        public InvalidCityIdException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
