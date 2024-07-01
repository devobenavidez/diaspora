using Diaspora.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Entities.PersonType
{
    public class PersonTypeDescription
    {
        public string Value { get; }

        private PersonTypeDescription(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw ArgumentNullOrWhiteSpaceException.ForParameter(nameof(value));
            }

            if (value.Length > 255)
            {
                throw ArgumentTooLongException.ForParameter(nameof(value), 255, value.Length);
            }

            Value = value;
        }

        public static PersonTypeDescription Create(string value) => new PersonTypeDescription(value);
    }
}
