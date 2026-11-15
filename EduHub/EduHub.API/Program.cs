using EduHub.Application.Interfaces;
using EduHub.Application.Services;
using EduHub.Infrastructure.Repositories;
using EduHub.Infrastructure.Notifications;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IEventRepository, InMemoryEventRepository>();
builder.Services.AddScoped<EventService>();
builder.Services.AddSingleton<INotificationFactory, NotificationFactory>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();