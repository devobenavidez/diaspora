using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Exceptions
{
    public class InvalidPostalCodeAlphanumericException : Exception
    {
        public InvalidPostalCodeAlphanumericException()
        {
        }

        public InvalidPostalCodeAlphanumericException(string message)
            : base(message)
        {
        }

        public InvalidPostalCodeAlphanumericException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public static InvalidPostalCodeAlphanumericException ForParameter(string paramName)
        {
            return new InvalidPostalCodeAlphanumericException($"Postal code for parameter '{paramName}' can only contain alphanumeric characters.");
        }
    }
}
