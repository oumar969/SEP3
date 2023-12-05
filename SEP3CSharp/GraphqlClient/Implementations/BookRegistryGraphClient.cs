using System.Text.Json;
using Domain.DTOs;
using Domain.Models;
using GraphQL;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using HttpClients.ClientInterfaces;

namespace HttpClients.Implementations;

public class BookRegistryGraphClient : IBookRegistryService
{
    private readonly HttpClient client;
    private readonly IGraphQLClient graphqlClient;

    public BookRegistryGraphClient(HttpClient client)
    {
        this.client = client;
        graphqlClient = new GraphQLHttpClient(ClientOptions.serverUrl, new NewtonsoftJsonSerializer());
    }
    
    public async Task<string> Create(BookRegistryCreationDto dto)
    {
        var createBookRegistryMutation = new GraphQLRequest
        {
            Query = @"
            mutation CreateBookRegistry($title: String!, $author: String!, $genre: String!, $isbn: String!, $description: String!) {
                createBookRegistry(title: $title, author: $author, genre: $genre, isbn: $isbn, description: $description) {
                    title
                    author
                    genre
                    isbn
                    description
                }
            }",
            Variables = new
            {
                title = dto.Title,
                author = dto.Author,
                genre = dto.Genre,
                isbn = dto.Isbn,
                description = dto.Description
            }
        };
        
        var response = await graphqlClient.SendMutationAsync<BookRegistryCreationDto>(createBookRegistryMutation);
        var resultMsg = "ok";

        if (response.Errors != null && response.Errors.Length > 0)
            resultMsg = "Error: " + string.Join(", ", response.Errors.Select(e => e.Message));
        return resultMsg;
    }

    
}