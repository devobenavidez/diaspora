using Diaspora.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Entities.User
{
    public class UserName
    {
        public string Value { get; }

        private const int MaxLength = 255;

        private UserName(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw ArgumentNullOrWhiteSpaceException.ForParameter(nameof(userName));
            }

            if (userName.Length > MaxLength)
            {
                throw ArgumentTooLongException.ForParameter(nameof(userName), MaxLength, userName.Length);
            }

            Value = userName;
        }

        public static UserName Create(string value) => new UserName(value);

        #pragma warning disable SA1201 // A operator should not follow a method
        public static bool operator ==(UserName left, UserName right)
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

        public static bool operator !=(UserName left, UserName right)
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

            return Equals((UserName)obj);
        }

        public bool Equals(UserName other)
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
