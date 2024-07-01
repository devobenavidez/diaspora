using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }

        public static NotFoundException ForUserId(Guid userId)
        {
            return new NotFoundException($"User with ID {userId} not found.");
        }

        public static NotFoundException ForResource(string resourceName, object key)
        {
            return new NotFoundException($"{resourceName} with key {key} not found.");
        }
    }
}
