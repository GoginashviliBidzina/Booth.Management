using Booth.Shared;
using System.Threading.Tasks;

namespace Booth.Domain.ProductManagement.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<ProductSupplier> GetProductSupplierByIdAsync(int id);
    }
}
