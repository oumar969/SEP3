namespace Domain.DTOs;

public class UserUpdateDto
{
    public string UUID { get; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool IsLibrarian { get; set; }
    
    public UserUpdateDto(string uUID)
    {
        UUID = uUID;
    }

    public UserUpdateDto(string firstName, string lastName, string email, string password, bool isLibrarian)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        IsLibrarian = isLibrarian;
    }
    
}