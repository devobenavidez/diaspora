using Diaspora.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Shared.ValueObjects
{
    public class AddressId : IEquatable<AddressId>
    {
        public int? Value { get; }

        private AddressId(int? value, bool isRequired)
        {
            if (isRequired && !value.HasValue)
            {
                throw new ArgumentNullException(nameof(value), "The address ID cannot be null.");
            }

            if (value.HasValue && value < 0)
            {
                throw InvalidIdException.ForValue(value.Value);
            }

            Value = value;
        }

        public static AddressId CreateRequired(int value) => new AddressId(value, true);

        public static AddressId CreateOptional(int? value) => new AddressId(value, false);

#pragma warning disable SA1201 // A operator should not follow a method
        public static bool operator ==(AddressId left, AddressId right)
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

        public static bool operator !=(AddressId left, AddressId right)
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

            return Equals((AddressId)obj);
        }

        public bool Equals(AddressId other)
        {
            return other != null && Value == other.Value;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString()
        {
            return Value?.ToString() ?? "null";
        }
    }
}
