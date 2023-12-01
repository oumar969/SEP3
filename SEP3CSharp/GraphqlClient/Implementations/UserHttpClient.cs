using System.Text.Json;
using Domain.DTOs;
using Domain.Models;
using GraphQL;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using HttpClients.ClientInterfaces;

namespace HttpClients.Implementations;

public class UserHttpClient : IUserService
{
    private readonly HttpClient client;
    private readonly IGraphQLClient graphqlClient;

    public UserHttpClient(HttpClient client)
    {
        this.client = client;
        graphqlClient = new GraphQLHttpClient(ClientOptions.serverUrl, new NewtonsoftJsonSerializer());
    }

    public async Task<IEnumerable<User>> GetUsers(string? usernameContains = null)
    {
        var uri = "/users";
        if (!string.IsNullOrEmpty(usernameContains)) uri += $"?username={usernameContains}";
        var response = await client.GetAsync(uri);
        var result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode) throw new Exception(result);

        Console.WriteLine(result);
        var users = JsonSerializer.Deserialize<IEnumerable<User>>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return users;
    }

    public async Task DeleteUser(string id)
    {
        var response = await client.DeleteAsync($"user/{id}");
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode) throw new Exception(content);
    }

    public async Task<string> Create(UserCreationDto dto)
    {
        var createUserMutation = new GraphQLRequest
        {
            Query = @"
                mutation ($firstName: String!, $lastName: String!, $email: String!, $password: String!, $isLibrarian: Boolean!) {
                   createUser(firstName: $firstName, lastName: $lastName, email: $email, password: $password, isLibrarian: $isLibrarian) {
                         firstName
                         lastName
                         email
                      }
                }",
            Variables = new
            {
                firstName = dto.FirstName,
                lastName = dto.LastName,
                email = dto.Email,
                password = dto.Password,
                isLibrarian = dto.IsLibrarian
            }
        };
        var response = await graphqlClient.SendMutationAsync<Data>(createUserMutation);
        var resultMsg = "ok";

        if (response.Errors != null && response.Errors.Length > 0)
            resultMsg = "Error: " + string.Join(", ", response.Errors.Select(e => e.Message));
        return resultMsg;
    }

    private class Data
    {
        public User CreateUser { get; set; }
    }
}