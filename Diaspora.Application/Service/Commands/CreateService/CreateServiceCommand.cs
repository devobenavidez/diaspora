using Diaspora.Application.Payment.DTOs;
using Diaspora.Application.Person.DTOs;
using Diaspora.Application.Users.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Application.Services.Commands.CreateService
{
    public class CreateServiceCommand : IRequest<int>
    {
        public int OriginCity { get; set; }
        public int DestinationCity { get; set; }
        public int CourierId { get; set; }
        public PersonDto Sender { get; set; }
        public PersonDto Receiver { get; set; }
        public DateTime PickupDate { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public PaymentDto Payment { get; set; }
        public int ServiceTypeId { get; set; }

    }
}
