using Diaspora.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Diaspora.Domain.Entities.Person
{
    public class Email
    {
        public string Value { get; }

        private const int MaxLength = 255;
        private static readonly Regex EmailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);

        private Email(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw ArgumentNullOrWhiteSpaceException.ForParameter(nameof(email));
            }

            if (email.Length > MaxLength)
            {
                throw ArgumentTooLongException.ForParameter(nameof(email), MaxLength, email.Length);
            }

            if (!EmailRegex.IsMatch(email))
            {
                throw InvalidEmailFormatException.ForEmail(email);
            }

            Value = email;
        }

        public static Email Create(string value) => new Email(value);

#pragma warning disable SA1201 // A operator should not follow a method
        public static bool operator ==(Email left, Email right)
        {
            if (ReferenceEquals(left, right))
            {
                return true;
            }

            if ((left is null) || (right is null))
            {
                return false;
            }

            return left.Equals(right);
        }

        public static bool operator !=(Email left, Email right)
        {
            return !(left == right);
        }
#pragma warning restore SA1201 // A operator should not follow a method

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return Equals((Email)obj);
        }

        public bool Equals(Email other)
        {
            return other != null && Value == other.Value;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
