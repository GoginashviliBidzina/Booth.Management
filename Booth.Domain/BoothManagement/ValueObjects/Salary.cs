using Booth.Shared;

namespace Booth.Domain.BoothManagement.ValueObjects
{
    public class Salary : ValueObject
    {
        public decimal Amount { get; private set; }

        public Salary(decimal amount)
        {
            Amount = amount;
        }
    }
}
