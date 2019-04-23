using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.DbContexts;
using WebAPI.Model;
using WebAPI.Repository;

namespace WebApi.UnitTests
{
    public static class BookContextMocker
    {
        public static IBookRepository<Book> GetInMemoryBooksRepository(string dbName)
        {
            var options = new DbContextOptionsBuilder<BookContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            BookContext bookContext = new BookContext(options);
            bookContext.FillDatabase();

            return new BookRepository(bookContext);
        }
    }
}
