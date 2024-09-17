using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Events
{
    public class ServiceCreatedEvent : INotification
    {
        public int ServiceId { get; }
        public string PaymentId { get; }
        public string Email { get; set; }

        public ServiceCreatedEvent(int serviceId, string paymentId, string email)
        {
            ServiceId = serviceId;
            PaymentId = paymentId;
            Email = email;
        }
    }
}
