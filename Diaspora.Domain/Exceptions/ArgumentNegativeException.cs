using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Exceptions
{
    public class ArgumentNegativeException : Exception
    {
        public ArgumentNegativeException(string parameterName, object value)
            : base($"The argument '{parameterName}' cannot be negative. Value provided: {value}.")
        {
        }

        public static ArgumentNegativeException ForParameter(string parameterName, decimal value)
        {
            return new ArgumentNegativeException(parameterName, value);
        }

        public static ArgumentNegativeException ForParameter(string parameterName, int value)
        {
            return new ArgumentNegativeException(parameterName, value);
        }
    }
}
