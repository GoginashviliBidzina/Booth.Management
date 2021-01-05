using Booth.Shared;

namespace Booth.Domain.ProductManagement.Events
{
    public class ProductPlacedEvent : DomainEvent
    {
        public Product Product { get; private set; }

        public ProductPlacedEvent(Product product)
        {
            Product = product;
        }
    }
}
