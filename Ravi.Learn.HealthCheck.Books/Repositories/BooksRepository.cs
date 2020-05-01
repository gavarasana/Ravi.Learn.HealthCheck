using Microsoft.EntityFrameworkCore;
using Ravi.Learn.HealthCheck.Books.Dbcontext;
using Ravi.Learn.HealthCheck.Books.Dxos;
using Ravi.Learn.HealthCheck.Books.Entities;
using Ravi.Learn.HealthCheck.Books.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ravi.Learn.HealthCheck.Books.Repositories
{
    public interface IRepository<T>
    {
        Task<T> GetById(Guid id, CancellationToken cancellationToken);

    }
    public class BooksRepository : IRepository<Book>
    {
        private readonly BooksContext booksContext;

        public BooksRepository(BooksContext booksContext, IEntityDxo<Book, BookResponse> bookDxo)
        {
            this.booksContext = booksContext;          
        }

        public async Task<Book> GetById(Guid id, CancellationToken cancellationToken)
        {
            //using (booksContext)
            //{
                return await booksContext.FindAsync<Book>(id);
                              
            //}
        }
    }
}
