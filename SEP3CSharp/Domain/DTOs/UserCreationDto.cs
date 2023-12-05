using Newtonsoft.Json;

namespace Domain.DTOs;

public class UserCreationDto
{
    public UserCreationDto(string uuid, string firstName, string lastName, string email, string password,
        bool isLibrarian, bool isSuccessful = false)
    {
        UUID = Guid.NewGuid().ToString();
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        IsLibrarian = isLibrarian;
        IsSuccessful = isSuccessful;
    }

    [JsonConstructor]
    public UserCreationDto(string firstName, string lastName, string email, string password, bool isLibrarian,
        bool isSuccessful = false)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        IsLibrarian = isLibrarian;
        IsSuccessful = isSuccessful;
    }

    public UserCreationDto()
    {
    }

    public string UUID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool IsLibrarian { get; set; }
    public bool IsSuccessful { get; set; }
}