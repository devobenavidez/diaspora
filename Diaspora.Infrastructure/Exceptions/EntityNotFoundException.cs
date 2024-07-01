using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Infrastructure.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public string EntityName { get; }

        public object EntityId { get; }

        public EntityNotFoundException(string entityName, object entityId)
            : base($"{entityName} with ID {entityId} not found.")
        {
            EntityName = entityName;
            EntityId = entityId;
        }

        public EntityNotFoundException(string entityName, object entityId, string message)
            : base(message)
        {
            EntityName = entityName;
            EntityId = entityId;
        }

        public EntityNotFoundException(string entityName, object entityId, string message, Exception innerException)
            : base(message, innerException)
        {
            EntityName = entityName;
            EntityId = entityId;
        }
    }
}
