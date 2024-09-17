using Diaspora.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Diaspora.Domain.Entities.Address
{
    public class PostalCode
    {
        public string Value { get; }

        private const int MaxLength = 20;
        private static readonly Regex AlphanumericRegex = new Regex("^[a-zA-Z0-9]*$", RegexOptions.Compiled);

        private PostalCode(string postalCode)
        {
            if (string.IsNullOrWhiteSpace(postalCode))
            {
                throw ArgumentNullOrWhiteSpaceException.ForParameter(nameof(postalCode));
            }

            if (postalCode.Length > MaxLength)
            {
                throw ArgumentTooLongException.ForParameter(nameof(postalCode), MaxLength, postalCode.Length);
            }

            if (!AlphanumericRegex.IsMatch(postalCode))
            {
                throw InvalidPostalCodeAlphanumericException.ForParameter(nameof(postalCode));
            }

            Value = postalCode;
        }

        public static PostalCode Create(string value) => new PostalCode(value);

#pragma warning disable SA1201 // A operator should not follow a method
        public static bool operator ==(PostalCode left, PostalCode right)
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

        public static bool operator !=(PostalCode left, PostalCode right)
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

            return Equals((PostalCode)obj);
        }

        public bool Equals(PostalCode other)
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
