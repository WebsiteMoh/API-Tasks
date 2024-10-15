using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Repository.Basket;
using Product.Services.Basket;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        public BasketController(IBasketService context) {
            _basketService = context;
        }
        [HttpGet]
        public  async Task<BasketItems> GetBasketItemByID(int ID)
        {
            return await _basketService.GetBasketItemByID(ID);
        }
        [HttpGet]
        public async Task<bool> DeleteBasketAsync(int ID)
        {
            return await _basketService.DeleteBasketAsync(ID);
        }
        [HttpPost]
        public async Task<ActionResult<BasketItems>> UpdateBasketAsync(BasketItems basket)
        {
            if (basket.OrderID == 0)
            {

                basket.OrderID = 1;
            }
            return await _basketService.UpdateBasketAsync(basket);
        }
    }
}
