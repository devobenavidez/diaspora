using Diaspora.Domain.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Entities.ServiceType
{
    public class CargoType
    {
        public CargoTypeId Id { get; set; }

        public CargoTypeDescription Description { get; set; } = null!;

        public bool? IsActive { get; set; }

        public AuditInfo AuditInfo { get; set; }

        private CargoType(CargoTypeId id, CargoTypeDescription description, bool? isActive, AuditInfo auditInfo)
        {
            Id = id;
            Description = description;
            IsActive = isActive;
            AuditInfo = auditInfo;
        }

        private CargoType(CargoTypeDescription description, bool? isActive, AuditInfo auditInfo)
        {
            Description = description;
            IsActive = isActive;
            AuditInfo = auditInfo;
        }

        public static CargoType Create(string description, bool isActive, DateTime createdAt, int createdBy)
        {
            var serviceTypeDescription = CargoTypeDescription.Create(description);
            var auditInfo = AuditInfo.Create(createdAt, createdBy, createdAt, createdBy);
            return new CargoType(serviceTypeDescription, isActive, auditInfo);
        }

        public static CargoType FromPrimitives(int id, string description, bool isActive, DateTime createdAt, int createdBy, DateTime updatedAt, int updatedBy)
        {
            var serviceTypeId = new CargoTypeId(id);
            var serviceTypeDescription = CargoTypeDescription.Create(description);
            var auditInfo = AuditInfo.Create(createdAt, createdBy, updatedAt, updatedBy);
            return new CargoType(serviceTypeId, serviceTypeDescription, isActive, auditInfo);
        }
    }
}
