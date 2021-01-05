using Booth.Domain.OrderManagement;

namespace Booth.Application.Commands.Order.Models
{
    public class OrderItemDto
    {
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
