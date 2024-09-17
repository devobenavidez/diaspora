using Diaspora.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Shared.ValueObjects
{
    public class UserId : IEquatable<UserId>
    {
        public int? Value { get; }

        private UserId(int? value, bool isRequired)
        {
            if (isRequired && !value.HasValue)
            {
                throw new ArgumentNullException(nameof(value), "The user ID cannot be null.");
            }

            if (value.HasValue && value < 0)
            {
                throw InvalidIdException.ForValue(value.Value);
            }

            Value = value;
        }

        public static UserId CreateRequired(int value) => new UserId(value, true);

        public static UserId CreateOptional(int? value) => new UserId(value, false);

#pragma warning disable SA1201 // A operator should not follow a method
        public static bool operator ==(UserId left, UserId right)
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

        public static bool operator !=(UserId left, UserId right)
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

            return Equals((UserId)obj);
        }

        public bool Equals(UserId other)
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
