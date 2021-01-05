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
    [Validator(typeof(UpdateProductCommandValidator))]
    public class UpdateProductCommand : Command
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int SupplierId { get; set; }

        public string PhotoUrl { get; set; }

        public int PhotoWidth { get; set; }

        public int PhotoHeight { get; set; }

        public IEnumerable<int> BoothIds { get; set; }

        public async override Task<CommandExecutionResult> ExecuteAsync()
        {
            var product = await _productRepository.GetByIdAsync(Id);

            var photo = new Photo(PhotoUrl,
                                  PhotoWidth,
                                  PhotoHeight);

            var boothIds = BoothIds.ToArray()
                                   .ToNewString();

            product.ChangeDetails(Name,
                                  Description,
                                  Price,
                                  boothIds,
                                  SupplierId,
                                  photo);

            await SaveAsync(product, _productRepository);

            return await OkAsync(DomainOperationResult.Create(product.Id));
        }
    }

    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(product => product.Id)
                .GreaterThan(0)
                .WithMessage("Id should be greater than zero.");
        }
    }
}
