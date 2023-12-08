using Moq;
using Application.DaoInterfaces;
using Domain.DTOs;
using Domain.Models;
using Application.Logic;

namespace UnitTest
{
    [TestFixture]
    public class UserLogicTest
    {
        private Mock<IUserDao> userDaoMock;
        private UserLogic userLogic;

        [SetUp]
        public void Setup()
        {
            // Mock IUserDao
            userDaoMock = new Mock<IUserDao>();//Mock er en klasse som lad os lave en fake version af en klasse
            userLogic = new UserLogic(userDaoMock.Object);
        }

        [Test]
        public async Task CreateAsync_ValidUser_ReturnsCreatedUser()
        {
            // Arrange
            var userCreationDto = new UserCreationDto
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Password = "SecurePwd123",
                IsLibrarian = false
            };

            userDaoMock.Setup(u => u.GetByEmailAsync(It.IsAny<string>())).ReturnsAsync((User)null);
            userDaoMock.Setup(u => u.CreateAsync(It.IsAny<User>())).ReturnsAsync(new User());

            // Act
            var result = await userLogic.CreateAsync(userCreationDto);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(userCreationDto.FirstName, result.FirstName);
            Assert.AreEqual(userCreationDto.LastName, result.LastName);
            Assert.AreEqual(userCreationDto.Email, result.Email);
            Assert.AreEqual(userCreationDto.Password, result.Password);
            Assert.AreEqual(userCreationDto.IsLibrarian, result.IsLibrarian);
        }

        [Test]
        public async Task CreateAsync_UserAlreadyExists_ThrowsException()
        {
            // Arrange
            var userCreationDto = new UserCreationDto { Email = "existing@example.com" };

            userDaoMock.Setup(u => u.GetByEmailAsync(userCreationDto.Email)).ReturnsAsync(new User());

            // Act & Assert
            Assert.ThrowsAsync<Exception>(() => userLogic.CreateAsync(userCreationDto));
        }

        [Test]
        public async Task GetAsync_ValidSearchParameters_ReturnsUsers()
        {
            // Arrange
            var searchParameters = new SearchUserParametersDto();
            var users = new List<User> { new User(), new User() };

            userDaoMock.Setup(u => u.GetAsync(searchParameters)).ReturnsAsync(users);

            // Act
            var result = await userLogic.GetAsync(searchParameters);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ICollection<User>>(result);
            Assert.AreEqual(users.Count, result.Count);
            // Add more assertions based on your specific requirements
        }
    }
}
