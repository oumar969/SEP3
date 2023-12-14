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
            
            var updateDto = new BookUpdateDto();

            
            await _bookLogic.UpdateAsync(updateDto);

            
            _bookDaoMock.Verify(dao => dao.UpdateAsync(updateDto), Times.Once);
        }

        [Test]
        public async Task GetByUuidAsync_ShouldCallGetByUuidAsyncOnDao()
        {
            var uuid = "some-uuid";

            await _bookLogic.GetByUuidAsync(uuid);

            _bookDaoMock.Verify(dao => dao.GetByUuidAsync(uuid), Times.Once);
        }

        [Test]
        public async Task GetAllBooksAsync_ShouldCallGetAllAsyncOnDao()
        {
            var isbn = "some-isbn";

            await _bookLogic.GetAllBooksAsync(isbn);

            _bookDaoMock.Verify(dao => dao.GetAllAsync(isbn), Times.Once);
        }

        [Test]
        public async Task CreateAsync_ShouldCallCreateAsyncOnDao()
        {
            var creationDto = new BookCreationDto();

            await _bookLogic.CreateAsync(creationDto);

            _bookDaoMock.Verify(dao => dao.CreateAsync(creationDto), Times.Once);
        }

        [Test]
        public async Task DeleteAsync_ShouldCallDeleteAsyncOnDao()
        {
            var deleteDto = new BookDeleteDto();

            await _bookLogic.DeleteAsync(deleteDto);

            _bookDaoMock.Verify(dao => dao.DeleteAsync(deleteDto), Times.Once);
        }
        [Test]
        public async Task UpdateAsync_ShouldReturnUpdatedBook()
        {
        var updateDto = new BookUpdateDto();
        var updatedBook = new BookUpdateDto(); 
        _bookDaoMock.Setup(dao => dao.UpdateAsync(updateDto)).ReturnsAsync(updatedBook);

        var result = await _bookLogic.UpdateAsync(updateDto);

    Assert.AreEqual(updatedBook, result);
        }

    [Test]
    public async Task GetByUuidAsync_WithValidUuid_ShouldReturnBook()
    {
    var uuid = "valid-uuid";
    var book = new Book("1213123123123131","123","1231"); 
    _bookDaoMock.Setup(dao => dao.GetByUuidAsync(uuid)).ReturnsAsync(book);

    var result = await _bookLogic.GetByUuidAsync(uuid);

    Assert.AreEqual(book, result);
    }

    [Test]
    public async Task GetAllBooksAsync_WithValidIsbn_ShouldReturnListOfBooks()
    {
    var isbn = "valid-isbn";
    var books = new List<Book>(); 
    _bookDaoMock.Setup(dao => dao.GetAllAsync(isbn)).ReturnsAsync(books);

    var result = await _bookLogic.GetAllBooksAsync(isbn);

    CollectionAssert.AreEqual(books, result);
    }

    [Test]
    public async Task CreateAsync_ShouldReturnCreatedBook()
    {
    var creationDto = new BookCreationDto();
    var createdBook = new BookCreationDto(); 
    _bookDaoMock.Setup(dao => dao.CreateAsync(creationDto)).ReturnsAsync(createdBook);

    var result = await _bookLogic.CreateAsync(creationDto);

    Assert.AreEqual(createdBook, result);
    }

    [Test]
    public async Task DeleteAsync_ShouldReturnDeletedBook()
    {
    var deleteDto = new BookDeleteDto();
    var deletedBook = new BookDeleteDto(); 
    _bookDaoMock.Setup(dao => dao.DeleteAsync(deleteDto)).ReturnsAsync(deletedBook);

    var result = await _bookLogic.DeleteAsync(deleteDto);

    Assert.AreEqual(deletedBook, result);
    }
}