namespace Wanna.Notifications.Api.Services;
using System.Collections.Concurrent;
using Wanna.Notifications.Api.Models;

public class SubscriptionService : ISubscriptionService
{
    private readonly ConcurrentDictionary<Guid, Subscription> _subscriptions = new();

    public Subscription Subscribe(string email, string eventName)
    {
        var subscription = new Subscription { Email = email, EventName = eventName };
        _subscriptions[subscription.Id] = subscription;
        return subscription;
    }

    public bool Unsubscribe(Guid id)
    {
        return _subscriptions.TryRemove(id, out _);
    }

    public IReadOnlyList<Subscription> GetAll(string? eventName = null)
    {
        IEnumerable<Subscription> query = _subscriptions.Values;
        if (eventName is not null)
            query = query.Where(s => s.EventName.Equals(eventName, StringComparison.OrdinalIgnoreCase));
        return query.ToList();
    }

    public NotificationResult TriggerEvent(string eventName)
    {
        var notifiedAt = DateTime.UtcNow;
        var notified = new List<Subscription>();

        foreach (var key in _subscriptions.Keys.ToList())
        {
            if (_subscriptions.TryGetValue(key, out var sub)
                && sub.EventName.Equals(eventName, StringComparison.OrdinalIgnoreCase)
                && _subscriptions.TryRemove(key, out _))
            {
                sub.NotifiedAt = notifiedAt;
                notified.Add(sub);
            }
        }

        return new NotificationResult
        {
            EventName = eventName,
            NotifiedCount = notified.Count,
            NotifiedEmails = notified.Select(s => s.Email).ToList()
        };
    }
}
