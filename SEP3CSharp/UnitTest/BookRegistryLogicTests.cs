using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DaoInterfaces;
using Application.Logic;
using Domain.DTOs;
using Domain.Models;
using Moq;
using NUnit.Framework;

namespace Unit_Test
{
    [TestFixture]
    public class BookRegistryLogicTests
    {
        [Test]
        public async Task CreateAsync_ValidDto_CreatesBookRegistry()
        {
            // Arrange
            var bookRegistryDaoMock = new Mock<IBookRegistryDao>();
            var userDaoMock = new Mock<IUserDao>();

            var bookRegistryLogic = new BookRegistryLogic(bookRegistryDaoMock.Object, userDaoMock.Object);

            var creationDto = new BookRegistryCreationDto
            {
                Title = "NewBook",
                Author = "Author",
                Genre = "Genre",
                Isbn = "ISBN",
                Description = "Description",
                Review = "Review",
                Location = "Library" // Add a valid location
            };

            bookRegistryDaoMock.Setup(x => x.CreateAsync(It.IsAny<BookRegistry>()))
                .ReturnsAsync(new BookRegistry(creationDto.Title, creationDto.Author, creationDto.Genre, creationDto.Isbn, creationDto.Description, creationDto.Review));

            // Act
            var createdBookRegistry = await bookRegistryLogic.CreateAsync(creationDto);

            // Assert
            Assert.IsNotNull(createdBookRegistry);
            bookRegistryDaoMock.Verify(x => x.CreateAsync(It.IsAny<BookRegistry>()), Times.Once);
        }
        //Todo Add more test cases as needed
    }
}
