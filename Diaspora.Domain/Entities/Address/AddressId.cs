using Diaspora.Domain.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Entities.Address
{
    public class AddressId : Id
    {
        public AddressId(int value) : base(value)
        {
        }
    }
}
