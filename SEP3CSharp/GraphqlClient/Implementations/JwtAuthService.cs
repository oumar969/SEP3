using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Domain.DTOs;
using Domain.Models;
using GraphQL;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using HttpClients.ClientInterfaces;

namespace HttpClients.Implementations;

public class JwtAuthService : IAuthService
{
    private readonly HttpClient client = new();
    private readonly IGraphQLClient graphqlClient;

    public JwtAuthService()
    {
        client.DefaultRequestHeaders.Add("Accept", "application/json");
        graphqlClient = new GraphQLHttpClient(ClientOptions.serverUrl, new NewtonsoftJsonSerializer());
    }

    public static string? Jwt { get; private set; } = "";

    public async Task RegisterAsync(User user)
    {
        var userAsJson = JsonSerializer.Serialize(user);
        StringContent content = new(userAsJson, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("https://localhost:7130/auth/register", content);
        var responseContent = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode) throw new Exception(responseContent);
    }

    public Task<ClaimsPrincipal> GetAuthAsync()
    {
        var principal = CreateClaimsPrincipal();
        return Task.FromResult(principal);
    }

    public Action<ClaimsPrincipal> OnAuthStateChanged { get; set; } = null!;


    public Task LogoutAsync()
    {
        Jwt = null;
        ClaimsPrincipal principal = new(new ClaimsIdentity());
        OnAuthStateChanged?.Invoke(principal);
        return Task.CompletedTask;
    }

    public async Task<UserLoginDto> LoginAsync(UserLoginDto dto)
    {
        Console.WriteLine("here1");
        var loginMutation = new GraphQLRequest
        {
            Query = @"
            mutation ($email: String!, $password: String!) {
                login(email: $email, password: $password) {
                    email
                    password
                    token
                    success
                    errMsg
                }
            }",
            Variables = new
            {
                email = dto.Email,
                password = dto.Password
            }
        };
        Console.WriteLine("here2");
        var response = await graphqlClient.SendMutationAsync<AuthUserResponse>(loginMutation);
        Console.WriteLine("here3");
        Console.WriteLine("response.Data 0: " + response.Data);
        Console.WriteLine("response.Data 1: " + response.Data?.Login.ToString());
        Console.WriteLine("response.Data 2 : " + response.Data?.Login?.Token);
        Console.WriteLine("response.Data 3 : " + response.Data?.Login?.Success);
        Console.WriteLine("response.Data 4 : " + response.Data?.Login?.ErrMsg);
        if (response.Errors != null && response.Errors.Length > 0)
            return response.Data?.Login;

        Jwt = response.Data?.Login?.Token;

        ClaimsPrincipal principal = CreateClaimsPrincipal();
        OnAuthStateChanged?.Invoke(principal);

        return response.Data?.Login;
    }

    private static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
    {
        var payload = jwt.Split('.')[1];
        var jsonBytes = ParseBase64WithoutPadding(payload);
        var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
        return keyValuePairs!.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()!));
    }

    private static byte[] ParseBase64WithoutPadding(string base64)
    {
        switch (base64.Length % 4)
        {
            case 2:
                base64 += "==";
                break;
            case 3:
                base64 += "=";
                break;
        }

        return Convert.FromBase64String(base64);
    }

    private static ClaimsPrincipal CreateClaimsPrincipal()
    {
        if (string.IsNullOrEmpty(Jwt)) return new ClaimsPrincipal();

        var claims = ParseClaimsFromJwt(Jwt);

        ClaimsIdentity identity = new(claims, "jwt");

        ClaimsPrincipal principal = new(identity);
        return principal;
    }

    private class AuthUserResponse
    {
        public UserLoginDto Login { get; set; }
    }
}