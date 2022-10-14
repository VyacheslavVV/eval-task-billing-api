using System.ComponentModel.Design;
using Billing_API.Classes;
using Billing_API.Models;

namespace Billing_API.tests;

public class PaymentGatewayNonWorkingTest
{
    [Test]
    public void NonWorkingPaymentGatewayThrowsException()
    {
        var gateway = new PaymentGatewayNonWorking();
        var order = new Order()
        {
            OrderNumber = 1,
            UserId = 1,
            AmountInCents = 400,
            GatewayCode = GatewayCodes.NonWorking, 
        };

        Assert.Throws<CheckoutException>(() => gateway.DoPlaceOrder(order));
    }
}
