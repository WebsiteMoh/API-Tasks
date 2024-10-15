using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Services.DTO
{
    public class ProductModel
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public float Price { get; set; }
        public String PictureUrl { get; set; }
        public int TypeId { get; set; }
        public int BrandId { get; set; }

    }
}
