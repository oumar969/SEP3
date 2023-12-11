using Application.DAOInterfaces;
using Application.Logic;
using Domain.DTOs;
using Domain.Models;
using Moq;

namespace UnitTest;

    [TestFixture]
    public class BookLogicTests
    {
        private Mock<IBookDao> _bookDaoMock;
        private BookLogic _bookLogic;

        [SetUp]
        public void Setup()
        {
            _bookDaoMock = new Mock<IBookDao>();
            _bookLogic = new BookLogic(_bookDaoMock.Object);
        }

        [Test]
        public async Task UpdateAsync_ShouldCallUpdateAsyncOnDao()
        {
            // Arrange
            var updateDto = new BookUpdateDto();

            // Act
            await _bookLogic.UpdateAsync(updateDto);

            // Assert
            _bookDaoMock.Verify(dao => dao.UpdateAsync(updateDto), Times.Once);
        }

        [Test]
        public async Task GetByUuidAsync_ShouldCallGetByUuidAsyncOnDao()
        {
            // Arrange
            var uuid = "some-uuid";

            // Act
            await _bookLogic.GetByUuidAsync(uuid);

            // Assert
            _bookDaoMock.Verify(dao => dao.GetByUuidAsync(uuid), Times.Once);
        }

        [Test]
        public async Task GetAllBooksAsync_ShouldCallGetAllAsyncOnDao()
        {
            // Arrange
            var isbn = "some-isbn";

            // Act
            await _bookLogic.GetAllBooksAsync(isbn);

            // Assert
            _bookDaoMock.Verify(dao => dao.GetAllAsync(isbn), Times.Once);
        }

        [Test]
        public async Task CreateAsync_ShouldCallCreateAsyncOnDao()
        {
            // Arrange
            var creationDto = new BookCreationDto();

            // Act
            await _bookLogic.CreateAsync(creationDto);

            // Assert
            _bookDaoMock.Verify(dao => dao.CreateAsync(creationDto), Times.Once);
        }

        [Test]
        public async Task DeleteAsync_ShouldCallDeleteAsyncOnDao()
        {
            // Arrange
            var deleteDto = new BookDeleteDto();

            // Act
            await _bookLogic.DeleteAsync(deleteDto);

            // Assert
            _bookDaoMock.Verify(dao => dao.DeleteAsync(deleteDto), Times.Once);
        }
        [Test]
        public async Task UpdateAsync_ShouldReturnUpdatedBook()
        {
        // Arrange
        var updateDto = new BookUpdateDto();
        var updatedBook = new BookUpdateDto(); 
        _bookDaoMock.Setup(dao => dao.UpdateAsync(updateDto)).ReturnsAsync(updatedBook);

        // Act
        var result = await _bookLogic.UpdateAsync(updateDto);

    // Assert
    Assert.AreEqual(updatedBook, result);
        }

    [Test]
    public async Task GetByUuidAsync_WithValidUuid_ShouldReturnBook()
    {
    // Arrange
    var uuid = "valid-uuid";
    var book = new Book("1213123123123131","123","1231"); 
    _bookDaoMock.Setup(dao => dao.GetByUuidAsync(uuid)).ReturnsAsync(book);

    // Act
    var result = await _bookLogic.GetByUuidAsync(uuid);

    // Assert
    Assert.AreEqual(book, result);
    }

    [Test]
    public async Task GetAllBooksAsync_WithValidIsbn_ShouldReturnListOfBooks()
    {
    // Arrange
    var isbn = "valid-isbn";
    var books = new List<Book>(); 
    _bookDaoMock.Setup(dao => dao.GetAllAsync(isbn)).ReturnsAsync(books);

    // Act
    var result = await _bookLogic.GetAllBooksAsync(isbn);

    // Assert
    CollectionAssert.AreEqual(books, result);
    }

    [Test]
    public async Task CreateAsync_ShouldReturnCreatedBook()
    {
    // Arrange
    var creationDto = new BookCreationDto();
    var createdBook = new BookCreationDto(); 
    _bookDaoMock.Setup(dao => dao.CreateAsync(creationDto)).ReturnsAsync(createdBook);

    // Act
    var result = await _bookLogic.CreateAsync(creationDto);

    // Assert
    Assert.AreEqual(createdBook, result);
    }

    [Test]
    public async Task DeleteAsync_ShouldReturnDeletedBook()
    {
    // Arrange
    var deleteDto = new BookDeleteDto();
    var deletedBook = new BookDeleteDto(); 
    _bookDaoMock.Setup(dao => dao.DeleteAsync(deleteDto)).ReturnsAsync(deletedBook);

    // Act
    var result = await _bookLogic.DeleteAsync(deleteDto);

    // Assert
    Assert.AreEqual(deletedBook, result);
    }
}