namespace Wanna.Notifications.Api.Models;
using System.ComponentModel.DataAnnotations;

public class CreateSubscriptionRequest
{
    [Required]
    [EmailAddress]
    public required string Email { get; set; }

    [Required]
    [MinLength(1)]
    public required string EventName { get; set; }
}
