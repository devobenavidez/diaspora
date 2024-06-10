using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Exceptions
{
    public class ArgumentTooLongException : Exception
    {
        public ArgumentTooLongException(string parameterName, int maxLength, int actualLength)
            : base($"The argument '{parameterName}' cannot exceed {maxLength} characters. Actual length: {actualLength}.")
        {
        }

        public static ArgumentTooLongException ForParameter(string parameterName, int maxLength, int actualLength)
        {
            return new ArgumentTooLongException(parameterName, maxLength, actualLength);
        }
    }
}
