using System.Linq;
using Newtonsoft.Json;
using Booth.Infrastructure.DataBase;
using Booth.Domain.OrderManagement.Events;
using Booth.Infrastructure.EventDispatching;
using Booth.Domain.OrderManagement.ReadModels;

namespace Booth.Application.EventHandlers.Order
{
    public class OrderEventHandler : IHandleEvent<OrderPlacedEvent>
    {
        public void Handle(OrderPlacedEvent @event, DatabaseContext db)
        {
            var order = @event.Order;
            var orderItemJson = order.OrderItems?.Any() ?? true ? JsonConvert.SerializeObject(order.OrderItems) :
                                                                  string.Empty;

            var orderStatus = (int)order.OrderStatus;

            var orderReadModel = new OrderReadModel(order.Id,
                                                    orderStatus,
                                                    order.TotalAmount,
                                                    order.BoothId,
                                                    orderItemJson);

            db.Set<OrderReadModel>()
              .Add(orderReadModel);
        }
    }
}
