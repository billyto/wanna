namespace Wanna.Notifications.Api.Services;
using Wanna.Notifications.Api.Models;

public interface ISubscriptionService
{
    Subscription Subscribe(string email, string eventName);
    bool Unsubscribe(Guid id);
    IReadOnlyList<Subscription> GetAll(string? eventName = null);
    NotificationResult TriggerEvent(string eventName);
}
