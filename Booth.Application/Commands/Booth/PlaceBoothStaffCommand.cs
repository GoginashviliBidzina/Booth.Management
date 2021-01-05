using FluentValidation;
using System.Threading.Tasks;
using FluentValidation.Attributes;
using Booth.Application.Infrastructure;
using Booth.Domain.BoothManagement.ValueObjects;

namespace Booth.Application.Commands.Booth
{
    [Validator(typeof(PlaceBoothStaffCommandValidator))]
    public class PlaceBoothStaffCommand : Command
    {
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public int BoothId { get; private set; }

        public decimal Salary { get; private set; }

        public string PhoneNumber { get; private set; }

        public async override Task<CommandExecutionResult> ExecuteAsync()
        {
            var booth = await _boothRepository.GetByIdAsync(BoothId);

            if (booth == null)
                return await FailAsync(ErrorCode.NotFound);

            var salary = new Salary(Salary);

            var phone = new Phone(PhoneNumber);

            var boothStaff = new Domain.BoothManagement.BoothStaff(FirstName,
                                                                   LastName,
                                                                   salary,
                                                                   phone);

            await _db.Set<Domain.BoothManagement.BoothStaff>()
                     .AddAsync(boothStaff);

            await _db.SaveChangesAsync();

            return await OkAsync(DomainOperationResult.Create(boothStaff.Id));
        }
    }

    internal class PlaceBoothStaffCommandValidator : AbstractValidator<PlaceBoothStaffCommand>
    {
        public PlaceBoothStaffCommandValidator()
        {
            RuleFor(boothStaff => boothStaff.BoothId)
                .GreaterThan(0)
                .WithMessage("Id should be greater than zero.");

            RuleFor(boothStaff => boothStaff.FirstName)
              .NotNull()
              .NotEmpty()
              .WithMessage("FirstName shouldn't be empty.");

            RuleFor(boothStaff => boothStaff.PhoneNumber)
              .NotNull()
              .NotEmpty()
              .WithMessage("PhoneNumber shouldn't be empty.");

            RuleFor(boothStaff => boothStaff.Salary)
              .GreaterThan(0)
              .WithMessage("Salary should be greater than zero.");

            RuleFor(boothStaff => boothStaff.LastName)
            .NotNull()
            .NotEmpty()
            .WithMessage("LastName shouldn't be empty.");
        }
    }
}
