using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Application.Exceptions
{
    public class PaymentProcessingException : Exception
    {
        public PaymentProcessingException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
