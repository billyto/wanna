namespace Wanna.Notifications.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Wanna.Notifications.Api.Services;

[ApiController]
[Route("api/[controller]")]
public class NotificationsController : ControllerBase
{
    private readonly ISubscriptionService _service;

    public NotificationsController(ISubscriptionService service)
    {
        _service = service;
    }

    // POST api/notifications/trigger/{eventName}
    [HttpPost("trigger/{eventName}")]
    public IActionResult TriggerEvent(string eventName)
    {
        if (string.IsNullOrWhiteSpace(eventName))
            return BadRequest("eventName must not be empty.");

        var result = _service.TriggerEvent(eventName);
        return Ok(result);
    }
}
