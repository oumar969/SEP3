using System.Text;





using Application.DaoInterfaces;
using Application.Logic;
using Application.LogicInterfaces;
using Domain.Auth;
using Domain.Models;
using FileData;
using JavaPersistenceClient.DAOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using WebAPI.Schema;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserDao, UserDao>();
builder.Services.AddScoped<IBookRegistryDao, BookRegistryDao>();
builder.Services.AddScoped<IGenericDao<User>, UserDao>();
builder.Services.AddScoped<IUserLogic, UserLogic>();
builder.Services.AddScoped<IGenericDao<BookRegistry>, BookRegistryDao>();

builder.Services.AddScoped<IBookRegistryLogic, BookRegistryLogic>();
//builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services
    .AddGraphQLServer().AddQueryType<UserQuery>().AddMutationType<UserMutation>();


AuthorizationPolicies.AddPolicies(builder.Services);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.UseAuthentication();

// Add GraphQL endpoint
app.MapGraphQL();

app.UseGraphQLPlayground();
//app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());


app.Run();

