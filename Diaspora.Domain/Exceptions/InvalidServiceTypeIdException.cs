using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Exceptions
{
    public class InvalidServiceTypeIdException : Exception
    {
        public InvalidServiceTypeIdException(int value)
            : base($"Service Type ID '{value}' is invalid. Service Type ID must be a positive integer.")
        {
        }

        public InvalidServiceTypeIdException(string message)
            : base(message)
        {
        }

        public InvalidServiceTypeIdException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
