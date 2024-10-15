using Product.Data.Data;
using Product.Repository.Specification;
using Product.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Services
{
    public interface IproductServices
    {
        Task<PaginatedResultDTO<ProductModel>> GetallProductsAsync(ProductSpecification input);
        IEnumerable<ProductBrand> GetallBrands();
        IEnumerable<ProductType> GetallTypes();
        Task<List<ProductModel>> GetProductByID(int ID);


    }
}
