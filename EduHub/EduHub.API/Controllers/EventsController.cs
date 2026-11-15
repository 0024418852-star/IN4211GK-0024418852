using EduHub.API.Models;
using EduHub.Application.Interfaces;
using EduHub.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace EduHub.API.Controllers;

[ApiController]
[Route("api")]
public class EventsController : ControllerBase
{
    private readonly IEventRepository _repository;
    private readonly EventService _eventService;

    public EventsController(
        IEventRepository repository,
        EventService eventService)
    {
        _repository = repository;
        _eventService = eventService;
    }

    [HttpGet("clubs/{clubId}/events")]
    public IActionResult GetByClub(Guid clubId)
    {
        return Ok(_repository.GetByClubId(clubId));
    }

    [HttpGet("events/{id}")]
    public IActionResult GetById(Guid id)
    {
        var ev = _repository.GetById(id);

        if (ev == null)
            return NotFound();

        return Ok(ev);
    }

    [HttpPost("clubs/{clubId}/events")]
    public IActionResult Create(Guid clubId, CreateEventRequest request)
    {
        try
        {
            var ev = _eventService.CreateEvent(
                clubId,
                request.Title,
                request.Date,
                request.Capacity,
                request.Channel);

            return CreatedAtAction(nameof(GetById), new { id = ev.Id }, ev);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpDelete("events/{id}")]
    public IActionResult Delete(Guid id)
    {
        var ev = _repository.GetById(id);

        if (ev == null)
            return NotFound();

        _repository.Delete(id);

        return NoContent();
    }
}