using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Data.Data.Identity
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }    
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
