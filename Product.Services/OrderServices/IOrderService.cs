using Product.Data.Data;
using Product.Services.OrderServices.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Services.OrderServices
{
     public interface IOrderService
    {

        Task<OrderDetialsDTO> createOrderDetials(OrderDTO input);
        Task<OrderDetialsDTO> GetAllOrdersForUser(String buyerEmail);
        Task<OrderDetialsDTO> GetOrderIdAsync(Guid id);
        Task<IReadOnlyList<Delivery>> GetDeliveryStatus(); 

    }
}
