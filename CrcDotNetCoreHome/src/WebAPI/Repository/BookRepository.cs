using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DbContexts;
using WebAPI.Model;

namespace WebAPI.Repository
{
    public class BookRepository : IBookRepository<Book>
    {
        private readonly BookContext _dbContext;

        public BookRepository(BookContext dbCcontext)
        {
            _dbContext = dbCcontext;
        }


        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _dbContext.Books.ToListAsync();
        }

        public async Task<Book> Get(long id)
        {
            return await _dbContext.Books.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task Add(Book entity)
        {
            await _dbContext.Books.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Book book, Book entity)
        {
            book.Title = entity.Title;
            book.Author = entity.Author;
            book.ISBN = entity.ISBN;
            book.Date = entity.Date;

            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Book measurement)
        {
            _dbContext.Books.Remove(measurement);
            await _dbContext.SaveChangesAsync();
        }
    }
}
