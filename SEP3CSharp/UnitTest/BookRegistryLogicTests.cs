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

            var result = await _bookRegistryLogic.CreateAsync(creationDto);

            
            Assert.AreEqual(createdBookRegistry, result);
        }

        [Test]
        public async Task DeleteAsync_ShouldReturnDeletedBookRegistry()
        {
            
            var deleteDto = new BookRegistryDeleteDto();

            var deletedBookRegistry = new BookRegistryDeleteDto(); 
            _bookRegistryDaoMock.Setup(dao => dao.DeleteAsync(deleteDto)).ReturnsAsync(deletedBookRegistry);

            var result = await _bookRegistryLogic.DeleteAsync(deleteDto);

            Assert.AreEqual(deletedBookRegistry, result);
        }

        [Test]
        public async Task GetAllBookRegistriesAsync_ShouldReturnListOfBookRegistries()
        {
            var bookRegistries = new List<BookRegistry>(); 
            _bookRegistryDaoMock.Setup(dao => dao.GetAllAsync()).ReturnsAsync(bookRegistries);

            var result = await _bookRegistryLogic.GetAllBookRegistriesAsync();

            CollectionAssert.AreEqual(bookRegistries, result);
        }

        [Test]
        public void EditAsync_ShouldThrowNotImplementedException()
        {
            
            var id = 1;
            var updateDto = new BookRegistryUpdateDto("111111111111111111111");

            
            Assert.ThrowsAsync<NotImplementedException>(async () => await _bookRegistryLogic.EditAsync(id, updateDto));
        }

        [Test]
        public async Task GetBookRegistryByIsbnAsync_ShouldReturnBookRegistry()
        {
            
            var isbn = "Test ISBN";
            var bookRegistry = new BookRegistry("Oumar","Ammar","genre","12345654768768","I'm so angry", "dont be shy"); // Provide a sample book registry or ensure it's returned by the mock.
            _bookRegistryDaoMock.Setup(dao => dao.GetByIsbnAsync(isbn)).ReturnsAsync(bookRegistry);

            
            var result = await _bookRegistryLogic.GetBookRegistryByIsbnAsync(isbn);

            Assert.AreEqual(bookRegistry, result);
        }

        [Test]
        public void CreateAsync_WithInvalidDto_ShouldThrowException()
        {
            var invalidDto = new BookRegistryCreationDto();

            Assert.ThrowsAsync<Exception>(async () => await _bookRegistryLogic.CreateAsync(invalidDto));
        }
    }
    

}