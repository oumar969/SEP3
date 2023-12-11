using Application.Logic;
using Domain.DTOs;

namespace UnitTest;

[TestFixture]
public class UserValidatorTest
{
    [Test]
    public void ValidateData_ValidUser_DoesNotThrowException()
    {
        // Arrange
        var userCreationDto = new UserCreationDto
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@example.com",
            Password = "SecurePwd123"
        };

        // Act & Assert
        Assert.DoesNotThrow(() => UserValidator.ValidateData(userCreationDto));
    }

    [Test]
    public void ValidateData_InvalidUser_ThrowsException()
    {
        // Arrange
        var userCreationDto = new UserCreationDto(); // Missing required fields

        // Act & Assert
        Assert.Throws<Exception>(() => UserValidator.ValidateData(userCreationDto));
    }

    [Test]
    public void SearchParametersValidator_ValidParameters_DoesNotThrowException()
    {
        // Arrange
        var searchParameters = new SearchUserParametersDto
        {
            FirstNameContains = "John",
            LastNameContains = "Doe"
        };

        // Act & Assert
        Assert.DoesNotThrow(() => UserValidator.SearchParametersValidator(searchParameters));
    }

    [Test]
    public void SearchParametersValidator_InvalidParameters_ThrowsException()
    {
        // Arrange
        var searchParameters = new SearchUserParametersDto(); // Missing required fields

        // Act & Assert
        Assert.Throws<Exception>(() => UserValidator.SearchParametersValidator(searchParameters));
    }

    [Test]
    public void IsValidEmail_ValidEmail_ReturnsTrue()
    {
        // Arrange
        string validEmail = "test@example.com";

        // Act
        var result = UserValidator.IsValidEmail(validEmail);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void IsValidEmail_InvalidEmail_ReturnsFalse()
    {
        // Arrange
        string invalidEmail = "invalidemail";

        // Act
        var result = UserValidator.IsValidEmail(invalidEmail);

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void ValidateData_EmptyFirstName_ThrowsException()
    {
        // Arrange
        var userCreationDto = new UserCreationDto
        {
            FirstName = "",
            LastName = "Doe",
            Email = "john.doe@example.com",
            Password = "SecurePwd123"
        };

        // Act & Assert
        Assert.Throws<Exception>(() => UserValidator.ValidateData(userCreationDto));
    }

    [Test]
    public void ValidateData_InvalidEmailFormat_ThrowsException()
    {
        // Arrange
        var userCreationDto = new UserCreationDto
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "invalid-email",
            Password = "SecurePwd123"
        };

        // Act & Assert
        Assert.Throws<Exception>(() => UserValidator.ValidateData(userCreationDto));
    }

    [Test]
    public void ValidateData_ShortPassword_ThrowsException()
    {
        // Arrange
        var userCreationDto = new UserCreationDto
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@example.com",
            Password = "Pwd123"
        };

        // Act & Assert
        Assert.Throws<Exception>(() => UserValidator.ValidateData(userCreationDto));
    }

    [Test]
    public void SearchParametersValidator_EmptyParameters_DoesNotThrowException()
    {
        // Arrange
        var searchParameters = new SearchUserParametersDto();

        // Act & Assert
        Assert.DoesNotThrow(() => UserValidator.SearchParametersValidator(searchParameters));
    }

    [Test]
    public void SearchParametersValidator_ShortFirstName_ThrowsException()
    {
        // Arrange
        var searchParameters = new SearchUserParametersDto
        {
            FirstNameContains = "Jo"
        };

        // Act & Assert
        Assert.Throws<Exception>(() => UserValidator.SearchParametersValidator(searchParameters));
    }


    [Test]
    public void ValidateData_NullUserCreationDto_ThrowsException()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => UserValidator.ValidateData(null));
    }

    [Test]
    public void SearchParametersValidator_NullSearchParametersDto_ThrowsException()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => UserValidator.SearchParametersValidator(null));
    }

    [Test]
    public void IsValidEmail_NullEmail_ReturnsFalse()
    {
        // Act
        var result = UserValidator.IsValidEmail(null);

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void IsValidEmail_EmptyEmail_ReturnsFalse()
    {
        // Act
        var result = UserValidator.IsValidEmail("");

        // Assert
        Assert.IsFalse(result);
    }
}