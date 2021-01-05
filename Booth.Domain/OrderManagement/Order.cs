using System.Linq;
using Booth.Shared;
using System.Collections.Generic;
using Booth.Domain.OrderManagement.Events;

namespace Booth.Domain.OrderManagement
{
    public class Order : AggregateRoot
    {
        public int BoothId { get; set; }

        public decimal TotalAmount { get; private set; }

        public OrderStatus OrderStatus { get; private set; }

        public ICollection<OrderItem> OrderItems { get; private set; }

        public Order()
        {

        }

        public Order(int boothId,
                     decimal totalAmount,
                     OrderStatus orderStatus,
                     ICollection<OrderItem> orderItems)
        {
            BoothId = boothId;
            TotalAmount = totalAmount;
            OrderItems = orderItems;
            OrderStatus = orderStatus;

            Raise(new OrderPlacedEvent(this));
        }
    }
}
