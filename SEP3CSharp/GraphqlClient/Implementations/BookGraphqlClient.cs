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

    public async Task<BookCreationDto> CreateAsync(BookCreationDto dto)
    {
        var createBookMutation = new GraphQLRequest
        {
            Query = @"
                mutation ($isbn: String!) {
                    createBook(isbn: $isbn) {
                        uuid
                        isbn
                        loanerUuid
                    }
                }",
            Variables = new
            {
                isbn = dto.Isbn,
            }
        };
        var response = await graphqlClient.SendMutationAsync<CreateBookResponse>(createBookMutation);
        Console.WriteLine(response.Data?.CreateBook);
        if (response.Errors != null && response.Errors.Length > 0)
            throw new Exception("Error: " + string.Join(", ", response.Errors.Select(e => e.Message)));
        return response.Data?.CreateBook;
    }

    public Task<ICollection<Book>> GetAsync(string? userName, int? userId, string? titleContains,
        string? authorContains, string? isbnContains,
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

    public Task<IEnumerable<Book>> GetAsync(string? titleContains = null, string? authorContains = null,
        string? isbnContains = null,
        string? genreContains = null)
    {
        throw new NotImplementedException();
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

    public async Task<string> LoanBook(Book book, User user)
    {
        var loanBookMutation = new GraphQLRequest
        {
            Query = @"
                mutation ($bookId: Int!, $userId: Int!) {
                    loanBook(bookId: $bookId, userId: $userId) {
                        title
                        author
                        isbn
                        genre
                        description
                        loanedTo {
                            firstName
                            lastName
                            email
                        }
                    }
                }",
            Variables = new
            {
                bookId = book.UUID,
                userId = user.UUID
            }
        };
        var response = await graphqlClient.SendMutationAsync<LoanBookResponse>(loanBookMutation);
        var resultMsg = "ok";

        if (response.Errors != null && response.Errors.Length > 0)
            resultMsg = "Error: " + string.Join(", ", response.Errors.Select(e => e.Message));

        return resultMsg;
    }

    private class LoanBookResponse
    {
        public Book LoanBook { get; set; }
    }

    private class CreateBookResponse
    {
        public BookCreationDto CreateBook { get; set; }
    }
}