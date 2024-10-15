using Product.Repository.Basket;
using Product.Repository.BasketRep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Services.Basket
{
    public class BasketService : IBasketService
    {
        private readonly IbasketRep _context;
        public BasketService(IbasketRep context) {
        _context = context;
        }
        public async Task<bool> DeleteBasketAsync(int ID)
             =>await _context.DeleteBasketAsync(ID);

        public async Task<BasketItems> GetBasketItemByID(int ID)
        {
            return await _context.GetBasketItemByID(ID);
        }

        public async Task<BasketItems> UpdateBasketAsync(BasketItems basket)
        {
            return await _context.UpdateBasketAsync(basket);
        }
    }
}
