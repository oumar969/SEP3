using BlazorWasm.Auth;
using Domain.Auth;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using HttpClients.ClientInterfaces;
using HttpClients.Implementations;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient<IUserService, UserGraphqlClient>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5125"); // Replace with your actual API base URL
});

builder.Services.AddHttpClient<IBookRegistryService, BookRegistryGraphClient>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5125"); // Replace with your actual API base URL
});

builder.Services.AddScoped<IAuthService, JwtAuthService>();
// builder.Services.AddScoped<IUserService, UserHttpClient>();
builder.Services.AddScoped<IBookService, BookGraphqlClient>();

builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthProvider>();
builder.Services.AddScoped<CascadingAuthenticationState>();
AuthorizationPolicies.AddPolicies(builder.Services);

builder.Services.AddScoped<IGraphQLClient>(s =>
    new GraphQLHttpClient("http://localhost:5125/graphql", new NewtonsoftJsonSerializer()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();