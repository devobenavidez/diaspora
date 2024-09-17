using Diaspora.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Shared.ValueObjects
{
    public class GenericDate : IEquatable<GenericDate>
    {
        public DateTime Value { get; }

        private GenericDate(DateTime value)
        {
            if (value > DateTime.UtcNow)
            {
                throw InvalidDateException.ForFutureDate(value);
            }

            Value = value;
        }

        public static GenericDate Create(DateTime value) => new GenericDate(value);

#pragma warning disable SA1201 // A operator should not follow a method
        public static bool operator ==(GenericDate left, GenericDate right)
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

        public static bool operator !=(GenericDate left, GenericDate right)
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

            return Equals((GenericDate)obj);
        }

        public bool Equals(GenericDate other)
        {
            return other != null && Value == other.Value;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString()
        {
            return Value.ToString("yyyy-MM-dd");
        }
    }
}
