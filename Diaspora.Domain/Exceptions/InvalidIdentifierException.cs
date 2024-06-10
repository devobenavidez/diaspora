using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Exceptions
{
    public class InvalidIdentifierException : Exception
    {
        public InvalidIdentifierException(string parameterName)
            : base($"The identifier '{parameterName}' must be a positive integer.")
        {
        }

        public static InvalidIdentifierException ForParameter(string parameterName)
        {
            return new InvalidIdentifierException(parameterName);
        }
    }
}
