using Product.Repository.Basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Services.Basket
{
    public interface IBasketService
    {
        public Task<BasketItems> GetBasketItemByID(int ID);
        public Task<bool> DeleteBasketAsync(int ID);
        public Task<BasketItems> UpdateBasketAsync(BasketItems basket);
    }
}
