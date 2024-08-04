using Diaspora.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Shared
{
    public class ServiceTypeId : IEquatable<ServiceTypeId>
    {
        public int Value { get; }

        public ServiceTypeId(int value)
        {
            if (value <= 0)
            {
                throw new InvalidServiceTypeIdException(value);
            }

            Value = value;
        }

        public static ServiceTypeId Create(int value) => new ServiceTypeId(value);

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return Equals((ServiceTypeId)obj);
        }

        public bool Equals(ServiceTypeId other)
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
        public static bool operator ==(ServiceTypeId left, ServiceTypeId right)
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

        public static bool operator !=(ServiceTypeId left, ServiceTypeId right)
        {
            return !(left == right);
        }

        #pragma warning restore SA1201 // A operator should not follow a method
    }
}
