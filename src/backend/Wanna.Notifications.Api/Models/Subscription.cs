namespace Wanna.Notifications.Api.Models;

public class Subscription
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Email { get; set; }
    public required string EventName { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool IsActive { get; set; } = true;
}
