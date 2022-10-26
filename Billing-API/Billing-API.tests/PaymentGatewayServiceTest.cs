using Billing_API.Classes;
using Billing_API.Models;

namespace Billing_API.tests;

public class PaymentGatewayServiceTest
{
    [Test]
    public void NullOrIncorrectGatewayCodeThrows()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            new PaymentGatewayService().GetPaymentGateway(null));
    }

    [Test]
    public void ExistingGatewayCodeReturnsAppropriateClass()
    {
        var gateway = new PaymentGatewayService()
            .GetPaymentGateway(GatewayCodes.Working);
        
        Assert.IsInstanceOf<PaymentGatewayWorking>(gateway);
    }
}
