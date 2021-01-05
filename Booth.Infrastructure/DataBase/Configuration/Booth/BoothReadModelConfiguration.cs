using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booth.Infrastructure.DataBase.Configuration.Booth
{
    public class BoothReadModelConfiguration : IEntityTypeConfiguration<Domain.BoothManagement.ReadModels.BoothReadModel>
    {
        public void Configure(EntityTypeBuilder<Domain.BoothManagement.ReadModels.BoothReadModel> builder)
            => builder.ToTable(nameof(Domain.BoothManagement.ReadModels.BoothReadModel));

    }
}
