using System.ComponentModel.Design;
using Billing_API.Models;

namespace Billing_API.Classes;

public class PaymentGatewayNonWorking : PaymentGateway
{
    public override PaymentReceipt DoPlaceOrder(Order order)
    {
        throw new CheckoutException("Selected payment gateway encountered an error!");

        return new PaymentReceipt();
    }
}
