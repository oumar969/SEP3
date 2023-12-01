using System.Net.Http.Json;
using System.Text;
using Domain.DTOs;
using Domain.Models;
using HttpClients.ClientInterfaces;

namespace HttpClients.Implementations;

public class BookHttpClient : IBookService
{
    private readonly HttpClient client;

    public BookHttpClient(HttpClient client)
    {
        this.client = client;
    }
    
    public async Task CreateAsync(BookRegistryCreationDto dto)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/books",dto);
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }
        
    }

    public Task<ICollection<Book>> GetAsync(string? userName, int? userId, string? titleContains, string? authorContains, string? isbnContains,
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
        HttpResponseMessage response = await client.DeleteAsync($"books/{id}");
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }
    }
}