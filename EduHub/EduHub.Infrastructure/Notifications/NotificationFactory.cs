using EduHub.Application.Interfaces;

namespace EduHub.Infrastructure.Notifications;

public class NotificationFactory : INotificationFactory
{
    public INotificationService Create(string channel)
    {
        return channel.ToLower() switch
        {
            "email" => new EmailNotificationService(),
            "sms" => new SmsNotificationService(),
            _ => throw new ArgumentException("Invalid notification channel")
        };
    }
}