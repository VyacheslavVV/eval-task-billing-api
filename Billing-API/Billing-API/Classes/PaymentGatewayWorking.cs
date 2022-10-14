using Billing_API.Models;

namespace Billing_API.Classes;

public class PaymentGatewayWorking : PaymentGateway
{
    private const string MerchantName = "Working merchant";

    public override PaymentReceipt DoPlaceOrder(Order order)
    {
        return new PaymentReceipt()
        {
            MerchantName = MerchantName,
            TransactionId = Guid.NewGuid(),
            ProcessedAt = DateTime.Now,
            AmountInCents = order.AmountInCents,
        };
    }
}
