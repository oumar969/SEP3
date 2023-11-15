using System.Text;
using Application.DaoInterfaces;
using Domain.DTOs;
using Domain.Models;
using FileData;
using Newtonsoft.Json;

namespace JavaPersistenceClient.DAOs;

public class UserDao : IGenericDao<User>, IUserDao
{
    private readonly HttpClient _httpClient;
    public UserDao()
    {
        _httpClient = new HttpClient();
    }

    public Task<User> GetByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }

    public async Task<User> CreateAsync(User entity)
    {
        var jsonContent = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
        Console.WriteLine("JSON: " + JsonConvert.SerializeObject(entity));
        Console.WriteLine("jsonContent11: " + jsonContent);
        var response = await _httpClient.PostAsync("http://localhost:8080/user/create", jsonContent);
        Console.WriteLine("response: " + response);
        if (!response.IsSuccessStatusCode)
            throw new Exception($"Error creating user: {JsonConvert.SerializeObject(response)}");

        var jsonResponse = await response.Content.ReadAsStringAsync();
        Console.WriteLine(jsonResponse);
        return JsonConvert.DeserializeObject<User>(jsonResponse);
    }

    public Task<User?> GetByUsernameAsync(string userName)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<User>> GetAsync(SearchUserParametersDto searchParameters)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<User> GetByUuidAsync(string uuid)
    {
        string url = $"http://localhost:8080/user/getByUuid/{uuid}";

        var response = await _httpClient.GetAsync(url);

        Console.WriteLine($"GET request to {url}");
        Console.WriteLine($"Response status code: {response.StatusCode}");
        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"JSON Response: {jsonResponse}");

            return JsonConvert.DeserializeObject<User>(jsonResponse);
        }
        else
        {
            var errorResponse = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Error Response: {errorResponse}");

            throw new Exception($"Error getting user by UUID. Status code: {response.StatusCode}");
        }
    }

    public Task<ICollection<User>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<User>> GetAsync(ISearchParametersDto searchParameters)
    {
        throw new NotImplementedException();
    }

    public Task<User> UpdateAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(string uuid)
    {
        string url = $"http://localhost:8080/user/delete/{uuid}";
        var response = await _httpClient.DeleteAsync(url);

        Console.WriteLine($"DELETE request to {url}");
        Console.WriteLine($"Response status code: {response.StatusCode}");

        if (!response.IsSuccessStatusCode)
        {
            var errorResponse = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Error Response: {errorResponse}");
            throw new Exception($"Error deleting user. Status code: {response.StatusCode}");
        }
    }
}