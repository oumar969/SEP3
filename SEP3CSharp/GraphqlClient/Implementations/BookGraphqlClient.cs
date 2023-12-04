using System.Net.Http.Json;
using Domain.DTOs;
using Domain.Models;
using HttpClients.ClientInterfaces;

namespace HttpClients.Implementations;

public class BookGraphqlClient : IBookService
{
    private readonly HttpClient client;

    public BookGraphqlClient(HttpClient client)
    {
        this.client = client;
    }

    public async Task CreateAsync(BookRegistryCreationDto dto)
    {
        var response = await client.PostAsJsonAsync("/books", dto);
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode) throw new Exception(content);
    }

    public Task<ICollection<Book>> GetAsync(string? userName, int? userId, string? titleContains,
        string? authorContains, string? isbnContains,
        string? genreContains, string? descriptionContains)
    {
        throw new NotImplementedException();
    }


    public async Task UpdateAsync(BookUpdateDto dto)
    {
    }

    public Task<BookRegistry> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        var response = await client.DeleteAsync($"books/{id}");
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode) throw new Exception(content);
    }
}