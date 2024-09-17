﻿using Diaspora.Domain.Entities.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Abstractions
{
    public interface IAddressRepository
    {
        Task<Address> AddAsync(Address address);
        void SyncDomainEntityWithDatabase(Address addressEntity);
    }
}
