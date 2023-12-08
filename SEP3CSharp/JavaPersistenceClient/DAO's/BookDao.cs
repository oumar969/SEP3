using System.Text;
using Application.DAOInterfaces;
using Domain.DTOs;
using Domain.Models;
using FileData;
using Newtonsoft.Json;
using System.Net.Http;


namespace JavaPersistenceClient.DAOs;

public class BookDao : IBookDao
{
    private HttpClient _httpClient;
    private readonly IHttpClientFactory _httpClientFactory;

    public BookDao(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
        _httpClient = _httpClientFactory.CreateClient();
    }

    public async Task<BookCreationDto> CreateAsync(BookCreationDto dto)
    {
        try
        {
            Console.WriteLine("njdsj");
            Book book = new Book(dto.Isbn, dto.Uuid, dto.LoanerUuid);
            var jsonContent = new StringContent(JsonConvert.SerializeObject(book), Encoding.UTF8, "application/json");
            Console.WriteLine("JSON: " + book.Isbn);
            Console.WriteLine("JSON: " + book.UUID);
            Console.WriteLine("jsonContent: " + await jsonContent.ReadAsStringAsync());
            Console.WriteLine("JSON: " + JsonConvert.SerializeObject(book));
            var response = await _httpClient.PostAsync("http://localhost:7777/book/create", jsonContent);
            Console.WriteLine("response: " + response);
            if (response.IsSuccessStatusCode)
            {
                dto.IsSuccessful = true;
                dto.Message = "Bog blev oprettet";
            }
            else
            {
                dto.IsSuccessful = false;
                dto.Message = "Bog blev ikke oprettet";
            }


            return dto;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Task<Book> CreateAsync(Book entity)
    {
        throw new NotImplementedException();
    }

    public Task<Book> GetByUuidAsync(string uuid)
    {
        throw new NotImplementedException();
    }

    public async Task<ICollection<Book>> GetAllAsync(string isbn)
    {
        var url = $"{ServerOptions.serverUrl}/book/get/all/{isbn}";

        var response = await _httpClient.GetAsync(url);

        Console.WriteLine($"GET request to {url}");
        Console.WriteLine($"Response status code: {response.StatusCode}");
        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"JSON Response: {jsonResponse}");

            return JsonConvert.DeserializeObject<ICollection<Book>>(jsonResponse);
        }

        var errorResponse = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"Error Response: {errorResponse}");

        throw new Exception($"Error getting all book registries. Status code: {response.StatusCode}");
    }

    public Task<ICollection<Book>> GetAsync(ISearchParametersDto searchParameters)
    {
        throw new NotImplementedException();
    }

    public async Task<BookDeleteDto> DeleteAsync(BookDeleteDto dto)
    {
        Console.WriteLine("delete book dao");
        var url = $"{ServerOptions.serverUrl}/book/delete/by-uuid/{dto.Uuid}";

        var response = await _httpClient.DeleteAsync(url);

        Console.WriteLine($"DELETE request to {url}");
        Console.WriteLine($"Response status code: {response.StatusCode}");

        if (response.IsSuccessStatusCode)
        {
            dto.IsSuccessful = true;
            dto.Message = "Bog blev slettet";
            return dto;
        }
        else
        {
            dto.IsSuccessful = false;
            dto.Message = "Bog blev ikke slettet";
            return dto;
        }
    }


    public async Task<BookUpdateDto> UpdateAsync(BookUpdateDto dto)
    {
        Book book = new Book(dto.Isbn, dto.Uuid, dto.LoanerUuid);
        var jsonContent = new StringContent(JsonConvert.SerializeObject(book), Encoding.UTF8, "application/json");
        Console.WriteLine("JSON: " + JsonConvert.SerializeObject(book));
        Console.WriteLine("jsonContent11: " + jsonContent);
        var response = await _httpClient.PutAsync("http://localhost:7777/book/update/" + dto.Uuid, jsonContent);
        Console.WriteLine("response: " + response);
        if (response.IsSuccessStatusCode)
        {
            dto.IsSuccessful = true;
            dto.Message = "Bog blev lånt";
        }
        else
        {
            dto.IsSuccessful = false;
            dto.Message = "Bog blev ikke lånt";
        }

        return dto;
    }
}