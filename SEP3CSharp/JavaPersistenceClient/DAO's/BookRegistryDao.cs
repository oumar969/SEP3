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

    public async Task<BookRegistryCreationDto> CreateAsync(BookRegistryCreationDto dto)
    {
        BookRegistry bookRegistry = new BookRegistry(
            dto.Title,
            dto.Author,
            dto.Genre,
            dto.Isbn,
            dto.Description,
            ""
        );

        var jsonContent =
            new StringContent(JsonConvert.SerializeObject(bookRegistry), Encoding.UTF8, "application/json");
        Console.WriteLine("JSON: " + JsonConvert.SerializeObject(bookRegistry));
        Console.WriteLine("jsonContent11: " + jsonContent);
        var response = await _httpClient.PostAsync("http://localhost:7777/book-registry/create", jsonContent);
        Console.WriteLine("response: " + response);
        if (response.IsSuccessStatusCode)
        {
            dto.IsSuccessful = true;
            dto.Message = "Bog registreret blev oprettet";
            return dto;
        }

        dto.IsSuccessful = false;
        dto.Message = "Bog registreret blev ikke oprettet";
        return dto;
    }

    public Task<BookRegistry> UpdateAsync(BookRegistryUpdateDto dto)
    {
        throw new NotImplementedException();
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

    public Task<ICollection<BookRegistry>> GetAsync(ISearchParametersDto searchParameters)
    {
        throw new NotImplementedException();
    }

    public Task<BookRegistry> UpdateAsync(BookRegistry entity)
    {
        throw new NotImplementedException();
    }

    public async Task<BookRegistryDeleteDto> DeleteAsync(BookRegistryDeleteDto dto)
    {
        var url = $"{ServerOptions.serverUrl}/book-registry/delete/{dto.Isbn}";

        var response = await _httpClient.DeleteAsync(url);

        Console.WriteLine($"DELETE request to {url}");
        Console.WriteLine($"Response status code: {response.StatusCode}");

        if (response.IsSuccessStatusCode)
        {
            dto.IsSuccessful = true;
            dto.Message = "Bog registreret blev slettet";
        }
        else
        {
            dto.IsSuccessful = false;
            dto.Message = "Bog registreret blev ikke slettet";
        }

        return dto;
    }


    public async Task<BookRegistry> GetByBookTitleAsync(string title)
    {
        var url = $"{ServerOptions.serverUrl}/book-registry/getByTitle/{title}";

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
        Console.WriteLine("get by isbn");
        var url = $"{ServerOptions.serverUrl}/book-registry/getByIsbn/{isbn}";

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
}