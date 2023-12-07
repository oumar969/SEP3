using System.Text;
using Application.DAOInterfaces;
using Domain.DTOs;
using Domain.Models;
using Newtonsoft.Json;


namespace JavaPersistenceClient.DAOs;

public class BookDao : IBookDao
{
    private readonly HttpClient _httpClient;

    public BookDao(HttpClient httpClient) //tissemand 
    {
        _httpClient = httpClient;
    }

    public Task<Book> CreateAsync(Book entity)
    {
        throw new NotImplementedException();
    }

    public Task<Book> GetByUuidAsync(string uuid)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<Book>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<Book>> GetAsync(ISearchParametersDto searchParameters)
    {
        throw new NotImplementedException();
    }

    public Task<Book> UpdateAsync(Book entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(string uuid)
    {
        throw new NotImplementedException();
    }

    public async Task<Book?> LoanAsync(Book book, User user)
    {
        string userId = "{ \"loanerUuid\": \"" + user.UUID.ToString() + "\"}";
        var jsonContent = new StringContent(userId, Encoding.UTF8, "application/json");
        Console.WriteLine("JSON: " + JsonConvert.SerializeObject(book));
        Console.WriteLine("jsonContent11: " + jsonContent);
        var response = await _httpClient.PutAsync("http://localhost:7777/book/update/" + book.UUID, jsonContent);
        Console.WriteLine("response: " + response);
        if (!response.IsSuccessStatusCode)
            throw new Exception($"Error creating bookRegistry: {JsonConvert.SerializeObject(response)}");

        var jsonResponse = await response.Content.ReadAsStringAsync();
        Console.WriteLine(jsonResponse);
        return JsonConvert.DeserializeObject<Book>(jsonResponse);
    }

    public Task<Book?> DeliverAsync(Book book, User user)
    {
        throw new NotImplementedException();
    }
}