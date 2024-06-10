using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Exceptions
{
    public class ArgumentNullOrWhiteSpaceException : Exception
    {
        public ArgumentNullOrWhiteSpaceException(string parameterName)
            : base($"The argument '{parameterName}' cannot be null or contain only white spaces.")
        {
        }

        public static ArgumentNullOrWhiteSpaceException ForParameter(string parameterName)
        {
            return new ArgumentNullOrWhiteSpaceException(parameterName);
        }
    }

}
