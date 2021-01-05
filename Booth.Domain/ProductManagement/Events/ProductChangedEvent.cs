using Booth.Shared;

namespace Booth.Domain.ProductManagement.Events
{
    public class ProductChangedEvent : DomainEvent
    {
        public Product Product;

        public ProductChangedEvent(Product product)
        {
            Product = product;
        }
    }
}
