using Newtonsoft.Json;

namespace Domain.DTOs;

public class UserCreationDto
{
    public UserCreationDto(string uuid, string firstName, string lastName, string email, string password,
        bool isLibrarian, bool isSuccessful = false, string errMsg = "")
    {
        UUID = Guid.NewGuid().ToString();
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        IsLibrarian = isLibrarian;
        IsSuccessful = isSuccessful;
        ErrMsg = errMsg;
    }

    [JsonConstructor]
    public UserCreationDto(string firstName, string lastName, string email, string password, bool isLibrarian,
        bool isSuccessful = false, string errMsg = "")
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        IsLibrarian = isLibrarian;
        IsSuccessful = isSuccessful;
        ErrMsg = errMsg;
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
    public string ErrMsg { get; set; }
}