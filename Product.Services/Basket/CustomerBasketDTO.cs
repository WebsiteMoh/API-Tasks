using Product.Repository.Basket;
using Product.Services.BasketDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Services.Basket
{
    public class CustomerBasketDTO
    {
        public int ID { get; set; }
        public int? DeliveryMethodID { get; set; }
        public decimal ShippingPrice { get; set; }
        public List<BasketItemDTO> basketItems { get; set; } = new List<BasketItemDTO>();
        public string? paymentIntentID { get; set; }
        public string? ClientSecret { get; set; }
    }
}
