using Application.Logic;
using Application.LogicInterfaces;
using Domain.Models;
using FileData;
using JavaPersistenceClient.DAOs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IGenericDao<User>, UserDao>();
builder.Services.AddScoped<IUserLogic, UserLogic>();
builder.Services.AddScoped<IGenericDao<BookRegistry>, BookRegistryDao>();
builder.Services.AddScoped<IBookRegistryLogic, BookRegistryLogic>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseAuthentication();

app.Run();