using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Exceptions
{
    public class InvalidGeoNameIdException : Exception
    {
        public InvalidGeoNameIdException(int value)
            : base($"GeoName ID '{value}' is invalid. GeoName ID must be a positive integer.")
        {
        }

        public InvalidGeoNameIdException(string message)
            : base(message)
        {
        }

        public InvalidGeoNameIdException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
