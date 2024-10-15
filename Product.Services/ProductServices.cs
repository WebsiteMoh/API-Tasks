using AutoMapper;
using Product.Data.Data;
using Product.Repository.Interfaces;
using Product.Repository.Specification;
using Product.Services.DTO;
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
        private readonly IMapper _Mapper;

        public ProductServices(IProduct context,IMapper Mapper) {
            _context = context;
            _Mapper = Mapper;
        }
        public IEnumerable<ProductBrand> GetallBrands()
        {
            return _context.GetallBrands().ToList();
        }

        public async Task<PaginatedResultDTO<ProductModel>> GetallProductsAsync(ProductSpecification input)
        {
            var specs = new ProductwithSpecification(input);

            var products= await _context.GetallProducts(specs);
            var mappedProducts = _Mapper.Map<List<ProductModel>>(products);
            return new PaginatedResultDTO<ProductModel>(input.PageIndex, input.PageSize,products.Count,mappedProducts);
        }

        public IEnumerable<ProductType> GetallTypes()
        {
            return _context.GetallTypes().ToList();
        }
     public async Task<List<ProductModel>> GetProductByID(int ID)
        {
            var products =await _context.GetProductByID(ID);
            var mappedProducts = _Mapper.Map<List<ProductModel>>(products);

            return mappedProducts;
        }
    }
}
