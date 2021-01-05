using Booth.Domain.ProductManagement.Events;
using Booth.Domain.ProductManagement.ReadModels;
using Booth.Infrastructure.DataBase;
using Booth.Infrastructure.EventDispatching;
using System.Linq;

namespace Booth.Application.EventHandlers.Product
{
    public class ProductEventHandler : IHandleEvent<ProductPlacedEvent>,
                                       IHandleEvent<ProductChangedEvent>
    {
        public void Handle(ProductPlacedEvent @event, DatabaseContext db)
        {
            var product = @event.Product;

            if (product == null)
                return;

            var productReadModel = new ProductReadModel(product.Code,
                                                        product.Id,
                                                        product.BoothIds,
                                                        product.Name,
                                                        product.Description,
                                                        product.Price,
                                                        product.ProductSupplierId,
                                                        product.ProductSupplier.Name,
                                                        product.Photo.Url,
                                                        product.Photo.Width,
                                                        product.Photo.Height);

            db.Set<ProductReadModel>()
              .Add(productReadModel);
        }

        public void Handle(ProductChangedEvent @event, DatabaseContext db)
        {
            var product = @event.Product;

            if (product == null)
                return;

            var productReadModel = db.Set<ProductReadModel>()
                                     .FirstOrDefault(readmodel => readmodel.AggregateRootId == product.Id);

            if (productReadModel != null)
            {
                productReadModel.ChangeDetails(product.Code,
                                               product.Id,
                                               product.BoothIds,
                                               product.Name,
                                               product.Description,
                                               product.Price,
                                               product.ProductSupplierId,
                                               product.ProductSupplier.Name,
                                               product.Photo.Url,
                                               product.Photo.Width,
                                               product.Photo.Height);

                db.Set<ProductReadModel>()
                  .Update(productReadModel);
            }
        }
    }
}
