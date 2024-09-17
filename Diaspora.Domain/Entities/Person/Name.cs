using Diaspora.Domain.Entities.Address;
using Diaspora.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Entities.Person
{
    public class Name
    {
        public string Value { get; }

        private const int MaxLength = 255;

        private Name(string name, bool isRequired)
        {

            if (isRequired && string.IsNullOrWhiteSpace(name))
            {
                throw ArgumentNullOrWhiteSpaceException.ForParameter(nameof(name));
            }

            if (name?.Length > MaxLength)
            {
                throw ArgumentTooLongException.ForParameter(nameof(name), MaxLength, name.Length);
            }
            Value = name;
        }

        public static Name CreateRequired(string value) => new Name(value, true);
        public static Name CreateNotRequired(string value) => new Name(value, false);

#pragma warning disable SA1201 // A operator should not follow a method
        public static bool operator ==(Name left, Name right)
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

        public static bool operator !=(Name left, Name right)
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

            return Equals((Name)obj);
        }

        public bool Equals(Name other)
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
