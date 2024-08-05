using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Exceptions
{
    public class InvalidUnitPriceException : Exception
    {
        public InvalidUnitPriceException(decimal value)
            : base($"Unit price '{value}' is invalid. Unit price must be a positive value.")
        {
        }

        public InvalidUnitPriceException(string message)
            : base(message)
        {
        }

        public InvalidUnitPriceException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
