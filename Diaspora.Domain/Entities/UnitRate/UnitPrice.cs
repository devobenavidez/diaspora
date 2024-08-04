using Diaspora.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Entities.UnitTariff
{
    public class UnitPrice : IEquatable<UnitPrice>
    {
        public decimal Value { get; }

        public UnitPrice(decimal value)
        {
            if (value <= 0)
            {
                throw new InvalidUnitPriceException(value);
            }

            Value = value;
        }

        public static UnitPrice Create(decimal value) => new UnitPrice(value);

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return Equals((UnitPrice)obj);
        }

        public bool Equals(UnitPrice other)
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
        public static bool operator ==(UnitPrice left, UnitPrice right)
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

        public static bool operator !=(UnitPrice left, UnitPrice right)
        {
            return !(left == right);
        }
        #pragma warning restore SA1201 // A operator should not follow a method
    }
}
