using Booth.Domain.OrderManagement;

namespace Booth.Payment.Models
{
    public class PaymentDetails
    {
        public decimal CashAmount { get; private set; }

        public string CardNumber { get; private set; }

        public string CardOwner { get; private set; }

        public decimal PaymentAmount { get; private set; }

        public PaymentMethod PaymentMethod { get; private set; }

        public PaymentDetails(decimal cashAmount,
                              string cardNumber,
                              string cardOwner,
                              decimal paymentAmount,
                              PaymentMethod paymentMethod)
        {
            CashAmount = cashAmount;
            CardNumber = cardNumber;
            CardOwner = cardOwner;
            PaymentAmount = paymentAmount;
            PaymentMethod = paymentMethod;
        }
    }
}
