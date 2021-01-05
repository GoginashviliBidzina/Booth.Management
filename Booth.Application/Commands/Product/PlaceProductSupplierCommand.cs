using FluentValidation;
using System.Threading.Tasks;
using FluentValidation.Attributes;
using Booth.Application.Infrastructure;
using Booth.Domain.ProductManagement.ValueObjects.Supplier;

namespace Booth.Application.Commands.ProductSupplier
{
    [Validator(typeof(PlaceProductSupplierCommandValidator))]
    public class PlaceProductSupplierCommand : Command
    {
        public string Name { get; set; }

        public string Fax { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string PhoneNumber { get; set; }

        public async override Task<CommandExecutionResult> ExecuteAsync()
        {
            var address = new Address(Street,
                                      City);

            var phone = new Phone(PhoneNumber);

            var productSupplier = new Domain.ProductManagement.ProductSupplier(Name,
                                                                               Fax,
                                                                               phone,
                                                                               address);

            await _db.Set<Domain.ProductManagement.ProductSupplier>()
                     .AddAsync(productSupplier);

            await _db.SaveChangesAsync();

            return await OkAsync(DomainOperationResult.Create(productSupplier.Id));
        }
    }

    internal class PlaceProductSupplierCommandValidator : AbstractValidator<PlaceProductSupplierCommand>
    {
        public PlaceProductSupplierCommandValidator()
        {
            RuleFor(supplier => supplier.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Name shouldn't be empty.");
        }
    }
}
