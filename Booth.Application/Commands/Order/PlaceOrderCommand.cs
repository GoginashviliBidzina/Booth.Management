using System.Linq;
using FluentValidation;
using Booth.Payment.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using FluentValidation.Attributes;
using Booth.Domain.OrderManagement;
using Booth.Payment.Infrastructure;
using Booth.Application.Infrastructure;
using Booth.Application.Commands.Order.Models;

namespace Booth.Application.Commands.Order
{
    [Validator(typeof(PlaceOrderCommandValidator))]
    public class PlaceOrderCommand : Command
    {
        public int BoothId { get; set; }

        public decimal CashAmount { get; set; }

        public string CardNumber { get; set; } = "5280-5850-1690-0043";

        public string CardOwner { get; private set; } = "BIDZINA GOGINASHVILI";

        public PaymentMethod PaymentMethod { get; set; }

        public IEnumerable<OrderItemDto> OrderItems { get; set; }

        public async override Task<CommandExecutionResult> ExecuteAsync()
        {
            var totalAmount = OrderItems.Sum(item => item.Price * item.Quantity);

            var orderItems = OrderItems.Select(items => new OrderItem(items.ProductId,
                                                                      items.Quantity,
                                                                      items.Price * items.Quantity,
                                                                      PaymentMethod));

            var paymentDetails = new PaymentDetails(CashAmount,
                                                    CardNumber,
                                                    CardOwner,
                                                    totalAmount,
                                                    PaymentMethod);

            var paymentFactory = PaymentFactory.Create(paymentDetails);
            var paymentResult = paymentFactory.Pay(paymentDetails);

            if (!paymentResult.IsSuccess)
                return await FailAsync(ErrorCode.PaymentUnsuccesfull);

            var order = new Domain.OrderManagement.Order(BoothId,
                                                         totalAmount,
                                                         OrderStatus.Placed,
                                                         orderItems.ToList());

            await SaveAsync(order, _orderRepository);

            return await OkAsync(DomainOperationResult.CreateEmpty());
        }
    }

    internal class PlaceOrderCommandValidator : AbstractValidator<PlaceOrderCommand>
    {
        public PlaceOrderCommandValidator()
        {
            RuleFor(order => order.BoothId)
                .GreaterThan(0)
                .WithMessage("Id should be greater than zero.");

            RuleFor(order => order.CashAmount)
                .GreaterThan(0)
                .WithMessage("Cash amount should be greater than zero.");

            RuleFor(order => order.OrderItems)
                .NotEmpty()
                .NotNull();
        }
    }
}
