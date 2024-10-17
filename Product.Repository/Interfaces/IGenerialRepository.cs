using Product.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Repository.Interfaces
{
    public interface IProduct
    {
        IEnumerable<Products> GetallProducts();
        IEnumerable<ProductBrand> GetallBrands();
        IEnumerable<ProductType> GetallTypes();

        Task<List<Delivery>> GetDeliverytByID(int ID);
        Task<List<Delivery>> GetDelivery();

    }
}
