using FluentValidation;
using System.Threading.Tasks;
using FluentValidation.Attributes;
using Booth.Application.Infrastructure;
using Booth.Domain.BoothManagement.ValueObjects;

namespace Booth.Application.Commands.Booth
{
    [Validator(typeof(PlaceBoothCommandValidator))]
    public class PlaceBoothCommand : Command
    {
        public string Code { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public async override Task<CommandExecutionResult> ExecuteAsync()
        {
            var address = new Address(Street,
                                      City);

            var booth = new Domain.BoothManagement.Booth(Code,
                                                         address);

            await SaveAsync(booth, _boothRepository);

            return await OkAsync(DomainOperationResult.Create(booth.Id));
        }
    }

    internal class PlaceBoothCommandValidator : AbstractValidator<PlaceBoothCommand>
    {
        public PlaceBoothCommandValidator()
        {
            RuleFor(booth => booth.Code)
                .NotNull()
                .NotEmpty()
                .WithMessage("Code shouldn't be empty.");

            RuleFor(booth => booth.Street)
                .NotNull()
                .NotEmpty()
                .WithMessage("Street shouldn't be empty.");

            RuleFor(booth => booth.Street)
                .NotNull()
                .NotEmpty()
                .WithMessage("City shouldn't be empty.");
        }
    }
}
