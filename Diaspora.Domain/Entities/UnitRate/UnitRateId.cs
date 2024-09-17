using Diaspora.Domain.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Entities.UnitTariff
{
    public class UnitRateId : Id
    {
        public UnitRateId(int value) : base(value)
        {
        }
    }
}
