using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Repository.Basket
{
    public class BasketItems
    {
       public int OrderID { get; set; }
       public List<BasketItem> Items { get; set;}=new List<BasketItem>();
       public String Location { get; set; }
        public string paymentIntentID { get; set; }

    }

}
