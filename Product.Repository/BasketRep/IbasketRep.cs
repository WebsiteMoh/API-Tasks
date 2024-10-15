using Product.Repository.Basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Repository.BasketRep
{
    public interface IbasketRep
    {
        public Task<BasketItems> GetBasketItemByID(int ID);
        public Task<bool> DeleteBasketAsync(int ID);
        public Task<BasketItems> UpdateBasketAsync(BasketItems basket);



    }
}
