using Microsoft.EntityFrameworkCore;
using Booth.Infrastructure.DataBase.Configuration;
using Booth.Infrastructure.DataBase.Configuration.Booth;
using Booth.Infrastructure.DataBase.Configuration.Order;
using Booth.Infrastructure.DataBase.Configuration.Product;

namespace Booth.Infrastructure.DataBase
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new ProductSupplierConfiguration());
            builder.ApplyConfiguration(new ProductReadModelConfiguration());

            builder.ApplyConfiguration(new BoothConfiguration());
            builder.ApplyConfiguration(new BoothReadModelConfiguration());

            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new OrderReadModelConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
