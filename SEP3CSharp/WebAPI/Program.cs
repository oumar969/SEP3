using System.Text;
using Application.DaoInterfaces;
using Application.DAOInterfaces;
using Application.Logic;
using Application.LogicInterfaces;
using Domain.Auth;
using JavaPersistenceClient.DAOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using WebAPI.Queries;
using WebApi.Services;
using WebAPI.Mutations;
using WebAPI.Schema;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddHttpClient();
builder.Services.AddScoped<IUserDao, UserDao>();

builder.Services.AddScoped<IBookRegistryDao, BookRegistryDao>();
builder.Services.AddScoped<IBookDao, BookDao>();
builder.Services.AddScoped<IUserLogic, UserLogic>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IBookRegistryLogic, BookRegistryLogic>();
builder.Services.AddScoped<IBookLogic, BookLogic>();

builder.Services
    .AddGraphQLServer().AddQueryType<Query>().AddType<UserQuery>().AddType<BookQuery>().AddType<BookRegistryQuery>()
    .AddMutationType<Mutation>()
    .AddType<BookMutation>().AddType<BookRegistryMutation>().AddType<UserMutation>();


AuthorizationPolicies.AddPolicies(builder.Services);


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

var app = builder.Build();

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) 
    .AllowCredentials());

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.UseAuthentication();

app.MapGraphQL();

app.UseGraphQLPlayground();


app.Run();