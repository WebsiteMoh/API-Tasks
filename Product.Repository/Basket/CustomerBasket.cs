using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Repository.Basket
{
    public class CustomerBasket
    {
        public int ID { get; set; }
        public int? DeliveryMethodID { get; set; }
        public decimal ShippingPrice { get; set; }
        public List<BasketItem> basketItems { get; set; } = new List<BasketItem>();
        public string? paymentIntentID { get; set; }
        public string? ClientSecret { get; set; }
    }
}
