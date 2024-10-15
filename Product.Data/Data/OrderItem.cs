using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Data.Data
{
    public class OrderItem
    {
        public decimal Price { get; set; }

        public int quntity { get; set; }
        public ProductItem ItemOrderd { get; set; }
        public Guid OrderID { get; set; }
    }
}
