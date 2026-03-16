namespace Wanna.Notifications.Api.Models;

public class CreateSubscriptionRequest
{
    public required string Email { get; set; }
    public required string EventName { get; set; }
}
