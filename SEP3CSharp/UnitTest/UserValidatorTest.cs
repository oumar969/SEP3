using Application.Logic;
using Domain.DTOs;

namespace UnitTest;

[TestFixture]
public class UserValidatorTest
{
    [Test]
    public void ValidateData_ValidUser_DoesNotThrowException()
    {
        var userCreationDto = new UserCreationDto
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@example.com",
            Password = "SecurePwd123"
        };

        Assert.DoesNotThrow(() => UserValidator.ValidateData(userCreationDto));
    }

    [Test]
    public void ValidateData_InvalidUser_ThrowsException()
    {
        
        var userCreationDto = new UserCreationDto(); 

        Assert.Throws<Exception>(() => UserValidator.ValidateData(userCreationDto));
    }

    [Test]
    public void SearchParametersValidator_ValidParameters_DoesNotThrowException()
    {
        var searchParameters = new SearchUserParametersDto
        {
            FirstNameContains = "John",
            LastNameContains = "Doe"
        };

        Assert.DoesNotThrow(() => UserValidator.SearchParametersValidator(searchParameters));
    }

    [Test]
    public void SearchParametersValidator_InvalidParameters_ThrowsException()
    {
        
        var searchParameters = new SearchUserParametersDto(); // Missing required fields

        // 
        Assert.Throws<Exception>(() => UserValidator.SearchParametersValidator(searchParameters));
    }

    [Test]
    public void IsValidEmail_ValidEmail_ReturnsTrue()
    {
        
        string validEmail = "test@example.com";

        var result = UserValidator.IsValidEmail(validEmail);

        Assert.IsTrue(result);
    }

    [Test]
    public void IsValidEmail_InvalidEmail_ReturnsFalse()
    {
        string invalidEmail = "invalidemail";

        var result = UserValidator.IsValidEmail(invalidEmail);

        Assert.IsFalse(result);
    }

    [Test]
    public void ValidateData_EmptyFirstName_ThrowsException()
    {
        var userCreationDto = new UserCreationDto
        {
            FirstName = "",
            LastName = "Doe",
            Email = "john.doe@example.com",
            Password = "SecurePwd123"
        };

        Assert.Throws<Exception>(() => UserValidator.ValidateData(userCreationDto));
    }

    [Test]
    public void ValidateData_InvalidEmailFormat_ThrowsException()
    {
        var userCreationDto = new UserCreationDto
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "invalid-email",
            Password = "SecurePwd123"
        };

        Assert.Throws<Exception>(() => UserValidator.ValidateData(userCreationDto));
    }

    [Test]
    public void ValidateData_ShortPassword_ThrowsException()
    {
        var userCreationDto = new UserCreationDto
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@example.com",
            Password = "Pwd123"
        };

        Assert.Throws<Exception>(() => UserValidator.ValidateData(userCreationDto));
    }

    [Test]
    public void SearchParametersValidator_EmptyParameters_DoesNotThrowException()
    {
        
        var searchParameters = new SearchUserParametersDto();

        
        Assert.DoesNotThrow(() => UserValidator.SearchParametersValidator(searchParameters));
    }

    [Test]
    public void SearchParametersValidator_ShortFirstName_ThrowsException()
    {
        var searchParameters = new SearchUserParametersDto
        {
            FirstNameContains = "Jo"
        };

        Assert.Throws<Exception>(() => UserValidator.SearchParametersValidator(searchParameters));
    }


    [Test]
    public void ValidateData_NullUserCreationDto_ThrowsException()
    {
        Assert.Throws<ArgumentNullException>(() => UserValidator.ValidateData(null));
    }

    [Test]
    public void SearchParametersValidator_NullSearchParametersDto_ThrowsException()
    {
        Assert.Throws<ArgumentNullException>(() => UserValidator.SearchParametersValidator(null));
    }

    [Test]
    public void IsValidEmail_NullEmail_ReturnsFalse()
    {
        var result = UserValidator.IsValidEmail(null);

        Assert.IsFalse(result);
    }

    [Test]
    public void IsValidEmail_EmptyEmail_ReturnsFalse()
    {
        var result = UserValidator.IsValidEmail("");

        Assert.IsFalse(result);
    }
}