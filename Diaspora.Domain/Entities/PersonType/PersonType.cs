using Diaspora.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Entities.PersonType
{
    public class PersonType
    {
        public PersonTypeId Id { get; private set; }
        public PersonTypeDescription Description { get; private set; }
        public bool IsActive { get; private set; }
        public AuditInfo AuditInfo { get; private set; }

        private PersonType(PersonTypeId id, PersonTypeDescription description, bool isActive, AuditInfo auditInfo)
        {
            Id = id;
            Description = description;
            IsActive = isActive;
            AuditInfo = auditInfo;
        }

        private PersonType(PersonTypeDescription description, bool isActive, AuditInfo auditInfo)
        {
            Description = description;
            IsActive = isActive;
            AuditInfo = auditInfo;
        }

        public static PersonType Create(string description, int createdBy, DateTime createdAt)
        {
            var descriptionVo = PersonTypeDescription.Create(description);
            var auditInfo = AuditInfo.Create(createdAt, createdBy, createdAt, createdBy);
            return new PersonType(descriptionVo, true, auditInfo);
        }

        public void SetId(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Person Type ID must be a positive integer.", nameof(id));
            }

            Id = new PersonTypeId(id);
        }

        public void UpdateDescription(string newDescription, int updatedBy)
        {
            Description = PersonTypeDescription.Create(newDescription);
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

        public void Delete(int deletedBy)
        {
            AuditInfo = AuditInfo.Create(AuditInfo.CreatedAt, AuditInfo.CreatedBy, AuditInfo.UpdatedAt, deletedBy, DateTime.Now);
        }

        public static PersonType FromPrimitives(int id, string description, bool isActive, DateTime createdAt, int createdBy, DateTime updatedAt, int updatedBy, DateTime? deletedAt)
        {
            var idVo = new PersonTypeId(id);
            var descriptionVo = PersonTypeDescription.Create(description);
            var auditInfo = AuditInfo.Create(createdAt, createdBy, updatedAt, updatedBy, deletedAt);

            return new PersonType(idVo, descriptionVo, isActive, auditInfo);
        }
    }

}
