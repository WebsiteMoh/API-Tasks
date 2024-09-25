using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Data.Data
{
    public class ProductType : BaseEntity<int>
    {
        public String Name { get; set; }  
    }
}
