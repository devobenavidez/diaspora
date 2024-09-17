using Diaspora.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Entities.Address
{
    public class AddressDescription
    {
        public string Value { get; }
        private const int MaxLength = 255;

        private AddressDescription(string address, bool isRequired)
        {
            if (isRequired && string.IsNullOrWhiteSpace(address))
            {
                throw ArgumentNullOrWhiteSpaceException.ForParameter(nameof(address));
            }

            if (address?.Length > MaxLength)
            {
                throw ArgumentTooLongException.ForParameter(nameof(address), MaxLength, address.Length);
            }

            Value = address;
        }

        public static AddressDescription CreateRequired(string value) => new AddressDescription(value, true);

        public static AddressDescription CreateOptional(string value) => new AddressDescription(value, false);

#pragma warning disable SA1201 // A operator should not follow a method
        public static bool operator ==(AddressDescription left, AddressDescription right)
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

        public static bool operator !=(AddressDescription left, AddressDescription right)
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

            return Equals((AddressDescription)obj);
        }

        public bool Equals(AddressDescription other)
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
