namespace Wanna.Notifications.Api.Tests.Services;
using Wanna.Notifications.Api.Services;
using Xunit;

public class SubscriptionServiceTests
{
    private readonly SubscriptionService _service = new();

    [Fact]
    public void Subscribe_ReturnsNewSubscription()
    {
        var sub = _service.Subscribe("user@example.com", "product-restock");
        Assert.NotEqual(Guid.Empty, sub.Id);
        Assert.Equal("user@example.com", sub.Email);
        Assert.Equal("product-restock", sub.EventName);
        Assert.True(sub.IsActive);
    }

    [Fact]
    public void GetAll_WithNoFilter_ReturnsAllActive()
    {
        _service.Subscribe("a@test.com", "event-1");
        _service.Subscribe("b@test.com", "event-2");
        var all = _service.GetAll();
        Assert.Equal(2, all.Count);
    }

    [Fact]
    public void GetAll_WithEventNameFilter_ReturnsOnlyMatching()
    {
        _service.Subscribe("a@test.com", "restock");
        _service.Subscribe("b@test.com", "launch");
        var result = _service.GetAll("restock");
        Assert.Single(result);
        Assert.Equal("a@test.com", result[0].Email);
    }

    [Fact]
    public void Unsubscribe_ExistingId_ReturnsTrueAndDeactivates()
    {
        var sub = _service.Subscribe("user@example.com", "event");
        var result = _service.Unsubscribe(sub.Id);
        Assert.True(result);
        Assert.Empty(_service.GetAll());
    }

    [Fact]
    public void Unsubscribe_NonExistingId_ReturnsFalse()
    {
        var result = _service.Unsubscribe(Guid.NewGuid());
        Assert.False(result);
    }

    [Fact]
    public void TriggerEvent_NotifiesActiveSubscribers_AndDeactivatesThem()
    {
        _service.Subscribe("a@test.com", "restock");
        _service.Subscribe("b@test.com", "restock");
        _service.Subscribe("c@test.com", "other-event");

        var result = _service.TriggerEvent("restock");
        
        Assert.Equal("restock", result.EventName);
        Assert.Equal(2, result.NotifiedCount);
        Assert.Contains("a@test.com", result.NotifiedEmails);
        Assert.Contains("b@test.com", result.NotifiedEmails);
        
        // Subscribers should be deactivated after notification
        Assert.Empty(_service.GetAll("restock"));
    }

    [Fact]
    public void TriggerEvent_CaseInsensitiveEventName()
    {
        _service.Subscribe("user@test.com", "ProductRestock");
        var result = _service.TriggerEvent("productrestock");
        Assert.Equal(1, result.NotifiedCount);
    }
}
