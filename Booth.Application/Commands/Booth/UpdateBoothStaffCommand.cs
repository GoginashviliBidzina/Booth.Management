using FluentValidation;
using System.Threading.Tasks;
using FluentValidation.Attributes;
using Booth.Domain.BoothManagement;
using Microsoft.EntityFrameworkCore;
using Booth.Application.Infrastructure;
using Booth.Domain.BoothManagement.ValueObjects;

namespace Booth.Application.Commands.Booth
{
    [Validator(typeof(UpdateBoothStaffCommandValidator))]
    public class UpdateBoothStaffCommand : Command
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public string PhoneNumber { get; set; }

        public async override Task<CommandExecutionResult> ExecuteAsync()
        {
            var boothStaff = await _db.Set<BoothStaff>()
                                      .FirstOrDefaultAsync(staff => staff.Id == Id);

            var salary = new Salary(Salary);

            var phone = new Phone(PhoneNumber);

            boothStaff.ChangeDetails(FirstName,
                                     LastName,
                                     salary,
                                     phone);

            _db.Set<BoothStaff>()
               .Update(boothStaff);

            await _db.SaveChangesAsync();

            return await OkAsync(DomainOperationResult.Create(boothStaff.Id));
        }
    }

    internal class UpdateBoothStaffCommandValidator : AbstractValidator<UpdateBoothStaffCommand>
    {
        public UpdateBoothStaffCommandValidator()
        {
            RuleFor(booth => booth.Id).GreaterThan(0)
                                      .WithMessage("Placing booth staff failed: id should be greater than zero...");
        }
    }
}
