using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Product.Data.Data.Identity;

namespace Product.Data.Context
{
    public class AppUserDBContext : IdentityDbContext<AppUser>
    {
        public AppUserDBContext(DbContextOptions<AppUserDBContext> options) : base(options) { }
    }
}
