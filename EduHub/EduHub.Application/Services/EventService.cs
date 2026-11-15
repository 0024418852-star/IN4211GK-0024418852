using EduHub.Application.Interfaces;
using EduHub.Domain.Entities;

namespace EduHub.Application.Services;

public class EventService
{
    private readonly IEventRepository _repository;
    private readonly INotificationFactory _notificationFactory;

    public EventService(
        IEventRepository repository,
        INotificationFactory notificationFactory)
    {
        _repository = repository;
        _notificationFactory = notificationFactory;
    }

    public Event CreateEvent(
        Guid clubId,
        string title,
        DateTime date,
        int capacity,
        string channel)
    {
        var ev = Event.Create(clubId, title, date, capacity);

        _repository.Add(ev);

        var notification = _notificationFactory.Create(channel);
        notification.Send($"New event: {title}");

        return ev;
    }
}