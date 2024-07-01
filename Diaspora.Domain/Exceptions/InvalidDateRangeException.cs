using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Exceptions
{
    public class InvalidDateRangeException : Exception
    {
        public InvalidDateRangeException(string message)
            : base(message)
        {
        }

        public static InvalidDateRangeException ForDates(string startDateName, string endDateName)
        {
            return new InvalidDateRangeException($"The date '{startDateName}' must be less than or equal to '{endDateName}'.");
        }
    }
}
