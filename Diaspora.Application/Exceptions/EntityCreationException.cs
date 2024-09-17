using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Application.Exceptions
{
    public class EntityCreationException : Exception
    {
        public EntityCreationException(string entityName, Exception innerException)
            : base($"There was an error creating the {entityName}.", innerException) { }
    }
}
