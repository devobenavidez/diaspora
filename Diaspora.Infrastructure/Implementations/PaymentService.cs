using Diaspora.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stripe;

namespace Diaspora.Infrastructure.Implementations
{
    public class PaymentService : IPaymentService
    {

        public PaymentService(string apiKey)
        {
            StripeConfiguration.ApiKey = apiKey;
        }

        public async Task<string> ProcessPaymentAsync(decimal amount, string currency, string source, string description)
        {
            var options = new PaymentIntentCreateOptions
            {
                Amount = (long)(amount * 100),
                Currency = currency,
                PaymentMethod = source,
                PaymentMethodTypes = new List<string> { "card" },
                ConfirmationMethod = "manual",
                Confirm = true,
                ReturnUrl = "https://f7d4-2800-e2-7080-1881-65f6-6f72-da96-17cd.ngrok-free.app/payment-success",
                Description = description
            };

            var service = new PaymentIntentService();

            try
            {
                PaymentIntent paymentIntent = await service.CreateAsync(options);
                return paymentIntent.Id;
            }
            catch (StripeException ex)
            {
                // Manejar errores de Stripe
                throw new Exception("Error processing payment with Stripe", ex);
            }
        }
    }
}
