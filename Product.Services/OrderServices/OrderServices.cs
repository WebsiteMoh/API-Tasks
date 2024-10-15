using AutoMapper;
using Product.Data.Data;
using Product.Repository.Interfaces;
using Product.Repository.Specification;
using Product.Services.Basket;
using Product.Services.OrderServices.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Services.OrderServices
{
    public class OrderServices : IOrderService
    {
        private readonly IBasketService _context;
        private readonly IProduct _Product;
        private readonly IMapper _Imapper;
        private readonly IOrderService _order;

        public OrderServices(IBasketService context,IProduct products,IMapper Mapper,IOrderService order) {
            _context = context;
            _Product = products;
            _Imapper = Mapper;
            _order = order;
        }
        public Task<OrderDetialsDTO> GetAllOrdersForUser(string buyerEmail)
        {
            var specs = new OrderWithitemSpecification(buyerEmail);

        }

        public async Task<IReadOnlyList<Delivery>> GetDeliveryStatus()
        {
         return await  _Product.GetDelivery();
        }

        public async Task<OrderDetialsDTO> GetOrderDetials(OrderDTO input)
        {
            var basket = await _context.GetBasketItemByID(int.Parse(input.BasketID));
            if (basket is null)
                throw new Exception("Basket not Exist");
            var orderItems = new List<OrderItemDTO>();
            foreach(var basketitem in basket.Items)
            {
                var productItem = await _Product.GetProductByID(basketitem.ProductID);
                if (productItem is null)
                    throw new Exception("${Product with ID : {} NOT EXIST");
                var ItemOrdered = new ProductItem
                {
                    Id = productItem[0].ID,
                    Name = productItem[0].Name,
                    ProductURL = productItem[0].PictureUrl
                };
                var OrderItem = new OrderItem
                {
                    Price = (decimal)productItem[0].Price,
                    quntity = basketitem.Quentity,
                    ItemOrderd = ItemOrdered
                };
                var mappedOrderd = _Imapper.Map<OrderItemDTO>(orderItems);
                orderItems.Add(mappedOrderd);
                #region get deilvery method
                var deilveryMethod= await _Product.GetDeliverytByID(input.DeilveryMethodID);
                if(deilveryMethod is null)
                    throw new Exception("");

                #endregion
                #region Calculate Subtotal 
                var subtotals = orderItems.Sum(item => item.quntity * item.Price);
                #endregion
                #region To do =>Payment

                #endregion
                #region Create Order
                var mapShippingAddress = _Imapper.Map<ShippingAddress>(input.ShippingAddress);
                var mapOrderItems = _Imapper.Map<List<OrderItem>>(orderItems);
                var order = new Order
                {
                    DeliveryID = deilveryMethod[0].ID,
                    ShippingAddresss = mapShippingAddress,
                    BuyerEmail = input.BuyerEmail,
                    OrderItems = mapOrderItems,
                    Subtotal = (double)subtotals
                };
                 
#endregion



            }

        }

        public Task<OrderDetialsDTO> GetOrderIdAsync(Guid id)
        {
            var specs = new OrderWithitemSpecification(id);
        }
    }
}
