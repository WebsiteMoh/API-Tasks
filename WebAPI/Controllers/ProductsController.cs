using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Data.Data;
using Product.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IproductServices _context;
        public ProductsController(IproductServices context) {
        _context = context;
        }
        [HttpGet]
        public IEnumerable<Products> GetallProducts() { 
        return _context.GetallProducts();
        }
        [HttpGet]

        public IEnumerable<ProductBrand> GetallBrands()
        {
            return _context.GetallBrands();
        }
        [HttpGet]

        public IEnumerable<ProductType> GetallTypes()
        {
            return _context.GetallTypes();
        }
    }
}
