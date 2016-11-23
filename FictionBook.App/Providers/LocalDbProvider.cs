using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Books.App.Core.Storage;
using Books.App.Core.Storage.Models;
using Books.App.Providers.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Books.App.Providers
{
    public class LocalDbBookProvider : IDbBookProvider
    {
        private readonly LocalDbContext _dbContext;

        public LocalDbBookProvider(LocalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<BookModel> GetBook()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<BookModel>> GetAllBooks()
        {
            return Task.FromResult(_dbContext.Books.AsEnumerable());
        }

        public Task<IEnumerable<BookModel>> GetRecentBooks(int days)
        {
            return Task.FromResult(_dbContext.Books.Where(x => x.LastOpenedTime >= DateTime.Now.Add(TimeSpan.FromDays(-days))).AsEnumerable());
        }

        public async Task SaveBook(BookModel book)
        {
            await _dbContext.Books.AddAsync(book);
            await _dbContext.SaveChangesAsync();
        }
    }
}