using System.Text;
using Application.DaoInterfaces;
using Domain.DTOs;
using Domain.Models;
using FileData;
using Newtonsoft.Json;

namespace JavaPersistenceClient.DAOs;

public class BookRegistryDao : IBookRegistryDao
{
    private readonly HttpClient _httpClient;

    public BookRegistryDao()
    {
        _httpClient = new HttpClient();
    }

    async Task<BookRegistry> IGenericDao<BookRegistry>.CreateAsync(BookRegistry entity)
    {
        var jsonContent = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
        Console.WriteLine("JSON: " + JsonConvert.SerializeObject(entity));
        Console.WriteLine("jsonContent11: " + jsonContent);
        var response = await _httpClient.PostAsync("http://localhost:7777/book-registry/create", jsonContent);
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

    public async Task<ICollection<BookRegistry>> GetAllAsync()
    {
        var url = $"{ServerOptions.serverUrl}/book-registry/get/all";

        var response = await _httpClient.GetAsync(url);

        Console.WriteLine($"GET request to {url}");
        Console.WriteLine($"Response status code: {response.StatusCode}");
        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"JSON Response: {jsonResponse}");

            return JsonConvert.DeserializeObject<List<BookRegistry>>(jsonResponse);
        }

        var errorResponse = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"Error Response: {errorResponse}");

        throw new Exception($"Error getting all book registries. Status code: {response.StatusCode}");
    }

    public Task<ICollection<Book>> GetAsync(ISearchParametersDto searchParameters)
    {
        throw new NotImplementedException();
    }

    public Task<BookRegistry> UpdateAsync(BookRegistry entity)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(string uuid)
    {
        var url = $"{ServerOptions.serverUrl}/books/delete/{uuid}";

        var response = await _httpClient.DeleteAsync(url);

        Console.WriteLine($"DELETE request to {url}");
        Console.WriteLine($"Response status code: {response.StatusCode}");

        if (response.IsSuccessStatusCode)
            return;

        var errorResponse = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"Error Response: {errorResponse}");

        throw new Exception($"Error deleting book registry. Status code: {response.StatusCode}");
    }

    public async Task<BookRegistry> GetByBookTitleAsync(string title)
    {
        var url = $"{ServerOptions.serverUrl}/book/getByTitle/{title}";

        var response = await _httpClient.GetAsync(url);

        Console.WriteLine($"GET request to {url}");
        Console.WriteLine($"Response status code: {response.StatusCode}");
        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"JSON Response: {jsonResponse}");

            return JsonConvert.DeserializeObject<BookRegistry>(jsonResponse);
        }

        var errorResponse = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"Error Response: {errorResponse}");

        throw new Exception($"Error getting user by UUID. Status code: {response.StatusCode}");
    }

    public async Task<BookRegistry> GetByIsbnAsync(string isbn)
    {
        var url = $"{ServerOptions.serverUrl}/book/getByIsbn/{isbn}";

        var response = await _httpClient.GetAsync(url);

        Console.WriteLine($"GET request to {url}");
        Console.WriteLine($"Response status code: {response.StatusCode}");
        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"JSON Response: {jsonResponse}");

            return JsonConvert.DeserializeObject<BookRegistry>(jsonResponse);
        }

        var errorResponse = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"Error Response: {errorResponse}");

        throw new Exception($"Error getting user by UUID. Status code: {response.StatusCode}");
    }

    public Task<Book?> GetByIdAsync(int bookId)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<BookRegistry>> GetAllBookRegistriesAsync()
    {
        throw new NotImplementedException();
    }

    private async Task<BookRegistry> CreateAsync(BookRegistry entity)
    {
        var jsonContent = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
        Console.WriteLine("JSON: " + JsonConvert.SerializeObject(entity));
        Console.WriteLine("jsonContent11: " + jsonContent);
        var response = await _httpClient.PostAsync("http://localhost:7777/book_registry/register", jsonContent);
        Console.WriteLine("response: " + response);
        if (!response.IsSuccessStatusCode)
            throw new Exception($"Error creating bookRegistry: {JsonConvert.SerializeObject(response)}");

        var jsonResponse = await response.Content.ReadAsStringAsync();
        Console.WriteLine(jsonResponse);
        return JsonConvert.DeserializeObject<BookRegistry>(jsonResponse);
    }
}