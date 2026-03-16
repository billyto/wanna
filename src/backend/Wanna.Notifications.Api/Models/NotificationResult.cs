namespace Wanna.Notifications.Api.Models;

public class NotificationResult
{
    public string EventName { get; set; } = string.Empty;
    public int NotifiedCount { get; set; }
    public IReadOnlyList<string> NotifiedEmails { get; set; } = [];
    public DateTime TriggeredAt { get; set; } = DateTime.UtcNow;
}
