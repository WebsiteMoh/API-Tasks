using Product.Repository.BasketRep;
using Product.Repository.Interfaces;
using Product.Repository.Specification;
using Product.Services.Basket;
using Product.Services.OrderServices;
using Product.Services.OrderServices.DTO;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Services.Payment
{
    public class PaymentService : IpaymentServices
    {
        private readonly IProduct _product;
        private readonly IbasketRep _basket;
        private readonly IOrderService _order;

        public PaymentService(IProduct product,IbasketRep basket,IOrderService order) {
        _product = product;
            _basket = basket;
            _order = order;
        }
        public async Task<CustomerBasketDTO> CreateorUpdatePaymentIntent(CustomerBasketDTO input)
        {
            StripeConfiguration.ApiKey = "sk_test_51OBhk9Hrt7hZJgrz1eWWQ7qAvm1Vw4wdlCXkJlgI0qgqHzuD769NDbUJYnXlZroLD0PZ7bJLOWFjI2DzanDt96f400nIFD1rki";
        if(input is null) 
                throw new Exception("Basket is Empty");
            var deliveryMethod = await _product.GetDeliverytByID(input.DeliveryMethodID.Value);
            decimal ShippingPrice = (decimal)deliveryMethod[0].Price;
            foreach(var item in input.basketItems)
            {
                var product = await _product.GetProductByID(item.ID);
                if (item.Price != product[0].Price)
                    item.Price = product[0].Price;
                var service = new PaymentIntentService();
                PaymentIntent paymentIntent;
                if (String.IsNullOrEmpty(input.paymentIntentID))
                {
                    var options = new PaymentIntentCreateOptions
                    {
                        Amount = (long)input.basketItems.Sum(item => item.Quentity * (item.Price * 100) + (long)(ShippingPrice * 100)),
                        Currency="usd",
                        PaymentMethodTypes=new List<string> { "card" }
                        
                    };
                    paymentIntent = await service.CreateAsync(options);
                    input.paymentIntentID = paymentIntent.Id;
                    input.ClientSecret = paymentIntent.ClientSecret;

                }
                else
                {
                    var options = new PaymentIntentUpdateOptions
                    {
                        Amount = (long)input.basketItems.Sum(item => item.Quentity * (item.Price * 100) + (long)(ShippingPrice * 100)),
                     
                    };
                    await service.UpdateAsync(input.paymentIntentID, options);

                }
            }
            await _basket.UpdateBasketAsync(input);

            
        }

        public async Task<OrderDetialsDTO> UpdateOrderPaymentfAILED(string paymentIntentID)
        {
            var specs = new OrderwithPaymentIntenetSpecficication(paymentIntentID);
        var order=await _order.g
        }

        public Task<OrderDetialsDTO> UpdateOrderPaymentSucceded(string paymentIntentID)
        {
            throw new NotImplementedException();
        }
    }
}
