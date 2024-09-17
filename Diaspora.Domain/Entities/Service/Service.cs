using Diaspora.Domain.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Entities.Service
{
    public class Service
    {
        public ServiceId Id { get; set; }

        public CityId OriginCity { get; set; }

        public CityId DestinationCity { get; set; }

        public CourierId CourierId { get; set; }

        public UserId SenderId { get; set; }

        public UserId ReceiverId { get; set; }

        public GenericDate PickupDate { get; set; }

        public bool IsActive { get; set; }
        public string PaymentId { get; set; }
        public int ServiceTypeId { get; set; }
        public AuditInfo AuditInfo { get; set; }

        private Service(ServiceId id, CityId originCity, CityId destinationCity, CourierId courierId, UserId senderId, UserId receiverId, GenericDate pickupDate, bool isActive, AuditInfo auditInfo, string paymentId, int serviceTypeId)
        {
            Id = id;
            OriginCity = originCity;
            DestinationCity = destinationCity;
            CourierId = courierId;
            SenderId = senderId;
            ReceiverId = receiverId;
            PickupDate = pickupDate;
            IsActive = isActive;
            AuditInfo = auditInfo;
            PaymentId = paymentId;
            ServiceTypeId = serviceTypeId;
        }

        private Service(CityId originCity, CityId destinationCity, CourierId courierId, UserId senderId, UserId receiverId, GenericDate pickupDate, bool isActive, AuditInfo auditInfo, string paymentId, int serviceTypeId)
        {
            OriginCity = originCity;
            DestinationCity = destinationCity;
            CourierId = courierId;
            SenderId = senderId;
            ReceiverId = receiverId;
            PickupDate = pickupDate;
            IsActive = isActive;
            AuditInfo = auditInfo;
            PaymentId = paymentId;
            ServiceTypeId = serviceTypeId;
        }

        public static Service Create(int originCity, int destinationCity, int courierId, int senderId, int receiverId, DateTime pickupDate, bool isActive, DateTime createdAt, int createdBy, string paymentId, int serviceTypeId)
        {
            var origin = CityId.Create(originCity);
            var destination = CityId.Create(destinationCity);
            var courier = CourierId.Create(courierId);
            var sender = UserId.CreateRequired(senderId);
            var receiver = UserId.CreateRequired(receiverId);
            var date = GenericDate.Create(pickupDate);
            var auditInfo = AuditInfo.Create(createdAt, createdBy, createdAt, createdBy);
            return new Service(origin, destination, courier, sender, receiver, date, isActive, auditInfo, paymentId, serviceTypeId);
        }

        public static Service FromPrimitives(int id, int originCity, int destinationCity, int courierId, int senderId, int receiverId, DateTime pickupDate, bool isActive, string paymentId, int serviceTypeId, DateTime createdAt, int createdBy, DateTime updatedAt, int updatedBy)
        {
            var serviceId = new ServiceId(id);
            var origin = CityId.Create(originCity);
            var destination = CityId.Create(destinationCity);
            var courier = CourierId.Create(courierId);
            var sender = UserId.CreateRequired(senderId);
            var receiver = UserId.CreateRequired(receiverId);
            var date = GenericDate.Create(pickupDate);
            var auditInfo = AuditInfo.Create(createdAt, createdBy, updatedAt, updatedBy);
            return new Service(serviceId, origin, destination, courier, sender, receiver, date, isActive, auditInfo, paymentId, serviceTypeId);
        }

        public static ServiceId SetServiceId(int id)
        {
            return new ServiceId(id);
        }
    }
}
