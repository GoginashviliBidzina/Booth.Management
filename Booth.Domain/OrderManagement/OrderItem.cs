using Booth.Shared;

namespace Booth.Domain.OrderManagement
{
    public class OrderItem : Entity
    {
        public int? OrderId { get; private set; }

        public Order Order { get; private set; }

        public int ProductId { get; private set; }

        public int Quantity { get; private set; }

        public decimal UnitPrice { get; private set; }

        public PaymentMethod PaymentMethod { get; private set; }

        public OrderItem(int productId,
                         int quantity,
                         decimal unitPrice,
                         PaymentMethod paymentMethod)
        {
            ProductId = productId;
            Quantity = quantity;
            UnitPrice = unitPrice;
            PaymentMethod = PaymentMethod;
        }
    }
}
