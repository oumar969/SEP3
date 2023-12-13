using System.Net;
using System.Text;
using Application.DaoInterfaces;
using Domain.DTOs;
using Domain.Models;
using FileData;
using Newtonsoft.Json;

namespace JavaPersistenceClient.DAOs;

public class UserDao : IUserDao
{
    private readonly HttpClient _httpClient;

    public UserDao()
    {
        _httpClient = new HttpClient();
    }

    public async Task<UserCreationDto> CreateAsync(UserCreationDto dto)
    {
        User user = new()
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Password = dto.Password,
            UUID = dto.UUID,
            IsLibrarian = dto.IsLibrarian
        };

        if (user.UUID == null || user.UUID.Equals(""))
        {
            user.UUID = Guid.NewGuid().ToString();
        }


        var jsonContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
        Console.WriteLine("JSON: " + JsonConvert.SerializeObject(user));
        Console.WriteLine("jsonContent11: " + jsonContent);
        var response = await _httpClient.PostAsync(ServerOptions.serverUrl + "/user/create", jsonContent);
        var responseString = await response.Content.ReadAsStringAsync();
        Console.WriteLine("responseString: " + responseString);
        Console.WriteLine("response: " + response);
        Console.WriteLine("response suc?: " + response.IsSuccessStatusCode);
        if (!response.IsSuccessStatusCode)
        {
            dto.IsSuccessful = false;
            dto.ErrMsg = "Fejl ved oprettelse af bruger: " + responseString;
            return dto;
        }

        var jsonResponse = await response.Content.ReadAsStringAsync();
        Console.WriteLine(jsonResponse);
        dto.IsSuccessful = true;
        dto.ErrMsg = "Brugeren blev oprettet";
        return dto;
    }

    public Task<User> CreateAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public async Task<User> GetByUuidAsync(string uuid)
    {
        var url = $"{ServerOptions.serverUrl}/user/get/{uuid}";

        var response = await _httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<User>(jsonResponse);
        }

        throw new Exception($"Error getting user by UUID. Status code: {response.StatusCode}");
    }

    public async Task<ICollection<User>> GetAllAsync()
    {
        var url = $"{ServerOptions.serverUrl}/user/get/all";

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

    public Task<ICollection<Book>> GetAsync(ISearchParametersDto searchParameters)
    {
        throw new NotImplementedException();
    }

    public async Task<UserUpdateDto> UpdateAsync(UserUpdateDto dto)
    {
        var url = $"{ServerOptions.serverUrl}/user/update";

        var jsonContent = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
        var response = await _httpClient.PutAsync(url, jsonContent);

        Console.WriteLine($"PUT request to {url}");
        Console.WriteLine($"Response status code: {response.StatusCode}");

        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"JSON Response: {jsonResponse}");

            return JsonConvert.DeserializeObject<UserUpdateDto>(jsonResponse);
        }

        var errorResponse = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"Error Response: {errorResponse}");

        throw new Exception($"Error updating user. Status code: {response.StatusCode}");
    }

    public async Task<UserDeleteDto> DeleteAsync(UserDeleteDto dto)
    {
        var url = $"{ServerOptions.serverUrl}/user/delete/{dto.UUID}";

        var response = await _httpClient.DeleteAsync(url);

        Console.WriteLine($"DELETE request to {url}");
        Console.WriteLine($"Response status code: {response.StatusCode}");
        if (response.IsSuccessStatusCode)
        {
            dto.IsSuccessful = true;
            dto.ErrMsg = "Brugeren blev slettet";
        }
        else
        {
            dto.IsSuccessful = false;
            dto.ErrMsg = "Fejl ved sletning af bruger";
        }

        return dto;
    }

    public async Task<User> GetByEmailAsync(string email)
    {
        var url = $"{ServerOptions.serverUrl}/user/get/by-email/{email}";
        Console.WriteLine("url: watin");
        var response = await _httpClient.GetAsync(url);

        Console.WriteLine($"GET request to {url}");
        Console.WriteLine($"Response status code: {response.StatusCode}");
        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"JSON Response: {jsonResponse}");

            return JsonConvert.DeserializeObject<User>(jsonResponse);
        }

        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            return null;
        }

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

    public async Task<User?> GetByIdAsync(int id)
    {
        var url = $"{ServerOptions.serverUrl}/user/getById/{id}";

        var response = await _httpClient.GetAsync(url);

        Console.WriteLine($"GET request to {url}");
        Console.WriteLine($"Response status code: {response.StatusCode}");

        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"JSON Response: {jsonResponse}");

            return JsonConvert.DeserializeObject<User>(jsonResponse);
        }

        if (response.StatusCode.ToString().Equals("NotFound"))
            return null;

        var errorResponse = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"Error Response: {errorResponse}");

        throw new Exception($"Error getting user by ID. Status code: {response.StatusCode}");
    }

    public async Task DeleteAsync(int id)
    {
        var url = $"{ServerOptions.serverUrl}/book/delete/{id}";

        var response = await _httpClient.DeleteAsync(url);

        Console.WriteLine($"DELETE request to {url}");
        Console.WriteLine($"Response status code: {response.StatusCode}");

        if (response.IsSuccessStatusCode)
            return;

        var errorResponse = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"Error Response: {errorResponse}");

        throw new Exception($"Error deleting book registry. Status code: {response.StatusCode}");
    }

    public Task<ICollection<User>> GetAllUsersAsync()
    {
        var url = $"{ServerOptions.serverUrl}/user/get/all";

        var response = _httpClient.GetAsync(url).Result;

        Console.WriteLine($"GET request to {url}");
        Console.WriteLine($"Response status code: {response.StatusCode}");
        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = response.Content.ReadAsStringAsync().Result;

            Console.WriteLine($"JSON Response: {jsonResponse}");

            return Task.FromResult(JsonConvert.DeserializeObject<ICollection<User>>(jsonResponse));
        }

        var errorResponse = response.Content.ReadAsStringAsync().Result;
        Console.WriteLine($"Error Response: {errorResponse}");
        throw new Exception("Error getting all users");
    }

    public Task<ICollection<Book>> GetAllLoanerBooks(string loanerUuid)
    {
        var url = $"{ServerOptions.serverUrl}/book/get/loaner/{loanerUuid}";

        var response = _httpClient.GetAsync(url).Result;

        Console.WriteLine($"GET request to {url}");
        Console.WriteLine($"Response status code: {response.StatusCode}");
        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = response.Content.ReadAsStringAsync().Result;

            Console.WriteLine($"JSON Response: {jsonResponse}");

            return Task.FromResult(JsonConvert.DeserializeObject<ICollection<Book>>(jsonResponse));
        }

        var errorResponse = response.Content.ReadAsStringAsync().Result;
        Console.WriteLine($"Error Response: {errorResponse}");
        throw new Exception("Error getting loaners books");
    }
}