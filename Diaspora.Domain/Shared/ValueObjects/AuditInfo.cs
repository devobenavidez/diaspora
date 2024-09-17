using Diaspora.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Shared.ValueObjects
{
    public class AuditInfo
    {
        public DateTime CreatedAt { get; }
        public int CreatedBy { get; }
        public DateTime UpdatedAt { get; }
        public int UpdatedBy { get; }
        public DateTime? DeletedAt { get; }

        private AuditInfo(DateTime createdAt, int createdBy, DateTime updatedAt, int updatedBy, DateTime? deletedAt)
        {
            if (createdBy < 0)
            {
                throw InvalidIdentifierException.ForParameter(nameof(createdBy));
            }

            if (updatedBy < 0)
            {
                throw InvalidIdentifierException.ForParameter(nameof(updatedBy));
            }

            CreatedAt = createdAt;
            CreatedBy = createdBy;
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
            DeletedAt = deletedAt;
        }

        public static AuditInfo Create(DateTime createdAt, int createdBy, DateTime updatedAt, int updatedBy, DateTime? deletedAt = null) =>
            new AuditInfo(createdAt, createdBy, updatedAt, updatedBy, deletedAt);
    }
}
