namespace Booth.Payment.Models
{
    public class PaymentResult
    {
        public bool IsSuccess { get; private set; }

        public decimal ReturnAmount { get; private set; }

        public PaymentResult(bool isSuccess,
                             decimal returnAmount)
        {
            IsSuccess = isSuccess;
            ReturnAmount = returnAmount;
        }
    }
}
