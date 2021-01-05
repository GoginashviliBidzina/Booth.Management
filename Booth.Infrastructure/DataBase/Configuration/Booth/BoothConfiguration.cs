using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booth.Infrastructure.DataBase.Configuration.Booth
{
    public class BoothConfiguration : IEntityTypeConfiguration<Domain.BoothManagement.Booth>
    {
        public void Configure(EntityTypeBuilder<Domain.BoothManagement.Booth> builder)
        {
            builder.HasMany(booth => booth.BoothStaff);

            builder.ToTable(nameof(Domain.BoothManagement.Booth));
        }
    }
}
