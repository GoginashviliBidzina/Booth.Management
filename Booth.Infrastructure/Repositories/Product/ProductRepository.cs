using System.Threading.Tasks;
using Booth.Infrastructure.Shared;
using Booth.Infrastructure.DataBase;
using Booth.Domain.ProductManagement;
using Booth.Domain.ProductManagement.Repository;

namespace Product.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository<DatabaseContext, Booth.Domain.ProductManagement.Product>, IProductRepository
    {
        DatabaseContext _context;

        public ProductRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        public Task<ProductSupplier> GetProductSupplierByIdAsync(int entityId)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteProductSupplierAsync(int entityId)
        {
            throw new System.NotImplementedException();
        }

        public Task InsertProductSupplierAsync(ProductSupplier supplier)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateProductSupplierAsync(ProductSupplier supplier)
        {
            throw new System.NotImplementedException();
        }
    }
}
