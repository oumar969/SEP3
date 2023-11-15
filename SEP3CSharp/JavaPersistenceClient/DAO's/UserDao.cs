using System.Text;
using Domain.DTOs;
using Domain.Models;
using FileData;
using Newtonsoft.Json;

namespace JavaPersistenceClient.DAOs;

public class UserDao : IGenericDao<User>
{
    private readonly HttpClient _httpClient;

    public UserDao()
    {
        _httpClient = new HttpClient();
    }

    public Task<User> CreateAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<User>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<User> UpdateAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(string uuid)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetByUuidAsync(string uuid)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<User>> GetAsync(object searchParameters)
    {
        throw new NotImplementedException();
    }

    public async Task<User> GetAsync(SearchUserParametersDto searchParameters)
    {
        var response = await _httpClient.PostAsync("http://localhost:8080/user/get/by_email",
            new StringContent("", Encoding.UTF8));
        Console.WriteLine("response: " + response);
        if (!response.IsSuccessStatusCode)
            throw new Exception($"Error creating bookRegistry: {JsonConvert.SerializeObject(response)}");

        var jsonResponse = await response.Content.ReadAsStringAsync();
        Console.WriteLine(jsonResponse);
        return JsonConvert.DeserializeObject<User>(jsonResponse);
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}