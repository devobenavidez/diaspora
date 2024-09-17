using Diaspora.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Entities.Person
{
    public class DocumentIdentifier
    {
        public string Value { get; }

        private const int MaxLength = 50;

        private DocumentIdentifier(string identifier)
        {
            if (string.IsNullOrWhiteSpace(identifier))
            {
                throw ArgumentNullOrWhiteSpaceException.ForParameter(nameof(identifier));
            }

            if (identifier.Length > MaxLength)
            {
                throw ArgumentTooLongException.ForParameter(nameof(identifier), MaxLength, identifier.Length);
            }

            Value = identifier;
        }

        public static DocumentIdentifier Create(string value) => new DocumentIdentifier(value);

#pragma warning disable SA1201 // A operator should not follow a method
        public static bool operator ==(DocumentIdentifier left, DocumentIdentifier right)
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

        public static bool operator !=(DocumentIdentifier left, DocumentIdentifier right)
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

            return Equals((DocumentIdentifier)obj);
        }

        public bool Equals(DocumentIdentifier other)
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
