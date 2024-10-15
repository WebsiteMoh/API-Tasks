using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Data.Data;
using Product.Repository.Specification;
using Product.Services;
using Product.Services.DTO;
using WebAPI.Helper;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]

    public class ProductsController : ControllerBase
    {
        private readonly IproductServices _context;
        public ProductsController(IproductServices context) {
        _context = context;
        }
        [HttpGet]
        [Cache(10)]
        public async Task<Product.Services.DTO.PaginatedResultDTO<ProductModel>> GetallProducts([FromQuery] ProductSpecification input) { 
        return await _context.GetallProductsAsync(input);
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
        [HttpGet]

        public async Task<List<ProductModel>> GetProductByID(int ID)
        {
            return await _context.GetProductByID(ID);
        }
    }
}
