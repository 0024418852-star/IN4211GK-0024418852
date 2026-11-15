using EduHub.Application.Interfaces;
using EduHub.Application.Services;
using EduHub.Domain.Entities;
using Moq;
using Xunit;

namespace EduHub.Tests.EntitiesTests;

public class EventServiceTests
{
    [Fact]
    public void CreateEvent_ShouldAddEventAndSendNotification()
    {
        var repository = new Mock<IEventRepository>();
        var factory = new Mock<INotificationFactory>();
        var notification = new Mock<INotificationService>();

        factory.Setup(f => f.Create("email"))
               .Returns(notification.Object);

        var service = new EventService(
            repository.Object,
            factory.Object);

        service.CreateEvent(
            Guid.NewGuid(),
            "Test Event",
            DateTime.Now,
            100,
            "email");

        repository.Verify(
            r => r.Add(It.IsAny<Event>()),
            Times.Once);

        notification.Verify(
            n => n.Send(It.IsAny<string>()),
            Times.Once);
    }
}