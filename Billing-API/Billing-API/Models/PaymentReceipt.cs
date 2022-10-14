namespace Billing_API.Models;

public class PaymentReceipt
{
    public string MerchantName { get; set; } = string.Empty;

    public Guid TransactionId { get; set; }
    
    public DateTime ProcessedAt { get; set; }

    public int AmountInCents { get; set; }
}
