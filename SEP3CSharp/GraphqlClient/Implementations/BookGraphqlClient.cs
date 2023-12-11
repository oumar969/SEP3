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
                        isSuccessful
                        message
                    }
                }",
            Variables = new
            {
                isbn = dto.Isbn,
            }
        };
        var response = await graphqlClient.SendMutationAsync<CreateBookResponse>(createBookMutation);
        Console.WriteLine("book created: " + response.Data?.CreateBook);
        Console.WriteLine("book created is suc: " + response.Data?.CreateBook.IsSuccessful);
        if (response.Errors != null && response.Errors.Length > 0)
            throw new Exception("Error: " + string.Join(", ", response.Errors.Select(e => e.Message)));
        return response.Data?.CreateBook;
    }

    public async Task<ICollection<Book>> GetAllBooksAsync(string isbn)
    {
        var graphQlRequest = new GraphQLRequest
        {
            Query = @"
            query ($isbn: String!) {
                allBooks (isbn: $isbn) {
                    uuid
                    isbn
                    loanerUuid
                }
            }",
            Variables = new
            {
                isbn = isbn
            }
        };

        var response = await graphqlClient.SendMutationAsync<GetAllBooksResponse>(graphQlRequest);
        Console.WriteLine("Res all books: " + response.Data?.AllBooks);
        Console.WriteLine("Res all books count: " + response.Data?.AllBooks.Count());

        if (response.Errors != null && response.Errors.Length > 0)
            throw new Exception("Error: " + string.Join(", ", response.Errors.Select(e => e.Message)));
        return response.Data?.AllBooks;
    }

    public Task<ICollection<Book>> GetAsync(string? userName, int? userId, string? titleContains,
        string? authorContains, string? isbnContains,
        string? genreContains, string? descriptionContains)
    {
        throw new NotImplementedException();
    }

    public async Task<BookDeleteDto> DeleteAsync(BookDeleteDto dto)
    {
        var loanBookMutation = new GraphQLRequest
        {
            Query = @"
                mutation ($uuid: String!, $isbn: String!, $loanerUuid: String!) {
                    deleteBook(uuid: $uuid, isbn: $isbn, loanerUuid: $loanerUuid) {
                        uuid
                        isbn
                        loanerUuid
                        isSuccessful
                        message
                    }
                }",
            Variables = new
            {
                uuid = dto.Uuid,
                isbn = dto.LoanerUuid,
                loanerUuid = dto.LoanerUuid
            }
        };
        var response = await graphqlClient.SendMutationAsync<DeleteBookResponse>(loanBookMutation);
        Console.WriteLine("book deleted: " + response.Data?.DeleteBook.IsSuccessful);
        Console.WriteLine("book deleted: " + response.Data?.DeleteBook.Message);

        if (response.Errors != null && response.Errors.Length > 0)
            throw new Exception("Error: " + string.Join(", ", response.Errors.Select(e => e.Message)));

        return response.Data?.DeleteBook;
    }

    public async Task<BookUpdateDto> UpdateBook(BookUpdateDto dto)
    {
        var loanBookMutation = new GraphQLRequest
        {
            Query = @"
                mutation ($uuid: String!, $isbn: String!, $loanerUuid: String!) {
                    updateBook(uuid: $uuid, isbn: $isbn, loanerUuid: $loanerUuid) {
                        uuid
                        isbn
                        loanerUuid
                        isSuccessful
                        message
                    }
                }",
            Variables = new
            {
                uuid = dto.Uuid,
                isbn = dto.Isbn,
                loanerUuid = dto.LoanerUuid
            }
        };
        
        var response = await graphqlClient.SendMutationAsync<UpdateBookResponse>(loanBookMutation);
        Console.WriteLine("book loaned: " + response.Data?.UpdateBook.IsSuccessful);
        Console.WriteLine("book loaned: " + response.Data?.UpdateBook.Message);

        if (response.Errors != null && response.Errors.Length > 0)
            throw new Exception("Error: " + string.Join(", ", response.Errors.Select(e => e.Message)));

        return response.Data?.UpdateBook;
    }

    private class UpdateBookResponse
    {
        public BookUpdateDto UpdateBook { get; set; }
    }

    private class CreateBookResponse
    {
        public BookCreationDto CreateBook { get; set; }
    }

    private class GetAllBooksResponse
    {
        public ICollection<Book> AllBooks { get; set; }
    }

    private class DeleteBookResponse
    {
        public BookDeleteDto DeleteBook { get; set; }
    }
}