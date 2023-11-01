namespace Domain.DTOs;

public class UserUpdateDto
{
    public string UUID { get;  }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool IsLibrarian { get; set; }
    
    public UserUpdateDto(string uUID)
    {
        UUID = uUID;
    }
}