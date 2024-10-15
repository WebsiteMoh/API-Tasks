using Product.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Product.Repository.Specification
{
    public class OrderWithitemSpecification : BaseSpecification<Order>
    {
        public OrderWithitemSpecification(String buyerEmail) : base(Order=>Order.BuyerEmail==buyerEmail)
        {
            AddInclude(Order => Order.DeliveryMethod);
            AddInclude(Order => Order.OrderItems);
            OrderByExper(x=>x.OrderDate);

        }
        public OrderWithitemSpecification(Guid id) : base(Order => Order.ID == id)
        {
            AddInclude(Order => Order.DeliveryMethod);
            AddInclude(Order => Order.OrderItems);

        }
    }
}
