using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Repository.Basket;
using Product.Services.OrderServices.DTO;
using Product.Services.Payment;
using Stripe;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        const string endpointSecret = "whsec_d1ca05d42375183dbe0b8a6bb30ebaf093a216bc4280418a42512eb6ba8d7c22";

        private readonly IpaymentServices _Payment;
        public PaymentController(IpaymentServices Payment) { 
        _Payment= Payment;
        }
        [HttpPost]
        public async Task<BasketItems> CreateorUpdatePaymentIntent(BasketItems input)
        {
            return await _Payment.CreateorUpdatePaymentIntent(input);
        }
        [HttpPost("webhook")]
        public async Task<IActionResult> Webhook()
        {
            PaymentIntent paymentIntent;

            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
            try
            {
                var stripeEvent = EventUtility.ConstructEvent(json,
                    Request.Headers["Stripe-Signature"], endpointSecret);

                // Handle the event
                if (stripeEvent.Type == "subscription_schedule.canceled")
                {
                    paymentIntent = stripeEvent.Data.Object as PaymentIntent;
               var order=     await _Payment.UpdateOrderPaymentfAILED(paymentIntent.Id);
                }
                else if (stripeEvent.Type == "payment.payment_succeeded")
                {
                    paymentIntent = stripeEvent.Data.Object as PaymentIntent;
                    var order = await _Payment.UpdateOrderPaymentSucceded(paymentIntent.Id);
                }
                else if (stripeEvent.Type == "payment_intent.created")
                {
                }
                // ... handle other event types
                else
                {
                    Console.WriteLine("Unhandled event type: {0}", stripeEvent.Type);
                }

                return Ok();
            }
            catch (StripeException e)
            {
                return BadRequest();
            }
        }
    

    


    }
}
