using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Exceptions
{
    public class InvalidDateException : Exception
    {
        public InvalidDateException(string message) : base(message) { }

        public static InvalidDateException ForFutureDate(DateTime date)
        {
            return new InvalidDateException($"The date '{date}' cannot be in the future.");
        }
    }
}
