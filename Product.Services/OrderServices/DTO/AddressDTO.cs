using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Services.OrderServices.DTO
{
    public class AddressDTO
    {
        public String Street { get; set; }
        public String Block { get; set; }
        public String Building { get; set; }
        public String Flat { get; set; }
    }
}
