using Diaspora.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Entities.Person
{
    public class DocumentTypeId : IEquatable<DocumentTypeId>
    {
        public int Value { get; }

        public DocumentTypeId(int value)
        {
            if (value <= 0)
            {
                throw new InvalidDocumentTypeIdException(value);
            }

            Value = value;
        }

        public static DocumentTypeId Create(int value) => new DocumentTypeId(value);

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return Equals((DocumentTypeId)obj);
        }

        public bool Equals(DocumentTypeId other)
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
        public static bool operator ==(DocumentTypeId left, DocumentTypeId right)
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

        public static bool operator !=(DocumentTypeId left, DocumentTypeId right)
        {
            return !(left == right);
        }
#pragma warning restore SA1201 // A operator should not follow a method
    }
}
