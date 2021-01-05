using FluentValidation;
using System.Threading.Tasks;
using FluentValidation.Attributes;
using Booth.Domain.BoothManagement;
using Microsoft.EntityFrameworkCore;
using Booth.Application.Infrastructure;

namespace Booth.Application.Commands.Booth
{
    [Validator(typeof(DeleteBoothStaffCommandValidator))]
    public class DeleteBoothStaffCommand : Command
    {
        public int Id { get; set; }

        public async override Task<CommandExecutionResult> ExecuteAsync()
        {
            var boothStaff = await _db.Set<BoothStaff>()
                                      .FirstOrDefaultAsync(staff => staff.Id == Id);

            if (boothStaff == null)
                return await FailAsync(ErrorCode.NotFound);

            _db.Set<BoothStaff>()
               .Remove(boothStaff);

            await _unitOfWork.SaveAsync();

            return await OkAsync(DomainOperationResult.CreateEmpty());
        }
    }

    internal class DeleteBoothStaffCommandValidator : AbstractValidator<DeleteBoothStaffCommand>
    {
        public DeleteBoothStaffCommandValidator()
        {
            RuleFor(booth => booth.Id)
                .GreaterThan(0)
                .WithMessage("Id should be greater than zero.");
        }
    }
}
