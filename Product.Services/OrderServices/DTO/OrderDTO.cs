using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Services.OrderServices.DTO
{
    public class OrderDTO
    {
        public string BasketID { get; set; }
        public string BuyerEmail { get; set;}
        public int DeilveryMethodID { get; set; }
        public AddressDTO ShippingAddress { get; set; }


    }
}
