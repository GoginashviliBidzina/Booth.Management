using Microsoft.EntityFrameworkCore;
using Booth.Infrastructure.DataBase;
using Booth.Application.Infrastructure;
using Booth.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Product.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Booth.Domain.ProductManagement.Repository;
using Booth.Domain.OrderManagement.Repositories;

namespace Booth.DI
{
    public class DependencyResolver
    {
        private IConfiguration _configuration { get; }

        public DependencyResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IServiceCollection Resolve(IServiceCollection services)
        {
            services ??= new ServiceCollection();

            var connectionString = _configuration.GetConnectionString("BoothDbContext");

            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<CommandExecutor>();
            services.AddScoped<QueryExecutor>();
            services.AddScoped<UnitOfWork>();

            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}
