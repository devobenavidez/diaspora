using Diaspora.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Infrastructure.Abstractions
{
    public interface IUnitOfWork
    {
        IAddressRepository Addresses { get; }
        IUserRepository Users { get; }
        IPersonRepository Persons { get; }
        IServiceRepository Services { get; }


        Task<int> CompleteAsync();  // Método para confirmar los cambios
    }
}
