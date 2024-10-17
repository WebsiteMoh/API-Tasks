﻿using AutoMapper;
using Product.Data.Data;
using Product.Repository.Interfaces;
using Product.Repository.Specification;
using Product.Services.Basket;
using Product.Services.OrderServices.DTO;
using Product.Services.Payment;
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
        private readonly IpaymentServices _payment;


        public OrderServices(IBasketService context,IProduct products,IMapper Mapper,IOrderService order,IpaymentServices payment) {
            _context = context;
            _Product = products;
            _Imapper = Mapper;
            _order = order;
            _payment = payment;
        }

        public Task<OrderDetialsDTO> createOrderDetials(OrderDTO input)
        {
            throw new NotImplementedException();
        }

        public async Task<OrderDetialsDTO> GetAllOrdersForUser(string buyerEmail)
        {
            var specs = new OrderWithitemSpecification(buyerEmail);
            var output = await _Product.GetallOrder(specs: specs);
            var MappedOutput = _Imapper.Map<OrderDetialsDTO>(output);
            return MappedOutput;
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
               
            }
            #region get deilvery method
            var deilveryMethod = await _Product.GetDeliverytByID(input.DeilveryMethodID);
            if (deilveryMethod is null)
                throw new Exception("");

            #endregion
            #region Calculate Subtotal 
            var subtotals = orderItems.Sum(item => item.quntity * item.Price);
            #endregion
            #region To do =>Payment
            var specs = new OrderwithPaymentIntenetSpecficication(basket.paymentIntentID);
            var exisitingOrder = await _Product.GetallOrder(specs);
            if (exisitingOrder is null)
                await _payment.CreateorUpdatePaymentIntent(basket);

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
                Subtotal = (double)subtotals,
                paymentIntentID = basket.paymentIntentID
            };
            var MappedOrder = _Imapper.Map<OrderDetialsDTO>(order);
            var MappedOrder2 = _Imapper.Map<OrderDTO>(order);

            await _order.createOrderDetials(MappedOrder2);
            return MappedOrder;
            #endregion



        }

        public async Task<OrderDetialsDTO> GetOrderIdAsync(Guid id)
        {
            var specs = new OrderWithitemSpecification(id);
           var output= await _Product.GetallOrder(specs);
            var MappedOutput=_Imapper.Map<OrderDetialsDTO>(output);
            return MappedOutput;
        }
    }
}
