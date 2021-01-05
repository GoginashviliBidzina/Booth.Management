namespace Booth.Domain.OrderManagement.ReadModels
{
    public class OrderReadModel
    {
        public int Id { get; set; }

        public int AggregateRootId { get; set; }

        public int BoothId { get; set; }

        public decimal TotalAmount { get; set; }

        public int OrderStatus { get; set; }

        public string OrderItemsJson { get; set; }

        public OrderReadModel(int aggregateRootId,
                              int boothId,
                              decimal totalAmount,
                              int orderStatus,
                              string orderItemsJson)
        {
            AggregateRootId = aggregateRootId;
            BoothId = boothId;
            TotalAmount = totalAmount;
            OrderStatus = orderStatus;
            OrderItemsJson = orderItemsJson;
        }
    }
}
