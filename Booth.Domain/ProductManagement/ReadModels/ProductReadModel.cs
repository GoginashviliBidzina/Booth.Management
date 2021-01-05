namespace Booth.Domain.ProductManagement.ReadModels
{
    public class ProductReadModel
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public int AggregateRootId { get; set; }

        public string BoothIds { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int SupplierId { get; set; }

        public string SupplierName { get; set; }

        public string PhotoUrl { get; set; }

        public int PhotoWidth { get; set; }

        public int PhotoHeight { get; set; }

        public ProductReadModel(string code,
                                int aggregateRootId,
                                string boothIds,
                                string name,
                                string description,
                                decimal price,
                                int supplierId,
                                string supplierName,
                                string photoUrl,
                                int photoWidth,
                                int photoHeight)
        {
            Code = code;
            AggregateRootId = aggregateRootId;
            BoothIds = boothIds;
            Name = name;
            Description = description;
            Price = price;
            SupplierId = supplierId;
            SupplierName = supplierName;
            PhotoUrl = photoUrl;
            PhotoWidth = photoWidth;
            PhotoHeight = photoHeight;
        }

        public void ChangeDetails(string code,
                                int aggregateRootId,
                                string boothIds,
                                string name,
                                string description,
                                decimal price,
                                int supplierId,
                                string supplierName,
                                string photoUrl,
                                int photoWidth,
                                int photoHeight)

        {
            Code = code;
            AggregateRootId = aggregateRootId;
            BoothIds = boothIds;
            Name = name;
            Description = description;
            Price = price;
            SupplierId = supplierId;
            SupplierName = supplierName;
            PhotoUrl = photoUrl;
            PhotoWidth = photoWidth;
            PhotoHeight = photoHeight;
        }
    }
}
