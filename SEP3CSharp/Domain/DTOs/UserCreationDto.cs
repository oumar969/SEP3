namespace Domain.DTOs;

public class UserCreationDto
{
    public string UUID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    
    public UserCreationDto(string uuid,string firstName, string lastName, string email, string password)
    {
        UUID = uuid;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }
}