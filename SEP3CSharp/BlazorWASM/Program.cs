using BlazorWasm.Auth;
using Domain.Auth;
using HttpClients.ClientInterfaces;
using HttpClients.Implementations;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddScoped<IAuthService, JwtAuthService>();
builder.Services.AddScoped<IUserService, UserHttpClient>();
builder.Services.AddScoped<IBookService, BookHttpClient>();

builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthProvider>();
builder.Services.AddScoped<CascadingAuthenticationState>();

builder.Logging.AddConsole();
builder.Logging.AddDebug();

AuthorizationPolicies.AddPolicies(builder.Services);

builder.Services.AddScoped(
    sp =>
        new HttpClient
        {
            BaseAddress = new Uri("https://localhost:5125")
        }
);
var client = new HttpClient
{
    BaseAddress = new Uri("https://localhost:5125")
};

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
    app.UseHttpsRedirection();
}


app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();