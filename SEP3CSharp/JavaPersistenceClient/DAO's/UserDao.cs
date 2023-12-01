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

    public async Task<User> CreateAsync(User entity)
    {
        var jsonContent = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
        Console.WriteLine("JSON: " + JsonConvert.SerializeObject(entity));
        Console.WriteLine("jsonContent11: " + jsonContent);
        var response = await _httpClient.PostAsync(ServerOptions.serverUrl + "/user/create", jsonContent);
        Console.WriteLine("response: " + response);
        if (!response.IsSuccessStatusCode)
            throw new Exception($"Error creating user: {JsonConvert.SerializeObject(response)}");

        var jsonResponse = await response.Content.ReadAsStringAsync();
        Console.WriteLine(jsonResponse);
        return JsonConvert.DeserializeObject<User>(jsonResponse);
    }

    public async Task<User> GetByUuidAsync(string uuid)
    {
        var url = $"{ServerOptions.serverUrl}/user/getByUuid/{uuid}";

        var response = await _httpClient.GetAsync(url);

        Console.WriteLine($"GET request to {url}");
        Console.WriteLine($"Response status code: {response.StatusCode}");
        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"JSON Response: {jsonResponse}");

            return JsonConvert.DeserializeObject<User>(jsonResponse);
        }

        var errorResponse = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"Error Response: {errorResponse}");

        throw new Exception($"Error getting user by UUID. Status code: {response.StatusCode}");
    }

    public async Task<ICollection<User>> GetAllAsync()
    {
        var url = $"{ServerOptions.serverUrl}/user/getAllAsync";

        var response = await _httpClient.GetAsync(url);

        Console.WriteLine($"GET request to {url}");
        Console.WriteLine($"Response status code: {response.StatusCode}");
        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"JSON Response: {jsonResponse}");

            return JsonConvert.DeserializeObject<ICollection<User>>(jsonResponse);
        }

        var errorResponse = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"Error Response: {errorResponse}");
        throw new Exception("Error getting all users");
    }

    public Task<ICollection<User>> GetAsync(ISearchParametersDto searchParameters)
    {
        throw new NotImplementedException();
    }

    public Task<User> UpdateAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(string uuid)
    {
        var url = $"{ServerOptions.serverUrl}/user/delete/{uuid}";

        var response = await _httpClient.DeleteAsync(url);

        Console.WriteLine($"DELETE request to {url}");
        Console.WriteLine($"Response status code: {response.StatusCode}");
        if (response.IsSuccessStatusCode) return;

        var errorResponse = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"Error Response: {errorResponse}");

        throw new Exception($"Error deleting user. Status code: {response.StatusCode}");
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        var url = $"{ServerOptions.serverUrl}/user/get/by-email/{email}";

        var response = await _httpClient.GetAsync(url);

        Console.WriteLine($"GET request to {url}");
        Console.WriteLine($"Response status code: {response.StatusCode}");
        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"JSON Response: {jsonResponse}");

            return JsonConvert.DeserializeObject<User>(jsonResponse);
        }

        if (response.StatusCode.ToString().Equals("NotFound")) return null;

        var errorResponse = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"Error Response: {errorResponse}");

        throw new Exception($"Error getting user by Email. Status code: {response.StatusCode}");
    }

    public async Task<User?> GetByUsernameAsync(string userName)
    {
        var url = $"{ServerOptions.serverUrl}/user/getByUsername/{userName}";

        var response = await _httpClient.GetAsync(url);

        Console.WriteLine($"GET request to {url}");
        Console.WriteLine($"Response status code: {response.StatusCode}");
        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"JSON Response: {jsonResponse}");

            return JsonConvert.DeserializeObject<User>(jsonResponse);
        }

        var errorResponse = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"Error Response: {errorResponse}");

        throw new Exception($"Error getting user by user name. Status code: {response.StatusCode}");
    }

    public Task<ICollection<User>> GetAsync(SearchUserParametersDto searchParameters)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}