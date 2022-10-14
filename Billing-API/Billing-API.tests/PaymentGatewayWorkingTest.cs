using Billing_API.Classes;
using Billing_API.Models;

namespace Billing_API.tests;

public class PaymentGatewayWorkingTest
{
    [Test]
    public void WorkingPaymentGatewayCreatesReceiptTest()
    {
        var gateway = new PaymentGatewayWorking();
        var order = new Order()
        {
            OrderNumber = 1,
            UserId = 1,
            AmountInCents = 400,
            GatewayCode = GatewayCodes.Working, 
        };

        var receipt = gateway.DoPlaceOrder(order);

        Assert.That(receipt, Is.InstanceOf(typeof(PaymentReceipt)));
    }

    [Test]
    public void WorkingPaymentGatewayReturnsCorrectAmountTest()
    {
        var random = new Random();
        var amount  = random.Next(1, int.MaxValue);

        var gateway = new PaymentGatewayWorking();
        var order = new Order()
        {
            OrderNumber = 1,
            UserId = 1,
            AmountInCents = amount,
            GatewayCode = GatewayCodes.Working, 
        };

        var receipt = gateway.DoPlaceOrder(order);

        Assert.That(receipt.AmountInCents, Is.EqualTo(amount));
    }

    [Test]
    public void WorkingPaymentGatewaySpecifiesMerchantTest()
    {
        var gateway = new PaymentGatewayWorking();
        var order = new Order()
        {
            OrderNumber = 1,
            UserId = 1,
            AmountInCents = 500,
            GatewayCode = GatewayCodes.Working, 
        };

        var receipt = gateway.DoPlaceOrder(order);

        Assert.That(receipt.MerchantName, Is.Not.Empty);
    }
}
