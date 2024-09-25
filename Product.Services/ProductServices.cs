using Product.Data.Data;
using Product.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Services
{
    public class ProductServices : IproductServices
    {
        private readonly IProduct _context;
        public ProductServices(IProduct context) {
        _context = context;
        }
        public IEnumerable<ProductBrand> GetallBrands()
        {
            return _context.GetallBrands().ToList();
        }

        public IEnumerable<Products> GetallProducts()
        {
            return _context.GetallProducts().ToList();
        }

        public IEnumerable<ProductType> GetallTypes()
        {
            return _context.GetallTypes().ToList();
        }
    }
}
