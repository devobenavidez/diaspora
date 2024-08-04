using Diaspora.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Shared
{
    public class CityId : IEquatable<CityId>
    {
        public int Value { get; }

        public CityId(int value)
        {
            if (value <= 0)
            {
                throw new InvalidCityIdException(value);
            }

            Value = value;
        }

        public static CityId Create(int value) => new CityId(value);

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return Equals((CityId)obj);
        }

        public bool Equals(CityId other)
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
        public static bool operator ==(CityId left, CityId right)
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

        public static bool operator !=(CityId left, CityId right)
        {
            return !(left == right);
        }
        #pragma warning restore SA1201 // A operator should not follow a method
    }
}
