using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Controllers;
using WebAPI.Model;
using Xunit;

namespace WebApi.UnitTests.Controllers
{
    public class BookControlleUnitTests
    {
        [Fact]
        public async Task get_all_books()
        {
            // Arrange 
            var repository = BookContextMocker.GetInMemoryBooksRepository(nameof(get_all_books));
            var controller = new BookController(repository);

            // Act
            var response = await controller.GetAll() as ObjectResult;
            var books = response.Value as List<Book>;

            // Assert
            Assert.Equal(200, response.StatusCode);
            Assert.Equal(5, books.Count);
        }

        [Fact]
        public async Task get_book_with_existing_id()
        {
            // Arrange 
            var repository = BookContextMocker.GetInMemoryBooksRepository(nameof(get_book_with_existing_id));
            var controller = new BookController(repository);
            var expectedValue = "Harry Potter";

            // Act
            var response = await controller.Get(1) as ObjectResult;
            var book = response.Value as Book;

            // Assert
            Assert.Equal(200, response.StatusCode);
            Assert.Equal(expectedValue, book.Title);
        }

        [Fact]
        public async Task get_book_with_not_existing_id()
        {
            // Arrange 
            var repository = BookContextMocker.GetInMemoryBooksRepository(nameof(get_book_with_not_existing_id));
            var controller = new BookController(repository);
            var expectedMessage = "The Book record couldn't be found.";

            // Act
            var response = await controller.Get(10) as ObjectResult;

            // Assert
            Assert.Equal(404, response.StatusCode);
            Assert.Equal(expectedMessage, response.Value);
        }

        [Fact]
        public async Task put_book_with_existing_id()
        {
            // Arrange 
            var repository = BookContextMocker.GetInMemoryBooksRepository(nameof(get_book_with_not_existing_id));
            var controller = new BookController(repository);
            var expectedValue = "Harry Potter 2";
            // Act

            Book book = new Book()
            {
                Title = expectedValue
            };
            await controller.Put(1, book);
            var response = await controller.Get(1) as ObjectResult;
            var newBook = response.Value as Book;


            // Assert
            Assert.Equal(200, response.StatusCode);
            Assert.Equal(book.Title, newBook.Title);
        }

        [Fact]
        public async Task delete_book_with_existing_id()
        {
            // Arrange 
            var repository = BookContextMocker.GetInMemoryBooksRepository(nameof(get_book_with_not_existing_id));
            var controller = new BookController(repository);
            var expectedValue = 4;
            // Act
            await controller.Delete(1);
            var response = await controller.GetAll() as ObjectResult;
            var books = response.Value as List<Book>;


            // Assert
            Assert.Equal(200, response.StatusCode);
            Assert.Equal(4, books.Count);
        }
    }
}
