using Product.Data.Context;
using Product.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Repository.Interfaces
{
    public class ProductRep : IProduct
    {
        private readonly ProductDBcontext _context;
        public ProductRep(ProductDBcontext context) {
            _context = context;
        }

        public IEnumerable<ProductBrand> GetallBrands()
        {
            return _context.ProductsBrand.ToList();
        }

        public IEnumerable<Products> GetallProducts()
        {
            return _context.Products.ToList();
        }

        public IEnumerable<ProductType> GetallTypes()
        {
            return _context.ProductsType.ToList();
        }
    }
}
