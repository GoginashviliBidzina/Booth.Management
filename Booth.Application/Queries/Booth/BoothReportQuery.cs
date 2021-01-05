using FluentValidation;
using System.Threading.Tasks;
using FluentValidation.Attributes;
using Booth.Application.Infrastructure;

namespace Booth.Application.Queries.Booth
{
    [Validator(typeof(BoothReportQueryValidator))]
    public class BoothReportQuery : Query<BoothReportQueryDetails>
    {
        public int Id { get; set; }

        public async override Task<QueryExecutionResult<BoothReportQueryDetails>> ExecuteAsync()
        {
            var booth = await _boothRepository.GetByIdAsync(Id);

            var result = new BoothReportQueryDetails();

            return await OkAsync(result);
        }
    }

    public class BoothReportQueryDetails
    {
    }

    public class BoothOrders
    {
    }

    internal class BoothReportQueryValidator : AbstractValidator<BoothReportQuery>
    {
        public BoothReportQueryValidator()
        {
            RuleFor(booth => booth.Id)
                .GreaterThan(0)
                .WithMessage("Id should be greater than zero.");
        }
    }
}
