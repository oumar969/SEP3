using System.Net.Http.Json;
using Domain.DTOs;
using Domain.Models;
using HttpClients.ClientInterfaces;
using GraphQL;
using GraphQL.Client.Abstractions;
using System.Text.Json;

namespace HttpClients.Implementations;

public class BookGraphqlClient : IBookService
{
    private readonly IGraphQLClient graphqlClient;

    public BookGraphqlClient(IGraphQLClient graphqlClient)
    {
        this.graphqlClient = graphqlClient;
    }

    public async Task<string> CreateAsync(BookRegistryCreationDto dto)
    {
        var createBookMutation = new GraphQLRequest
        {
            Query = @"
                mutation ($title: String!, $author: String!, $isbn: String!, $genre: String!, $description: String!) {
                    createBook(title: $title, author: $author, isbn: $isbn, genre: $genre, description: $description) {
                        title
                        author
                        isbn
                        genre
                        description
                    }
                }",
            Variables = new
            {
                title = dto.Title,
                author = dto.Author,
                isbn = dto.Isbn,
                genre = dto.Genre,
                description = dto.Description
            }
        };
        var response = await graphqlClient.SendMutationAsync<BookGraphqlDto>(createBookMutation);
        
        if (response.Errors != null && response.Errors.Length > 0)
            return "Error: " + string.Join(", ", response.Errors.Select(e => e.Message));
        return "ok";
    }

    public Task<ICollection<Book>> GetAsync(string? userName, int? userId, string? titleContains, string? authorContains, string? isbnContains,
        string? genreContains, string? descriptionContains)
    {
        throw new NotImplementedException();
    }

    Task IBookService.UpdateAsync(BookUpdateDto dto)
    {
        return UpdateAsync(dto);
    }

    Task<BookRegistry> IBookService.GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    Task IBookService.DeleteAsync(int id)
    {
        return DeleteAsync(id);
    }

    public Task<IEnumerable<Book>> GetAsync(string? titleContains = null, string? authorContains = null, string? isbnContains = null,
        string? genreContains = null)
    {
        throw new NotImplementedException();
    }

    Task IBookService.CreateAsync(BookRegistryCreationDto dto)
    {
        return CreateAsync(dto);
    }

    public Task<string> UpdateAsync(BookUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<Book> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<string> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    // Implement other methods similarly...

    private class BookGraphqlDto
    {
        public Book CreateBook { get; set; }
        public Book UpdateBook { get; set; }
    }
}