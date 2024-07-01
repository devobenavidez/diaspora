using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Exceptions
{
    public class ArgumentNullOrEmptyException : Exception
    {
        public ArgumentNullOrEmptyException(string parameterName)
            : base($"The argument '{parameterName}' cannot be null or empty.")
        {
        }

        public static ArgumentNullOrEmptyException ForParameter(string parameterName)
        {
            return new ArgumentNullOrEmptyException(parameterName);
        }
    }
}
