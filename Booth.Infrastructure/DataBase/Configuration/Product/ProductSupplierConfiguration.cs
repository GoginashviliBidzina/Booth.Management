using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booth.Infrastructure.DataBase.Configuration
{
    public class ProductSupplierConfiguration : IEntityTypeConfiguration<Domain.ProductManagement.ProductSupplier>
    {
        public void Configure(EntityTypeBuilder<Domain.ProductManagement.ProductSupplier> builder)
        {
            builder.OwnsOne(supplier => supplier.Phone);
            builder.OwnsOne(supplier => supplier.Address);
            builder.OwnsMany(supplier => supplier.Products);

            builder.ToTable(nameof(Domain.ProductManagement.ProductSupplier));
        }
    }
}
