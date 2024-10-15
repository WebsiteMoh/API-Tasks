using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Data.OrdersConfigurations
{
    public class Configuration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.OwnsOne(x => x.ShippingAddresss, x =>
            {
                x.WithOwner();
            });
            builder.HasMany(Order => Order.OrderItems).WithOne().OnDelete(deleteBehavior: DeleteBehavior.Cascade);
        }
    }
}
