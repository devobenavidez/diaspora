using Diaspora.Domain.Abstractions;
using Diaspora.Infrastructure.Abstractions;
using Diaspora.Infrastructure.Data;
using Diaspora.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Infrastructure.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DBContext _context;

        public IAddressRepository Addresses { get; }
        public IPersonRepository Persons { get; }
        public IUserRepository Users { get; }
        public IServiceRepository Services { get; }

        public UnitOfWork(DBContext context, IAddressRepository addressRepository, IPersonRepository personRepository, IServiceRepository serviceRepository, IUserRepository users)
        {
            _context = context;
            Addresses = new AddressRepository(_context);
            Persons = new PersonRepository(_context);
            Services = new ServiceRepository(_context);
            Users = new UserRepository(_context);
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
