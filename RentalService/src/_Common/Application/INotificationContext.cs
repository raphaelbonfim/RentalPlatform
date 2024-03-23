using FluentValidation.Results;

namespace Common.Application;

public interface INotificationContext
{
    IReadOnlyCollection<Notification> Notifications { get; }
    bool HasNotifications { get; }
    NotificationType NotificationType { get; set; }

    void AddAsAppService(string message);
    void AddAsDomainValidation(ValidationResult validationResult);
        
    void AddNotification(string message);
    void AddNotification(string message, Exception exception);
}