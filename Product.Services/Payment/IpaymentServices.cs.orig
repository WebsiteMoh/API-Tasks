using Product.Repository.Basket;
using Product.Services.Basket;
using Product.Services.OrderServices.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Services.Payment
{
    public interface IpaymentServices
    {
        Task<BasketItems> CreateorUpdatePaymentIntent(BasketItems input);
        Task<OrderDetialsDTO> UpdateOrderPaymentSucceded(String paymentIntentID);
        Task<OrderDetialsDTO> UpdateOrderPaymentfAILED(String paymentIntentID);


    }
}
