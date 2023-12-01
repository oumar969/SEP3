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
        public void IsLibrarian_IsLibrarian_ReturnsTrue()
        {
            // Arrange
            bool isLibrarian = true;

            // Act
            var result = UserValidator.IsLibrarian(isLibrarian);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsLibrarian_IsNotLibrarian_ReturnsFalse()
        {
            // Arrange
            bool isLibrarian = false;

            // Act
            var result = UserValidator.IsLibrarian(isLibrarian);

            // Assert
            Assert.IsFalse(result);
        }
        
        
}