using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Exceptions
{
    public class InvalidCourierIdException : Exception
    {
        public InvalidCourierIdException(int value)
            : base($"Courier ID must be a positive integer. Value: {value}")
        {
        }

        public InvalidCourierIdException(string message)
            : base(message)
        {
        }

        public InvalidCourierIdException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
