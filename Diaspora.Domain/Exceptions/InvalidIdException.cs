using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Exceptions
{
    public class InvalidIdException : Exception
    {
        public InvalidIdException(string message) : base(message) { }

        public static InvalidIdException ForValue(int value)
        {
            return new InvalidIdException($"The ID '{value}' is not valid. It must be greater than zero.");
        }
    }
}
