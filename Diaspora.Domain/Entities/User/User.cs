namespace Diaspora.Domain.Entities.User
{
    using Diaspora.Domain.Abstractions;
    using Diaspora.Domain.Shared;
    using System;

    public class User
    {
        public UserId Id { get; private set; }

        public UserName UserName { get; private set; }

        public PasswordHash PasswordHash { get; private set; }

        public bool IsActive { get; private set; }

        public AuditInfo AuditInfo { get; private set; }

        public Salt Salt { get; private set; }

        private User(UserId id, UserName userName, PasswordHash passwordHash, bool isActive, AuditInfo auditInfo, byte[] salt)
        {
            Id = id;
            UserName = userName;
            PasswordHash = passwordHash;
            IsActive = isActive;
            AuditInfo = auditInfo;
            Salt = Salt.FromBytes(salt);
        }

        private User(UserName userName, PasswordHash passwordHash, bool isActive, AuditInfo auditInfo, byte[] salt)
        {
            UserName = userName;
            PasswordHash = passwordHash;
            IsActive = isActive;
            AuditInfo = auditInfo;
            Salt = Salt.FromBytes(salt);
        }

        public static User Create(string userName, string passwordHash, int createdBy, DateTime createdAt, byte[] salt)
        {
            var userNameVo = UserName.Create(userName);
            var passwordHashVo = PasswordHash.Create(passwordHash);
            var auditInfo = AuditInfo.Create(createdAt, createdBy, createdAt, createdBy);
            return new User(userNameVo, passwordHashVo, true, auditInfo, salt);
        }

        public void SetId(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("User ID must be a positive integer.", nameof(id));
            }

            Id = new UserId(id);
        }

        public void UpdatePassword(int updatedBy)
        {
            AuditInfo = AuditInfo.Create(AuditInfo.CreatedAt, AuditInfo.CreatedBy, DateTime.Now, updatedBy);
        }

        public void Deactivate(int updatedBy)
        {
            IsActive = false;
            AuditInfo = AuditInfo.Create(AuditInfo.CreatedAt, AuditInfo.CreatedBy, DateTime.Now, updatedBy, DateTime.Now);
        }

        public void Activate(int updatedBy)
        {
            IsActive = true;
            AuditInfo = AuditInfo.Create(AuditInfo.CreatedAt, AuditInfo.CreatedBy, DateTime.Now, updatedBy);
        }

        public void UpdateUserName(string newUserName)
        {
            UserName = UserName.Create(newUserName);
            AuditInfo = AuditInfo.Create(AuditInfo.CreatedAt, AuditInfo.CreatedBy, DateTime.Now, AuditInfo.UpdatedBy);
        }

        public void SetPassword(string password, IHashingService hashingService, byte[] salt)
        {
            var passwordHashed = hashingService.HashPassword(password, salt);
            PasswordHash = PasswordHash.Create(passwordHashed);
            Salt = Salt.FromBytes(salt);
        }

        public bool VerifyPassword(string password, IHashingService hashingService)
        {
            var passwordHash = PasswordHash.Value;
            return hashingService.VerifyPassword(passwordHash, password, Salt.Value);
        }

        public void Delete(int deletedBy)
        {
            AuditInfo = AuditInfo.Create(AuditInfo.CreatedAt, AuditInfo.CreatedBy, AuditInfo.UpdatedAt, deletedBy, DateTime.Now);
        }

        public static User FromPrimitves(int id, string userName, string passwordHash, byte[] salt, bool isActive, DateTime createdAt, int createdBy, DateTime updatedAt, int updatedBy, DateTime? deletedAt)
        {
            var idVo = new UserId(id);
            var userNameVo = UserName.Create(userName);
            var passwordHashVo = PasswordHash.Create(passwordHash);
            var auditInfo = AuditInfo.Create(createdAt, createdBy, updatedAt, updatedBy, deletedAt);

            return new User(idVo, userNameVo, passwordHashVo, isActive, auditInfo, salt);
        }
    }
}
