using Diaspora.Domain.Abstractions;
using Diaspora.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Infrastructure.Repositories
{
    public class UserRepository : IUser
    {
        private readonly DBContext _context;

        public UserRepository(DBContext context)
        {
            _context = context;
        }


        public async Task<List<Domain.Entities.User>> GetUsersList()
        {

           var users = await _context.Users.ToListAsync();
            List<Domain.Entities.User> userList = new List<Domain.Entities.User>();
            foreach (var user in users)
            {
                Domain.Entities.User userEntity = new Domain.Entities.User();
                userEntity.Id = user.Id;
                userEntity.UserName = user.UserName;
                userEntity.IsActive = user.IsActive;
                userEntity.CreatedAt = user.CreatedAt;
                userEntity.CreatedBy = user.CreatedBy;
                userEntity.UpdatedAt = user.UpdatedAt;
                userEntity.UpdatedBy = user.UpdatedBy;
                userEntity.DeletedAt = user.DeletedAt;
                userList.Add(userEntity);
            }
            return userList;
        }

        
    }
}
