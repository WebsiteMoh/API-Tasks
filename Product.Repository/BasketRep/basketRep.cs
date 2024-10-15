using Product.Repository.Basket;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Product.Repository.BasketRep
{
    public class basketRep : IbasketRep
    {
        private readonly IDatabase _database;
        public basketRep(IConnectionMultiplexer database)
        {
            _database = database.GetDatabase();

        }
        public async Task<bool> DeleteBasketAsync(int ID)
        {
            return await _database.KeyDeleteAsync(ID.ToString());
        }

        public async Task<BasketItems> GetBasketItemByID(int ID)
        {
            var basket = await _database.StringGetAsync(ID.ToString());
            return JsonSerializer.Deserialize<BasketItems>(basket);
        }

        public async Task<BasketItems> UpdateBasketAsync(BasketItems basket)
        {
            var IsCreated= _database.StringSetAsync(basket.OrderID.ToString(), JsonSerializer.Serialize(basket), TimeSpan.FromHours(12));
            return await GetBasketItemByID(basket.OrderID);
    }
    }
}
