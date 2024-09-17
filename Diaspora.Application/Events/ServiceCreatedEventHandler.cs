using Diaspora.Domain.Abstractions;
using Diaspora.Domain.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Application.Events
{
    public class ServiceCreatedEventHandler : INotificationHandler<ServiceCreatedEvent>
    {
        private readonly IEmailService _emailService;

        public ServiceCreatedEventHandler(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task Handle(ServiceCreatedEvent notification, CancellationToken cancellationToken)
        {
            string subject = "Nuevo servicio creado con éxito";
            string message = $"Se ha creado un nuevo servicio con ID {notification.ServiceId} y el número de pago es {notification.PaymentId}.";

            await _emailService.SendEmailAsync(notification.Email, subject, message);
        }
    }
}
