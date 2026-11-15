using EduHub.Application.Interfaces;

namespace EduHub.Application.Interfaces;

public interface INotificationFactory
{
    INotificationService Create(string channel);
}