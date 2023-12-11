using Application.DaoInterfaces;
using Application.Logic;
using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;
using Moq;

namespace Unit_Test
{
    [TestFixture]
    public class BookRegistryLogicTests
    {
        private Mock<IBookRegistryDao> _bookRegistryDaoMock;
        private Mock<IUserDao> _userDaoMock;
        private BookRegistryLogic _bookRegistryLogic;
        //mock er en klasse som lad os lave en fake version af en klasse
        [SetUp]
        public void Setup()
        {
            _bookRegistryDaoMock = new Mock<IBookRegistryDao>();
            _userDaoMock = new Mock<IUserDao>();
            _bookRegistryLogic = new BookRegistryLogic(_bookRegistryDaoMock.Object, _userDaoMock.Object);
        }

        [Test]
        public async Task CreateAsync_ValidDto_ShouldReturnCreatedBookRegistry()
        {
            // Arrange
            var creationDto = new BookRegistryCreationDto
            {
                Title = "Test Title",
                Author = "Test Author",
                Genre = "Test Genre",
                Isbn = "Test ISBN",
                Description = "Test Description",
            };

            var createdBookRegistry = new BookRegistryCreationDto(); 
            _bookRegistryDaoMock.Setup(dao => dao.CreateAsync(creationDto)).ReturnsAsync(createdBookRegistry);

            // Act
            var result = await _bookRegistryLogic.CreateAsync(creationDto);

            // Assert
            Assert.AreEqual(createdBookRegistry, result);
        }

        [Test]
        public async Task DeleteAsync_ShouldReturnDeletedBookRegistry()
        {
            // Arrange
            var deleteDto = new BookRegistryDeleteDto();

            var deletedBookRegistry = new BookRegistryDeleteDto(); 
            _bookRegistryDaoMock.Setup(dao => dao.DeleteAsync(deleteDto)).ReturnsAsync(deletedBookRegistry);

            // Act
            var result = await _bookRegistryLogic.DeleteAsync(deleteDto);

            // Assert
            Assert.AreEqual(deletedBookRegistry, result);
        }

        [Test]
        public async Task GetAllBookRegistriesAsync_ShouldReturnListOfBookRegistries()
        {
            // Arrange
            var bookRegistries = new List<BookRegistry>(); 
            _bookRegistryDaoMock.Setup(dao => dao.GetAllAsync()).ReturnsAsync(bookRegistries);

            // Act
            var result = await _bookRegistryLogic.GetAllBookRegistriesAsync();

            // Assert
            CollectionAssert.AreEqual(bookRegistries, result);
        }

        [Test]
        public void EditAsync_ShouldThrowNotImplementedException()
        {
            // Arrange
            var id = 1;
            var updateDto = new BookRegistryUpdateDto("111111111111111111111");

            // Act + Assert
            Assert.ThrowsAsync<NotImplementedException>(async () => await _bookRegistryLogic.EditAsync(id, updateDto));
        }

        [Test]
        public async Task GetBookRegistryByIsbnAsync_ShouldReturnBookRegistry()
        {
            // Arrange
            var isbn = "Test ISBN";
            var bookRegistry = new BookRegistry("Oumar","Ammar","genre","12345654768768","I'm so angry", "dont be shy"); // Provide a sample book registry or ensure it's returned by the mock.
            _bookRegistryDaoMock.Setup(dao => dao.GetByIsbnAsync(isbn)).ReturnsAsync(bookRegistry);

            // Act
            var result = await _bookRegistryLogic.GetBookRegistryByIsbnAsync(isbn);

            // Assert
            Assert.AreEqual(bookRegistry, result);
        }

        [Test]
        public void CreateAsync_WithInvalidDto_ShouldThrowException()
        {
            // Arrange
            var invalidDto = new BookRegistryCreationDto();

            // Act + Assert
            Assert.ThrowsAsync<Exception>(async () => await _bookRegistryLogic.CreateAsync(invalidDto));
        }
    }
    

}