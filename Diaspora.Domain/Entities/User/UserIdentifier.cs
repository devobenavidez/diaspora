using Diaspora.Domain.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Entities.User
{
    public class UserIdentifier : Id
    {
        public UserIdentifier(int value) : base(value)
        {
        }
    }
}
