using Diaspora.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Shared.ValueObjects
{
    public class CourierId : IEquatable<CourierId>
    {
        public int Value { get; }

        public CourierId(int value)
        {
            if (value <= 0)
            {
                throw new InvalidCourierIdException(value);
            }

            Value = value;
        }

        public static CourierId Create(int value) => new CourierId(value);

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return Equals((CourierId)obj);
        }

        public bool Equals(CourierId other)
        {
            return other != null && Value == other.Value;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString()
        {
            return Value.ToString();
        }

#pragma warning disable SA1201 // A operator should not follow a method
        public static bool operator ==(CourierId left, CourierId right)
        {
            if (ReferenceEquals(left, right))
            {
                return true;
            }

            if (left is null || right is null)
            {
                return false;
            }

            return left.Equals(right);
        }

        public static bool operator !=(CourierId left, CourierId right)
        {
            return !(left == right);
        }
#pragma warning restore SA1201 // A operator should not follow a method
    }
}
