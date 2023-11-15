using System.Text;
using Application.DaoInterfaces;
using Domain.DTOs;
using Domain.Models;
using Newtonsoft.Json;

namespace JavaPersistenceClient.DAOs;

public class BookRegistryDao : IBookRegistryDao
{
    private readonly HttpClient _httpClient;

    public BookRegistryDao()
    {
        _httpClient = new HttpClient();
    }

    public Task<BookRegistry> UpdateAsync(BookRegistry entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(string uuid)
    {
        throw new NotImplementedException();
    }

    public async Task<BookRegistry> CreateAsync(BookRegistry entity)
    {
        var jsonContent = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
        Console.WriteLine("JSON: " + JsonConvert.SerializeObject(entity));
        Console.WriteLine("jsonContent11: " + jsonContent);
        var response = await _httpClient.PostAsync("http://localhost:8080/book_registry/register", jsonContent);
        Console.WriteLine("response: " + response);
        if (!response.IsSuccessStatusCode)
            throw new Exception($"Error creating bookRegistry: {JsonConvert.SerializeObject(response)}");

        var jsonResponse = await response.Content.ReadAsStringAsync();
        Console.WriteLine(jsonResponse);
        return JsonConvert.DeserializeObject<BookRegistry>(jsonResponse);
    }

    public Task<BookRegistry> GetByUuidAsync(string uuid)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<BookRegistry>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<BookRegistry> GetAsync(SearchBookRegistryParametersDto searchParameters)
    {
        throw new NotImplementedException();
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