using Billing_API.Models;

namespace Billing_API.Classes;

public class PaymentGatewayService : IPaymentGatewayService
{
    public PaymentGateway GetPaymentGateway(GatewayCodes? code)
    {
        return code switch
        {
            GatewayCodes.Working => new PaymentGatewayWorking(),
            GatewayCodes.NonWorking => new PaymentGatewayNonWorking(),
            _ => throw new ArgumentOutOfRangeException(nameof(code))
        };
    }
}
