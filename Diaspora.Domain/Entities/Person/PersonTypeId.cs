using Diaspora.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Entities.Person
{
    public class PersonTypeId : IEquatable<PersonTypeId>
    {
        public int Value { get; }

        public PersonTypeId(int value)
        {
            if (value < 0)
            {
                throw InvalidIdException.ForValue(value);
            }

            Value = value;
        }

        public static PersonTypeId Create(int value) => new PersonTypeId(value);

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return Equals((PersonTypeId)obj);
        }

        public bool Equals(PersonTypeId other)
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
        public static bool operator ==(PersonTypeId left, PersonTypeId right)
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

        public static bool operator !=(PersonTypeId left, PersonTypeId right)
        {
            return !(left == right);
        }
#pragma warning restore SA1201 // A operator should not follow a method
    }
}
