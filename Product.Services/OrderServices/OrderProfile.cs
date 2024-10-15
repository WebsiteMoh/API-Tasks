using AutoMapper;
using Product.Data.Data;
using Product.Services.OrderServices.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Services.OrderServices
{
    public class OrderProfile : Profile
    {
        public OrderProfile() {
            CreateMap<ShippingAddress, AddressDTO>().ReverseMap();
            CreateMap<Order,OrderDTO>().ReverseMap();
            CreateMap<OrderItem,OrderItemDTO>().ReverseMap();

        }

    }
}
