using System.Linq;
using FluentValidation;
using System.Threading.Tasks;
using System.Collections.Generic;
using FluentValidation.Attributes;
using Booth.Application.Infrastructure;

namespace Booth.Application.Queries.Booth
{
    [Validator(typeof(BoothDetailsQueryValidator))]
    public class BoothDetailsQuery : Query<BoothDetailsQueryResult>
    {
        public int Id { get; set; }

        public async override Task<QueryExecutionResult<BoothDetailsQueryResult>> ExecuteAsync()
        {
            var booth = await _boothRepository.GetByIdAsync(Id);

            if (booth == null)
                return await FailAsync(ErrorCode.NotFound);

            var boothStaffs = booth.BoothStaff?.Select(boothStaff => new BoothStaff(boothStaff.FirstName,
                                                                                    boothStaff.LastName,
                                                                                    boothStaff.Phone?.PhoneNumber,
                                                                                    boothStaff.Salary.Amount));
            var result = new BoothDetailsQueryResult(booth.Code,
                                                     booth.Address?.Street,
                                                     booth.Address?.City,
                                                     boothStaffs);

            return await OkAsync(result);
        }
    }

    public class BoothDetailsQueryResult
    {
        public string Code { get; private set; }

        public string Street { get; private set; }

        public string City { get; private set; }

        public IEnumerable<BoothStaff> BoothStaffs { get; private set; }

        public BoothDetailsQueryResult(string code,
                                       string street,
                                       string city,
                                       IEnumerable<BoothStaff> boothStaffs)
        {
            Code = code;
            Street = street;
            City = city;
            BoothStaffs = boothStaffs;
        }
    }

    public class BoothStaff
    {
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string PhoneNumber { get; private set; }

        public decimal Salary { get; private set; }

        public BoothStaff(string firstName,
                          string lastName,
                          string phoneNumber,
                          decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Salary = salary;
        }
    }

    internal class BoothDetailsQueryValidator : AbstractValidator<BoothDetailsQuery>
    {
        public BoothDetailsQueryValidator()
        {
            RuleFor(product => product.Id)
                .GreaterThan(0)
                .WithMessage("Id should be greater than zero.");
        }
    }
}
