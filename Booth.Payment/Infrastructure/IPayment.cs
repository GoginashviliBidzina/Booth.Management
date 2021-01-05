using Booth.Payment.Models;

namespace Booth.Payment
{
    public interface IPayment
    {
        PaymentResult Pay(PaymentDetails details);
    }
}
