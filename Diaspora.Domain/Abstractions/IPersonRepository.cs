using Diaspora.Domain.Entities.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Abstractions
{
    public interface IPersonRepository
    {
        Task<Person> AddAsync(Person person);
        Task UpdateAsync(Person personEntity);
        void SyncDomainEntityWithDatabase(Person personEntity);
    }
}
