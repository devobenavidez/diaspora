using Diaspora.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Abstractions
{
    public interface IUserRepository
    {
        Task CreateUser(User user);
        Task<List<User>> GetUsersList();
        Task UpdateUser(User user);
        Task<User> GetUserById(int id);
        Task DeleteUser(User user);
        Task<User> GetByUserNameAsync(string userName);
        Task<User> AddAsync(User user);
        void SyncDomainEntityWithDatabase(User userEntity);
    }
}
