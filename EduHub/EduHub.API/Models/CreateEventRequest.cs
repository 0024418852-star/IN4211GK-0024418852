namespace EduHub.API.Models;

public class CreateEventRequest
{
    public string Title { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public int Capacity { get; set; }
    public string Channel { get; set; } = "email";
}