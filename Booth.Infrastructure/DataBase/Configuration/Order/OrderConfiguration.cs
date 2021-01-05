using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booth.Infrastructure.DataBase.Configuration.Order
{
    class OrderConfiguration : IEntityTypeConfiguration<Domain.OrderManagement.Order>
    {
        public void Configure(EntityTypeBuilder<Domain.OrderManagement.Order> builder)
        {
            builder.HasMany(order => order.OrderItems);

            builder.ToTable(nameof(Domain.OrderManagement.Order));
        }
    }
}
