using System.Linq;
using FluentValidation;
using System.Threading.Tasks;
using Booth.Application.Helpers;
using System.Collections.Generic;
using FluentValidation.Attributes;
using Booth.Application.Infrastructure;
using Booth.Domain.ProductManagement.ValueObjects;

namespace Booth.Application.Commands.Product
{
    [Validator(typeof(PlaceProductCommandValidator))]
    public class PlaceProductCommand : Command
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int ProductSupplierId { get; set; }

        public string PhotoUrl { get; set; }

        public int PhotoWidth { get; set; }

        public int PhotoHeight { get; set; }

        public IEnumerable<int> BoothIds { get; set; }

        public async override Task<CommandExecutionResult> ExecuteAsync()
        {
            var photo = new Photo(PhotoUrl,
                                  PhotoWidth,
                                  PhotoHeight);

            var isValidSupplier = _db.Set<Domain.ProductManagement.ProductSupplier>()
                                     .FirstOrDefault(supplier => supplier.Id == ProductSupplierId);

            var boothIds = BoothIds.ToArray()
                                   .ToNewString();

            var product = new Domain.ProductManagement.Product(Code,
                                                               Name,
                                                               Description,
                                                               Price,
                                                               boothIds,
                                                               ProductSupplierId,
                                                               photo);

            await SaveAsync(product, _productRepository);

            return await OkAsync(DomainOperationResult.Create(product.Id));
        }
    }

    internal class PlaceProductCommandValidator : AbstractValidator<PlaceProductCommand>
    {
        public PlaceProductCommandValidator()
        {
            RuleFor(product => product.ProductSupplierId)
                .GreaterThan(0)
                .WithMessage("Supplier id should be greater than zero.");

            RuleFor(product => product.Code)
               .NotNull()
               .NotEmpty()
               .WithMessage("Code should not be empty.");
        }
    }
}
