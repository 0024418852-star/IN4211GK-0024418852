using EduHub.Domain.Entities;

namespace EduHub.Application.Interfaces;

public interface IEventRepository
{
    void Add(Event ev);
    Event? GetById(Guid id);
    IEnumerable<Event> GetByClubId(Guid clubId);
    void Delete(Guid id);
}