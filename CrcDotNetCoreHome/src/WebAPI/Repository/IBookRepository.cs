using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model;

namespace WebAPI.Repository
{
    public interface IBookRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Get(long id);
        Task Add(TEntity entity);
        Task Update(Book book, TEntity entity);
        Task Delete(Book book);
    }
}
