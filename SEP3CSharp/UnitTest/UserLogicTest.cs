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
            userDaoMock = new Mock<IUserDao>();
            userLogic = new UserLogic(userDaoMock.Object);
        }

        [Test]
        public async Task CreateAsync_ValidUser_ReturnsCreatedUser()
        {
            
            var userCreationDto = new UserCreationDto
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Password = "SecurePwd123",
                IsLibrarian = false
            };
            
            var result = await userLogic.CreateAsync(userCreationDto);

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
            var userCreationDto = new UserCreationDto { Email = "existing@example.com" };

            userDaoMock.Setup(u => u.GetByEmailAsync(userCreationDto.Email)).ReturnsAsync(new User());

            Assert.ThrowsAsync<Exception>(() => userLogic.CreateAsync(userCreationDto));
        }

        [Test]
        public async Task GetAsync_ValidSearchParameters_ReturnsUsers()
        {
            var searchParameters = new SearchUserParametersDto();
            var users = new List<User> { new User(), new User() };

            userDaoMock.Setup(u => u.GetAsync(searchParameters)).ReturnsAsync(users);

            var result = await userLogic.GetAsync(searchParameters);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ICollection<User>>(result);
            Assert.AreEqual(users.Count, result.Count);
        }
    }
}