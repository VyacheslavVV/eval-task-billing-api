using System.ComponentModel.Design;
using System.Net;
using Billing_API.Classes;
using Billing_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Billing_API.Controllers;

// https://github.com/oganzins/Task-Billing-API
[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly ILogger _logger;

    public OrderController(ILogger<OrderController> logger)
    {
        _logger = logger;
    }

    /// <exception cref="ArgumentOutOfRangeException"></exception>
    /// <remarks>
    ///  sends the order to an appropriate payment gateway. If the order is processed successfully
    /// by the payment gateway, the billing service creates a receipt and returns it in response.
    /// </remarks>
    /// <response code="200">OK. Indicates that the order is processed.</response>
    /// <response code="500">Error. Indicates processing error.</response>
    /// <returns>All products.</returns>
    [HttpPost]
    public IActionResult Place([FromBody] Order order)
    {
        PaymentGateway paymentGateway = order.GatewayCode switch
        {
            GatewayCodes.Working => new PaymentGatewayWorking(),
            GatewayCodes.NonWorking => new PaymentGatewayNonWorking(),
            _ => throw new ArgumentOutOfRangeException(nameof(order.GatewayCode))
        };

        ActionResult result;

        try
        {
            result = Ok( paymentGateway.DoPlaceOrder(order));
        }
        catch (CheckoutException exception)
        {
            _logger.LogCritical($"An exception, while processing order: {exception.Message}");

            result = StatusCode((int) HttpStatusCode.InternalServerError, "Something went wrong");
        }

        return result;
    }
}
