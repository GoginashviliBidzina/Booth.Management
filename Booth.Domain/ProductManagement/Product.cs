using Booth.Shared;
using Booth.Domain.ProductManagement.Events;
using Booth.Domain.ProductManagement.ValueObjects;

namespace Booth.Domain.ProductManagement
{
    public class Product : AggregateRoot
    {
        public string Code { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public decimal Price { get; private set; }

        public string BoothIds { get; private set; }

        public int ProductSupplierId { get; private set; }

        public ProductSupplier ProductSupplier { get; set; }

        public Photo Photo { get; private set; }

        public Product()
        {

        }

        public Product(string code,
                       string name,
                       string description,
                       decimal price,
                       string boothIds,
                       int productSupplierId,
                       Photo photo)
        {
            Code = code;
            Name = name;
            Description = description;
            Price = price;
            BoothIds = boothIds;
            ProductSupplierId = productSupplierId;
            Photo = photo;

            Raise(new ProductPlacedEvent(this));
        }

        public void ChangeDetails(string name,
                                  string description,
                                  decimal price,
                                  string boothIds,
                                  int productSupplierId,
                                  Photo photo)
        {
            Name = name;
            Description = description;
            Price = price;
            ProductSupplierId = productSupplierId;
            Photo = photo;

            Raise(new ProductChangedEvent(this));
        }

        public void ChangeBoothIds(string boothIds)
        {
            BoothIds = boothIds;
        }
    }
}
