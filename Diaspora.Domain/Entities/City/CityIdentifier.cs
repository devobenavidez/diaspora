using Diaspora.Domain.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Entities.City
{
    public class CityIdentifier : Id
    {
        public CityIdentifier(int value) : base(value)
        {
        }
    }
}
