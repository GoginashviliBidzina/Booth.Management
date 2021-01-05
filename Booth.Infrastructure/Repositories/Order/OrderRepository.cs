using Booth.Infrastructure.Shared;
using Booth.Domain.OrderManagement;
using Booth.Infrastructure.DataBase;
using Booth.Domain.OrderManagement.Repositories;

namespace Booth.Infrastructure.Repositories
{
    public class OrderRepository : BaseRepository<DatabaseContext, Order>, IOrderRepository
    {
        DatabaseContext _context;

        public OrderRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }
    }
}
