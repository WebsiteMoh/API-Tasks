using Microsoft.EntityFrameworkCore;
using Product.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Data.Context
{
    public class ProductDBcontext : DbContext
    {
        public ProductDBcontext()
        {

        }
        public ProductDBcontext(DbContextOptions<ProductDBcontext> options) : base(options)
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //   optionsBuilder.UseSqlServer("");
        //}

        public DbSet<Products> Products { get; set; }
        public DbSet<ProductType> ProductsType { get; set; }
        public DbSet<ProductBrand> ProductsBrand { get; set; }



    }
}
