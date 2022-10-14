using Billing_API.Models;

namespace Billing_API.Classes;

public abstract class PaymentGateway
{
    public abstract PaymentReceipt DoPlaceOrder(Order odrer);
}
