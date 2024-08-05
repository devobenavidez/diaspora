using Diaspora.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Entities.City
{
    public class CityName
    {
        public string Value { get; }

        private const int MaxLength = 100;

        private CityName(string cityName)
        {
            if (string.IsNullOrWhiteSpace(cityName))
            {
                throw ArgumentNullOrWhiteSpaceException.ForParameter(nameof(cityName));
            }

            if (cityName.Length > MaxLength)
            {
                throw ArgumentTooLongException.ForParameter(nameof(cityName), MaxLength, cityName.Length);
            }

            Value = cityName;
        }

        public static CityName Create(string value) => new CityName(value);

#pragma warning disable SA1201 // A operator should not follow a method
        public static bool operator ==(CityName left, CityName right)
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

        public static bool operator !=(CityName left, CityName right)
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

            return Equals((CityName)obj);
        }

        public bool Equals(CityName other)
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
