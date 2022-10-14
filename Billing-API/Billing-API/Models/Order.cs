using System.ComponentModel.DataAnnotations;

namespace Billing_API.Models;

public class Order
{
    [Required]
    [Range(0, int.MaxValue)]
    public int? OrderNumber { get; set; }

    [Required]
    [Range(0, int.MaxValue)]
    public int? UserId { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int AmountInCents { get; set; }

    [Required]
    [EnumDataType(typeof(GatewayCodes))]
    public GatewayCodes? GatewayCode { get; set; }

    public string Description { get; set; } = string.Empty;
}
