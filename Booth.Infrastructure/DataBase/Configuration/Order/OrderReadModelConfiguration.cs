using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booth.Infrastructure.DataBase.Configuration.Order
{
    public class OrderReadModelConfiguration : IEntityTypeConfiguration<Domain.OrderManagement.ReadModels.OrderReadModel>
    {
        public void Configure(EntityTypeBuilder<Domain.OrderManagement.ReadModels.OrderReadModel> builder)
        => builder.ToTable(nameof(Domain.OrderManagement.ReadModels.OrderReadModel));
    }
}
