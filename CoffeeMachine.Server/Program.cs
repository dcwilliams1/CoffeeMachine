using CoffeeMachine.Server.Domain.Interfaces;
using CoffeeMachine.Server.Domain.Services;
using CoffeeMachine.Server.Domain.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ICoffeeMachine, StandardMachine>();
builder.Services.AddTransient<ICoffeeMachine, GrindingMachine>();
builder.Services.AddSingleton<IMachineFactoryService, MachineFactoryService>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
