using Diaspora.Domain.Abstractions;
using Diaspora.Infrastructure.Data;
using Diaspora.Infrastructure.Models;
using UserEntity = Diaspora.Domain.Entities.User.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DBContext _context;

        public UserRepository(DBContext context)
        {
            _context = context;
        }

        public async Task CreateUser(UserEntity userEntity)
        {
            User user = new User
            {
                UserName = userEntity.UserName.Value,
                PasswordHash = userEntity.PasswordHash.Value,
                Salt = userEntity.Salt.Value,
                IsActive = userEntity.IsActive,
                CreatedAt = userEntity.AuditInfo.CreatedAt,
                CreatedBy = userEntity.AuditInfo.CreatedBy,
                UpdatedAt = userEntity.AuditInfo.UpdatedAt,
                UpdatedBy = userEntity.AuditInfo.UpdatedBy,
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(UserEntity userEntity)
        {
            User user = await _context.Users.FindAsync(userEntity.Id.Value);
            user.DeletedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }

        public async Task<UserEntity?> GetByUserNameAsync(string userName)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName);
            if (user == null)
            {
                return null;
            }

            return MapUserToEntity(user);
        }

        public async Task<UserEntity?> GetUserById(int id)
        {
            User? user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return null;
            }

            return MapUserToEntity(user);
        }

        public async Task<List<UserEntity>> GetUsersList()
        {
            var users = await _context.Users
                                        .Where(u => u.DeletedAt == null)
                                        .ToListAsync();
            List<UserEntity> userList = new List<UserEntity>();
            foreach (var user in users)
            {
                var userEntity = MapUserToEntity(user);
                userList.Add(userEntity);
            }

            return userList;
        }

        public async Task UpdateUser(UserEntity userEntity)
        {
            User user = await _context.Users.FindAsync(userEntity.Id.Value);
            user.PasswordHash = userEntity.PasswordHash.Value;
            user.IsActive = userEntity.IsActive;
            user.Salt = userEntity.Salt.Value;
            await _context.SaveChangesAsync();
        }

        public async Task<UserEntity> AddAsync(UserEntity userEntity)
        {
            var user = MapToModel(userEntity);
            var userResult = await _context.Users.AddAsync(user);
            //await _context.SaveChangesAsync();

            return MapUserToEntity(userResult.Entity);
        }

        public void SyncDomainEntityWithDatabase(UserEntity userEntity)
        {
            var addressModel = _context.Users.Local.FirstOrDefault(p => p.UserName == userEntity.UserName.Value);
            if (addressModel != null)
            {
                userEntity.Id = UserEntity.SetUserId(addressModel.Id);
            }
        }

        private UserEntity MapUserToEntity(User user)
        {
            UserEntity userEntity = UserEntity.FromPrimitves(
                        user.Id,
                        user.UserName,
                        user.PasswordHash,
                        user.Salt,
                        user.IsActive,
                        user.CreatedAt,
                        user.CreatedBy,
                        user.UpdatedAt,
                        user.UpdatedBy,
                        user.DeletedAt);


            return userEntity;
        }

        private User MapToModel(UserEntity userEntity)
        {
            return new User
            {
                UserName = userEntity.UserName.Value,
                PasswordHash = userEntity.PasswordHash.Value,
                Salt = userEntity.Salt.Value,
                IsActive = userEntity.IsActive,
                CreatedAt = userEntity.AuditInfo.CreatedAt,
                CreatedBy = userEntity.AuditInfo.CreatedBy,
                UpdatedAt = userEntity.AuditInfo.UpdatedAt,
                UpdatedBy = userEntity.AuditInfo.UpdatedBy,
                DeletedAt = userEntity.AuditInfo.DeletedAt,
            };
        }
    }
}
