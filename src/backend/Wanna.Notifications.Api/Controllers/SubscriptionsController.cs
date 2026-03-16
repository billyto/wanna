namespace Wanna.Notifications.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Wanna.Notifications.Api.Models;
using Wanna.Notifications.Api.Services;

[ApiController]
[Route("api/[controller]")]
public class SubscriptionsController : ControllerBase
{
    private readonly ISubscriptionService _service;

    public SubscriptionsController(ISubscriptionService service)
    {
        _service = service;
    }

    // GET api/subscriptions?eventName=xxx
    [HttpGet]
    public ActionResult<IReadOnlyList<Subscription>> GetAll([FromQuery] string? eventName = null)
    {
        return Ok(_service.GetAll(eventName));
    }

    // POST api/subscriptions
    [HttpPost]
    public ActionResult<Subscription> Subscribe([FromBody] CreateSubscriptionRequest request)
    {
        var subscription = _service.Subscribe(request.Email, request.EventName);
        return CreatedAtAction(nameof(GetAll), new { eventName = subscription.EventName }, subscription);
    }

    // DELETE api/subscriptions/{id}
    [HttpDelete("{id:guid}")]
    public IActionResult Unsubscribe(Guid id)
    {
        if (!_service.Unsubscribe(id))
            return NotFound();
        return NoContent();
    }
}
