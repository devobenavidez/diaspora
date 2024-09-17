using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Application.Payment.DTOs
{
    public class PaymentDto
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string Source { get; set; }
        public string Description { get; set; }
    }
}
