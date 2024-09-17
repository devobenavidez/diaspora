using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Abstractions
{
    public interface IPaymentService
    {
        Task<string> ProcessPaymentAsync(decimal amount, string currency, string source, string description);
    }
}
