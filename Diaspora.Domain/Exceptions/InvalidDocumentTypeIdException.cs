using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Exceptions
{
    public class InvalidDocumentTypeIdException : Exception
    {
        public InvalidDocumentTypeIdException(int value)
            : base($"Document Type ID '{value}' is invalid. Document Type ID must be a positive integer.")
        {
        }

        public InvalidDocumentTypeIdException(string message)
            : base(message)
        {
        }

        public InvalidDocumentTypeIdException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
