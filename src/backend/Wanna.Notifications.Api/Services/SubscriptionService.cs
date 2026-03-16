namespace Wanna.Notifications.Api.Services;
using System.Collections.Concurrent;
using Wanna.Notifications.Api.Models;

public class SubscriptionService : ISubscriptionService
{
    private readonly ConcurrentDictionary<Guid, Subscription> _subscriptions = new();
    private readonly object _stateLock = new();

    public Subscription Subscribe(string email, string eventName)
    {
        var subscription = new Subscription { Email = email, EventName = eventName };
        _subscriptions[subscription.Id] = subscription;
        return subscription;
    }

    public bool Unsubscribe(Guid id)
    {
        if (_subscriptions.TryGetValue(id, out var sub))
        {
            lock (_stateLock)
            {
                if (!sub.IsActive)
                    return false;
                sub.IsActive = false;
            }
            return true;
        }
        return false;
    }

    public IReadOnlyList<Subscription> GetAll(string? eventName = null)
    {
        var query = _subscriptions.Values.Where(s => s.IsActive);
        if (eventName is not null)
            query = query.Where(s => s.EventName.Equals(eventName, StringComparison.OrdinalIgnoreCase));
        return query.ToList();
    }

    public NotificationResult TriggerEvent(string eventName)
    {
        List<Subscription> subs;
        lock (_stateLock)
        {
            subs = _subscriptions.Values
                .Where(s => s.IsActive && s.EventName.Equals(eventName, StringComparison.OrdinalIgnoreCase))
                .ToList();

            foreach (var sub in subs)
                sub.IsActive = false;
        }

        return new NotificationResult
        {
            EventName = eventName,
            NotifiedCount = subs.Count,
            NotifiedEmails = subs.Select(s => s.Email).ToList()
        };
    }
}
