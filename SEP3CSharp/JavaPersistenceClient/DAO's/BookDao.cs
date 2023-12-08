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

    public async Task<BookCreationDto> CreateAsync(string isbn)
    {
        try
        {
            Console.WriteLine("njdsj");
            Book book = new Book(isbn, Guid.NewGuid().ToString(), "");
            var jsonContent = new StringContent(JsonConvert.SerializeObject(book), Encoding.UTF8, "application/json");
            Console.WriteLine("JSON: " + book.Isbn);
            Console.WriteLine("JSON: " + book.UUID);
            Console.WriteLine("jsonContent: " + await jsonContent.ReadAsStringAsync());
            Console.WriteLine("JSON: " + JsonConvert.SerializeObject(book));
            var response = await _httpClient.PostAsync("http://localhost:7777/book/create", jsonContent);
            Console.WriteLine("response: " + response);
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error creating bookRegistry: {JsonConvert.SerializeObject(response)}");
            var jsonResponse = await response.Content.ReadAsStringAsync();
            Console.WriteLine(jsonResponse);
            BookCreationDto bookCreationDto = JsonConvert.DeserializeObject<BookCreationDto>(jsonResponse);

            if (response.IsSuccessStatusCode)
            {
                bookCreationDto.IsSuccesful = true;
                bookCreationDto.Message = "Bog blev oprettet";
            }
            else
            {
                bookCreationDto.IsSuccesful = false;
                bookCreationDto.Message = "Bog blev ikke oprettet";
            }


            return JsonConvert.DeserializeObject<BookCreationDto>(jsonResponse);
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

    public Task<IEnumerable<Book>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Book>> GetAllAsync(string isbn)
    {
        var url = $"{ServerOptions.serverUrl}/book/get/all/{isbn}";

        var response = await _httpClient.GetAsync(url);

        Console.WriteLine($"GET request to {url}");
        Console.WriteLine($"Response status code: {response.StatusCode}");
        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"JSON Response: {jsonResponse}");

            return JsonConvert.DeserializeObject<List<Book>>(jsonResponse);
        }

        var errorResponse = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"Error Response: {errorResponse}");

        throw new Exception($"Error getting all book registries. Status code: {response.StatusCode}");
    }

    public Task<IEnumerable<Book>> GetAsync(ISearchParametersDto searchParameters)
    {
        throw new NotImplementedException();
    }

    public Task<Book> UpdateAsync(Book entity)
    {
        throw new NotImplementedException();
    }

    public async Task<Book> DeleteAsync(string isbn)
    {
        Console.WriteLine("delete book dao");
        var url = $"{ServerOptions.serverUrl}/book/deleteByIsbn/{isbn}";

        var response = await _httpClient.DeleteAsync(url);

        Console.WriteLine($"DELETE request to {url}");
        Console.WriteLine($"Response status code: {response.StatusCode}");

        if (response.IsSuccessStatusCode)
            return JsonConvert.DeserializeObject<Book>(await response.Content.ReadAsStringAsync());

        var errorResponse = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"Error Response: {errorResponse}");

        throw new Exception($"Error deleting book. Status code: {response.StatusCode}");
    }


    public async Task<Book?> LoanAsync(string bookId, string userId)
    {
        string jsonBody = "{ \"loanerUuid\": \"" + userId + "\"}";
        var jsonContent = new StringContent(jsonBody, Encoding.UTF8, "application/json");
        Console.WriteLine("JSON: " + JsonConvert.SerializeObject(bookId));
        Console.WriteLine("jsonContent11: " + jsonContent);
        var response = await _httpClient.PutAsync("http://localhost:7777/book/update/" + bookId, jsonContent);
        Console.WriteLine("response: " + response);
        if (!response.IsSuccessStatusCode)
            throw new Exception($"Error creating bookRegistry: {JsonConvert.SerializeObject(response)}");

        var jsonResponse = await response.Content.ReadAsStringAsync();
        Console.WriteLine(jsonResponse);
        return JsonConvert.DeserializeObject<Book>(jsonResponse);
    }

    public async Task<Book?> DeliverAsync(string bookId, string userId)
    {
        string jsonBody = "{ \"loanerUuid\": \"" + null + "\"}";
        var jsonContent = new StringContent(jsonBody, Encoding.UTF8, "application/json");
        Console.WriteLine("JSON: " + JsonConvert.SerializeObject(bookId));
        Console.WriteLine("jsonContent11: " + jsonContent);
        var response = await _httpClient.PutAsync("http://localhost:7777/book/update/" + bookId, jsonContent);
        Console.WriteLine("response: " + response);
        if (!response.IsSuccessStatusCode)
            throw new Exception($"Error creating bookRegistry: {JsonConvert.SerializeObject(response)}");

        var jsonResponse = await response.Content.ReadAsStringAsync();
        Console.WriteLine(jsonResponse);
        return JsonConvert.DeserializeObject<Book>(jsonResponse);
    }
}
