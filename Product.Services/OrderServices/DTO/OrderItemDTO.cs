using Product.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Services.OrderServices.DTO
{
    
    public class OrderItemDTO
    {
        public decimal Price { get; set; }

        public int quntity { get; set; }
        public Products ItemOrderd { get; set; }
        public Guid OrderID { get; set; }
    }
}
