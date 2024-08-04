using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Exceptions
{
    public class InvalidProvinceIdException : Exception
    {
        public InvalidProvinceIdException(int value)
            : base($"Province ID '{value}' is invalid. Province ID must be a positive integer.")
        {
        }

        public InvalidProvinceIdException(string message)
            : base(message)
        {
        }

        public InvalidProvinceIdException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
