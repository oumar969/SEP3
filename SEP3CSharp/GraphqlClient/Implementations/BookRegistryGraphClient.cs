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

    public async Task<BookRegistryCreationDto> Create(BookRegistryCreationDto dto)
    {
        var createBookRegistryMutation = new GraphQLRequest
        {
            Query = @"
            mutation ($title: String!, $author: String!, $genre: String!, $isbn: String!, $description: String!) {
                createBookRegistry(title: $title, author: $author, genre: $genre, isbn: $isbn, description: $description) {
                    title
                    author
                    genre
                    isbn
                    description
                    isSuccessful
                    message
                }
            }",
            Variables = new
            {
                title = dto.Title,
                author = dto.Author,
                genre = dto.Genre,
                isbn = dto.Isbn,
                description = dto.Description
            } //test
        };

        var response = await graphqlClient.SendMutationAsync<CreateBookRegistryRespnse>(createBookRegistryMutation);
        Console.WriteLine("Res gg1: " + response.Data?.CreateBookRegistry);
        Console.WriteLine("Res gg2: " + response.Data?.CreateBookRegistry.IsSuccessful);
        Console.WriteLine("Res gg3: " + response.Data?.CreateBookRegistry.Message);

        if (response.Errors != null && response.Errors.Length > 0)
            throw new Exception("Error: " + string.Join(", ", response.Errors.Select(e => e.Message)));
        return response.Data?.CreateBookRegistry;
    }

    public async Task<IEnumerable<BookRegistry>> GetBookRegistries()
    {
        var graphQlRequest = new GraphQLRequest
        {
            Query = @"
            query {
                allBookRegistries {
                    isbn
                    title
                    author
                    genre
                    description
                    reviews
                }
            }"
        };
        Console.WriteLine("here res 11");
        var response = await graphqlClient.SendMutationAsync<GetBookRegistriesRespnse>(graphQlRequest);
        Console.WriteLine("Res: " + response.Data?.AllBookRegistries);

        if (response.Errors != null && response.Errors.Length > 0)
            throw new Exception("Error: " + string.Join(", ", response.Errors.Select(e => e.Message)));
        return response.Data?.AllBookRegistries;
    }

    private class GetBookRegistriesRespnse
    {
        public IEnumerable<BookRegistry> AllBookRegistries { get; set; }
    }

    private class CreateBookRegistryRespnse
    {
        public BookRegistryCreationDto CreateBookRegistry { get; set; }
    }
}