using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booth.Infrastructure.DataBase.Configuration.Product
{
    public class ProductConfiguration : IEntityTypeConfiguration<Domain.ProductManagement.Product>
    {
        public void Configure(EntityTypeBuilder<Domain.ProductManagement.Product> builder)
        {
            builder.OwnsOne(product => product.Photo);
            builder.OwnsOne(product => product.ProductSupplier);

            builder.ToTable(nameof(Domain.ProductManagement.Product));
        }
    }
}
