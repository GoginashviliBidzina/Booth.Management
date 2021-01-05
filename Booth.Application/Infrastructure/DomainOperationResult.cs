namespace Booth.Application.Infrastructure
{
    public class DomainOperationResult
    {
        public DomainOperationResult()
        {
        }

        public DomainOperationResult(int id)
        {
            Id = id;
        }

        public DomainOperationResult(decimal returnAmount)
        {
            ReturnAmount = returnAmount;
        }

        public int Id { get; }

        public decimal ReturnAmount { get; }

        public static DomainOperationResult Create(int id) => new DomainOperationResult(id);

        public static DomainOperationResult Create(decimal returnAmount) => new DomainOperationResult(returnAmount);

        public static DomainOperationResult CreateEmpty() => new DomainOperationResult();


    }
}