namespace Booth.Domain.ProductManagement.Events
{
    public class ProductSupplierPlacedEvent
    {
        public ProductSupplier ProductSupplier { get; private set; }

        public ProductSupplierPlacedEvent(ProductSupplier productSupplier)
        {
            ProductSupplier = productSupplier;
        }
    }
}
