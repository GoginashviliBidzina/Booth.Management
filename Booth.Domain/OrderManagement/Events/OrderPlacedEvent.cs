using Booth.Shared;

namespace Booth.Domain.OrderManagement.Events
{
    public class OrderPlacedEvent : DomainEvent
    {
        public Order Order { get; private set; }

        public OrderPlacedEvent(Order order)
        {
            Order = order;
        }
    }
}
