using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Diaspora.Api.Controllers
{
    [Route("payment-success")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        [HttpGet]
        public IActionResult PaymentSuccess([FromQuery] string payment_intent, [FromQuery] string payment_intent_client_secret)
        {
            // Aquí puedes manejar la lógica de tu aplicación una vez que el pago ha sido exitoso
            return Ok($"Payment successful! Intent ID: {payment_intent}");
        }
    }
}
