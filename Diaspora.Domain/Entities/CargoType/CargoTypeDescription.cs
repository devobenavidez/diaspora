using Diaspora.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Entities.ServiceType
{
    public class CargoTypeDescription
    {
        public string Value { get; }

        private const int MaxLength = 255;

        private CargoTypeDescription(string serviceTypeDescription)
        {
            if (string.IsNullOrWhiteSpace(serviceTypeDescription))
            {
                throw ArgumentNullOrWhiteSpaceException.ForParameter(nameof(serviceTypeDescription));
            }

            if (serviceTypeDescription.Length > MaxLength)
            {
                throw ArgumentTooLongException.ForParameter(nameof(serviceTypeDescription), MaxLength, serviceTypeDescription.Length);
            }

            Value = serviceTypeDescription;
        }

        public static CargoTypeDescription Create(string value) => new CargoTypeDescription(value);

#pragma warning disable SA1201 // A operator should not follow a method
        public static bool operator ==(CargoTypeDescription left, CargoTypeDescription right)
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

        public static bool operator !=(CargoTypeDescription left, CargoTypeDescription right)
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

            return Equals((CargoTypeDescription)obj);
        }

        public bool Equals(CargoTypeDescription other)
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
