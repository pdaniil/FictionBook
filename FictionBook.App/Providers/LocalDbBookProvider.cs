namespace Books.App.Providers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Contracts;
    using Core.Database;
    using Models.Database;

    public class LocalDbBookProvider 
        : IDbBookProvider
    {
        #region Private Members

        private readonly LocalDbContext _dbContext;

        #endregion

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