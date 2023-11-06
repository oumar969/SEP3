using System.Text;
using Application.DaoInterfaces;
using Domain.DTOs;
using Domain.Models;
using Newtonsoft.Json;

namespace JavaPersistenceClient.DAOs;

public class BookRegistryDao : IBookRegistryDao
{
    private readonly HttpClient _httpClient;

    public Task<BookRegistry> UpdateAsync(BookRegistry entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(string uuid)
    {
        throw new NotImplementedException();
    }

    public Task<BookRegistry> CreateAsync(BookRegistry entity)
    {
        throw new NotImplementedException();
    }

    public Task<BookRegistry> GetByUuidAsync(string uuid)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<BookRegistry>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<BookRegistry>> GetAsync(ISearchParametersDto searchParameters)
    {
        throw new NotImplementedException();
    }

    public async Task<Book> CreateAsync(Book entity)
    {
        var jsonContent = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("http://localhost:8080/book/create", jsonContent);
        Console.WriteLine(response);
        if (!response.IsSuccessStatusCode) throw new Exception($"Error creating book: {response.StatusCode}");

        var jsonResponse = await response.Content.ReadAsStringAsync();
        Console.WriteLine(jsonResponse);
        return JsonConvert.DeserializeObject<Book>(jsonResponse);
    }

    public Task<Book> UpdateAsync(Book entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}