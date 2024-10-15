using Product.Data.Data.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Data.Data
{
    public class Order : BaseEntity<Guid>
    {
        public String BuyerEmail { get; set; }
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        public ShippingAddress ShippingAddresss { get; set; }
        public Delivery DeliveryMethod { get; set; }
        public int? DeliveryID { get; set; }
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Placed;
        public Orderpayment Orderpayment { get; set; } = Orderpayment.Pending;
        public IReadOnlyList<OrderItem> OrderItems { get; set; }
        public double Subtotal { get; set; }
        public String? BasketID { get; set; }
        public string paymentIntentID { get; set; }

    }
}
