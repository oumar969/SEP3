using Newtonsoft.Json;

namespace Domain.Models;

public class User
{
    public User(string uuid, string firstName, string lastName, string email, string password, bool isLibrarian)
    {
        UUID = uuid;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        IsLibrarian = isLibrarian;
    }

    public User(string firstName, string lastName, string email, string password, bool isLibrarian)
    {
        UUID = Guid.NewGuid().ToString();
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        IsLibrarian = isLibrarian;
    }

    public User()
    {
    }

    [JsonProperty("uuid")] public string UUID { get; set; }
    [JsonProperty("firstName")] public string FirstName { get; set; }
    [JsonProperty("lastName")] public string LastName { get; set; }
    [JsonProperty("email")] public string Email { get; set; }
    [JsonProperty("password")] public string Password { get; set; }
    [JsonProperty("isLibrarian")] public bool IsLibrarian { get; set; }
}