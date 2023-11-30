using System.Net.Http.Json;
using System.Text;
using Domain.DTOs;
using Domain.Models;
using HttpClients.ClientInterfaces;
using BookRegistry = Domain.DTOs.BookRegistry;

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

    public Task<ICollection<Book>> GetAsync(string? userName, int? userId, bool? completedStatus, string? titleContains)
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

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}