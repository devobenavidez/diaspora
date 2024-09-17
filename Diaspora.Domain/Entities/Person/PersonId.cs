using Diaspora.Domain.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Entities.Person
{
    public class PersonId : Id
    {
        public PersonId(int value) : base(value)
        {
        }
    }
}
