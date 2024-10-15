using Product.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Product.Repository.Specification
{
    public class OrderwithPaymentIntenetSpecficication : BaseSpecification<Order>
    {
        public OrderwithPaymentIntenetSpecficication(string? PaymentIntentId) : base(order=>order.paymentIntentID==PaymentIntentId)
        {
        }
    }
}
