using Diaspora.Domain.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Entities.Service
{
    public class ServiceId : Id
    {
        public ServiceId(int value) : base(value)
        {
        }
    }
}
