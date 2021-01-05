using Microsoft.EntityFrameworkCore;
using Booth.Domain.ProductManagement.ReadModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booth.Infrastructure.DataBase.Configuration.Product
{
    public class ProductReadModelConfiguration : IEntityTypeConfiguration<ProductReadModel>
    {
        public void Configure(EntityTypeBuilder<ProductReadModel> builder)
            => builder.ToTable(nameof(ProductReadModel));
    }
}
