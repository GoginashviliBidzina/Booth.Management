using System.Linq;
using FluentValidation;
using System.Threading.Tasks;
using Booth.Application.Helpers;
using FluentValidation.Attributes;
using Booth.Application.Infrastructure;

namespace Booth.Application.Commands.Product
{
    [Validator(typeof(DeleteProductCommandValidator))]
    public class DeleteProductCommand : Command
    {
        public int Id { get; set; }

        public int BoothId { get; set; }

        public async override Task<CommandExecutionResult> ExecuteAsync()
        {
            var product = await _productRepository.GetByIdAsync(Id);

            if (product == null)
                return await FailAsync(ErrorCode.NotFound);

            if (!string.IsNullOrWhiteSpace(product.BoothIds))
            {
                var boothIds = product.BoothIds.ToNewArray();

                if (boothIds?.Any() ?? true)
                {
                    boothIds = boothIds?.Where(boothId => boothId != BoothId)
                                        .ToArray();

                    product.ChangeBoothIds(boothIds?.ToNewString());
                }
            }

            await SaveAsync(product, _productRepository);

            return await OkAsync(new DomainOperationResult(Id));
        }
    }

    internal class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(product => product.Id)
                .GreaterThan(0)
                .WithMessage("Id should be greater than zero.");

            RuleFor(product => product.BoothId)
                .GreaterThan(0)
                .WithMessage("BoothId should be greater than zero.");
        }
    }
}
