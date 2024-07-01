using Diaspora.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Entities.User
{
    public class UserId : Id
    {
        public UserId(int value) : base(value)
        {
        }

    }
}
