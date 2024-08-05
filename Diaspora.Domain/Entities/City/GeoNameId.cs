using Diaspora.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Entities.City
{
    public class GeoNameId : IEquatable<GeoNameId>
    {
        public int Value { get; }

        public GeoNameId(int value)
        {
            if (value <= 0)
            {
                throw new InvalidGeoNameIdException(value);
            }

            Value = value;
        }

        public static GeoNameId Create(int value) => new GeoNameId(value);

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return Equals((GeoNameId)obj);
        }

        public bool Equals(GeoNameId other)
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
        public static bool operator ==(GeoNameId left, GeoNameId right)
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

        public static bool operator !=(GeoNameId left, GeoNameId right)
        {
            return !(left == right);
        }
#pragma warning restore SA1201 // A operator should not follow a method
    }
}
