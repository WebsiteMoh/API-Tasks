using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Repository.Basket
{
    public class BasketItem
    {
       public int ID { get; set; }
        public int ProductID { get; set; }

        public int ProductType { get; set; }
        public int ProduccBrand { get; set; }
        public String ImgURL { get; set; }
        public String Description { get; set; }
        public float Price { get; set; }
        public int Quentity { get; set; }



    }
}
