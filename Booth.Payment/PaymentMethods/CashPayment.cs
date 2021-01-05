using Booth.Payment.Models;

namespace Booth.Payment.PaymentMethods
{
    public class CashPayment : IPayment
    {
        public PaymentResult Pay(PaymentDetails details)
        {
            var cashBack = details.CashAmount - details.PaymentAmount;
            if (cashBack >= 0)
                return new PaymentResult(true,
                                         details.CashAmount - details.PaymentAmount);
            else
                return new PaymentResult(false,
                                         cashBack);
        }
    }
}
