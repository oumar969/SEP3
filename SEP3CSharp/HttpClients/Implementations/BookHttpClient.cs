using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
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

    public async Task<ICollection<Book>> GetAsync(string? userName, int? userId, bool? reservedStatus, string? titleContains, string? authorContains,
        string? isbnContains, string? genreContains, string? descriptionContains, string? locationContains)
    {
        string query = ConstructQuery(userName, userId, titleContains, reservedStatus, authorContains, isbnContains, genreContains, descriptionContains, locationContains);

        HttpResponseMessage response = await client.GetAsync("/books"+query);
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        ICollection<Book> books = JsonSerializer.Deserialize<ICollection<Book>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return books;
    }


    public async Task UpdateAsync(BookUpdateDto dto)
    {
        string dtoAsJson = JsonSerializer.Serialize(dto);
        StringContent body = new StringContent(dtoAsJson, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await client.PatchAsync("/books", body);
        if (!response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
    }

    public async Task<BookBasicDto> GetByIdAsync(int id)
    {
        HttpResponseMessage response = await client.GetAsync($"/books/{id}");
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        BookBasicDto book = JsonSerializer.Deserialize<BookBasicDto>(content, 
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }
        )!;
        return book;
        
    }

    public async Task DeleteAsync(int id)
    {
        HttpResponseMessage response = await client.DeleteAsync($"Books/{id}");
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }
    }
    
    private static string ConstructQuery(string? userName, int? userId, string? titleContains, bool? reservedStatus,
        string? authorContains, string? isbnContains, string? genreContains, string? descriptionContains, string? locationContains)
    {
        var queryParameters = new List<string>();

        if (!string.IsNullOrEmpty(userName))
        {
            queryParameters.Add($"username={Uri.EscapeDataString(userName)}");
        }

        if (userId.HasValue)
        {
            queryParameters.Add($"userid={userId.Value}");
        }

        if (!string.IsNullOrEmpty(titleContains))
        {
            queryParameters.Add($"titlecontains={Uri.EscapeDataString(titleContains)}");
        }

        if (reservedStatus.HasValue)
        {
            queryParameters.Add($"reservedstatus={reservedStatus.Value}");
        }

        if (!string.IsNullOrEmpty(authorContains))
        {
            queryParameters.Add($"authorcontains={Uri.EscapeDataString(authorContains)}");
        }

        if (!string.IsNullOrEmpty(isbnContains))
        {
            queryParameters.Add($"isbncontains={Uri.EscapeDataString(isbnContains)}");
        }

        if (!string.IsNullOrEmpty(genreContains))
        {
            queryParameters.Add($"genrecontains={Uri.EscapeDataString(genreContains)}");
        }

        if (!string.IsNullOrEmpty(descriptionContains))
        {
            queryParameters.Add($"descriptioncontains={Uri.EscapeDataString(descriptionContains)}");
        }

        if (!string.IsNullOrEmpty(locationContains))
        {
            queryParameters.Add($"locationcontains={Uri.EscapeDataString(locationContains)}");
        }

        return queryParameters.Any() ? "?" + string.Join("&", queryParameters) : "";
    }

}