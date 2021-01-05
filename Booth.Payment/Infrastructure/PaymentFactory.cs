using Booth.Payment.Models;
using Booth.Domain.OrderManagement;
using Booth.Payment.PaymentMethods;

namespace Booth.Payment.Infrastructure
{
    public static class PaymentFactory
    {
        public static IPayment Create(PaymentDetails paymentDetails)
        {
            if (paymentDetails.PaymentMethod == PaymentMethod.TBC)
            {
                return new TbcPayment();
            }
            else if (paymentDetails.PaymentMethod == PaymentMethod.BOG)
            {
                return new BogPayment();
            }
            else
            {
                return new CashPayment();
            }
        }
    }
}
