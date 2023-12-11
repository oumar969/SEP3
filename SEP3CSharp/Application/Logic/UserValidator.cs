using System.Net.Mail;
using Domain.DTOs;

namespace Application.Logic;

public class UserValidator
{
    public static void ValidateData(UserCreationDto userCreationDto)
    {
        var firstName = userCreationDto.FirstName;
        var lastName = userCreationDto.LastName;
        var email = userCreationDto.Email;
        var password = userCreationDto.Password;

        if (string.IsNullOrWhiteSpace(firstName))
            throw new Exception("First Name is required");

        if (string.IsNullOrWhiteSpace(lastName))
            throw new Exception("Last Name is required");

        if (string.IsNullOrWhiteSpace(email))
            throw new Exception("Email is required");

        if (string.IsNullOrWhiteSpace(password))
            throw new Exception("Password is required");

        if (firstName.Length < 3 || lastName.Length < 3)
            throw new Exception("Both First Name and Last Name must be at least 3 characters long");

        if (email.Length < 5 || !IsValidEmail(email))
            throw new Exception("Email is not valid");

        if (password.Length < 8)
            throw new Exception("Password must be at least 8 characters long");
    }

    public static bool IsValidEmail(string email)
    {
        try
        {
            var address = new MailAddress(email);
            return address.Address == email;
        }
        catch
        {
            return false;
        }
    }

    public static void SearchParametersValidator(SearchUserParametersDto searchParameters)
    {
        var firstName = searchParameters.FirstNameContains;
        var lastName = searchParameters.LastNameContains;


        if (string.IsNullOrWhiteSpace(firstName) && string.IsNullOrWhiteSpace(lastName))
            throw new Exception("At least one search parameter is required");

        if (firstName != null && firstName.Length < 3)
            throw new Exception("First Name must be at least 3 characters long");

        if (lastName != null && lastName.Length < 3)
            throw new Exception("Last Name must be at least 3 characters long");
    }
}