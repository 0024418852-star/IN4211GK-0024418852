using EduHub.Domain.Entities;
using EduHub.Domain.Enums;
using Xunit;

namespace EduHub.Tests.EntitiesTests;

public class RegistrationTests
{
    [Fact]
    public void Create_ShouldHavePendingStatus()
    {
        var r = Registration.Create(Guid.NewGuid(), Guid.NewGuid());

        Assert.Equal(RegistrationStatus.Pending, r.Status);
    }

    [Fact]
    public void Confirm_ShouldChangeStatusToConfirmed()
    {
        var r = Registration.Create(Guid.NewGuid(), Guid.NewGuid());

        r.Confirm();

        Assert.Equal(RegistrationStatus.Confirmed, r.Status);
    }

    [Fact]
    public void CancelThenConfirm_ShouldThrowAndRemainCancelled()
    {
        var r = Registration.Create(Guid.NewGuid(), Guid.NewGuid());

        r.Cancel();

        Assert.Throws<InvalidOperationException>(() => r.Confirm());

        Assert.Equal(RegistrationStatus.Cancelled, r.Status);
    }
}