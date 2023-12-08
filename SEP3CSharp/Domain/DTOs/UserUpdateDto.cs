namespace Domain.DTOs;

public class UserUpdateDto
{
    public string UUID { get; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool IsLibrarian { get; set; }
    public bool IsSuccessful { get; set; }
    public string ErrMsg { get; set; }

    public UserUpdateDto()
    {
    }

    public UserUpdateDto(string firstName, string lastName, string email, string password, bool isLibrarian,
        bool isSuccessful, string errMsg)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        IsLibrarian = isLibrarian;
        IsSuccessful = isSuccessful;
        ErrMsg = errMsg;
    }
}