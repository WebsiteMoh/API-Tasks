using Product.Data.Data;
using Product.Repository.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Repository.Interfaces
{
    public interface IProduct
    {
        Task<List<Products>> GetallProducts();
        Task<List<Products>> GetallProducts(Ispecification<Products> specs);

        IEnumerable<ProductBrand> GetallBrands();
        IEnumerable<ProductType> GetallTypes();
        Task<List<Products>> GetProductByID(int ID);

        Task<List<Delivery>> GetDeliverytByID(int ID);
        Task<List<Delivery>> GetDelivery();

    }
}
