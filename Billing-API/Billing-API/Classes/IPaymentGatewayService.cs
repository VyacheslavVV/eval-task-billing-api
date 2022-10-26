using Billing_API.Models;

namespace Billing_API.Classes;

public interface IPaymentGatewayService
{
    public PaymentGateway GetPaymentGateway(GatewayCodes? code);
}
