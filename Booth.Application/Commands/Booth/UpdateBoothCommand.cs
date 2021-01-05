using FluentValidation;
using System.Threading.Tasks;
using FluentValidation.Attributes;
using Booth.Application.Infrastructure;
using Booth.Domain.BoothManagement.ValueObjects;

namespace Booth.Application.Commands.Booth
{
    [Validator(typeof(UpdateBoothCommandValidator))]
    public class UpdateBoothCommand : Command
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public async override Task<CommandExecutionResult> ExecuteAsync()
        {
            var booth = await _boothRepository.GetByIdAsync(Id);

            if (booth == null)
                return await FailAsync(ErrorCode.NotFound);

            var address = new Address(Street,
                                      City);

            booth.ChangeDetails(Code,
                                address);

            await SaveAsync(booth, _boothRepository);

            return await OkAsync(DomainOperationResult.Create(booth.Id));
        }
    }

    internal class UpdateBoothCommandValidator : AbstractValidator<UpdateBoothCommand>
    {
        public UpdateBoothCommandValidator()
        {
            RuleFor(booth => booth.Id)
              .GreaterThan(0)
              .WithMessage("Id should be greater than zero.");

            RuleFor(booth => booth.Code)
               .NotNull()
               .NotEmpty()
               .WithMessage("Code shouldn't be empty.");

            RuleFor(booth => booth.Street)
                .NotNull()
                .NotEmpty()
                .WithMessage("Booth street shouldn't be empty.");

            RuleFor(booth => booth.Street)
                .NotNull()
                .NotEmpty()
                .WithMessage("Booth city shouldn't be empty.");

            RuleFor(booth => booth.Code)
                .NotNull()
                .NotEmpty()
                .WithMessage("Code shouldn't be empty...");

            RuleFor(booth => booth.Street)
               .NotNull()
               .NotEmpty()
               .WithMessage("Code shouldn't be empty...");
        }
    }
}
