using BlazorWasm.Auth;
using BlazorWASM.Services;
using Domain.Auth;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using HttpClients.ClientInterfaces;
using HttpClients.Implementations;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient<IUserService, UserGraphqlClient>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5125"); 
});

builder.Services.AddHttpClient<IBookRegistryService, BookRegistryGraphClient>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5125");
});

builder.Services.AddScoped<IAuthService, JwtAuthService>();
builder.Services.AddScoped<IBookService, BookGraphqlClient>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthProvider>();
builder.Services.AddScoped<CascadingAuthenticationState>();
builder.Services.AddScoped<BookStateService>();

AuthorizationPolicies.AddPolicies(builder.Services);

builder.Services.AddScoped<IGraphQLClient>(s =>
    new GraphQLHttpClient("http://localhost:5125/graphql", new NewtonsoftJsonSerializer()));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();