using Diaspora.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Entities.User
{
    public class PasswordHash
    {
        public string Value { get; }

        private PasswordHash(string value)
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

        public static PasswordHash Create(string value) => new PasswordHash(value);
    }
}
