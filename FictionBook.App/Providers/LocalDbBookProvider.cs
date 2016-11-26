namespace Books.App.Providers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Microsoft.EntityFrameworkCore;

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


        #region Getting books

        public async Task<BookModel> GetBook(Guid bookId)
        {
            var book = await _dbContext.Books.FirstOrDefaultAsync(x => x.Id == bookId);
            return book;
        }

        public Task<IEnumerable<BookModel>> GetBooks()
        {
            return Task.FromResult(_dbContext.Books.AsEnumerable());
        }

        public Task<IEnumerable<BookModel>> GetBooks(int days)
        {
            return Task.FromResult(_dbContext.Books.Where(x => x.LastOpenedTime >= DateTime.Now.Add(TimeSpan.FromDays(-days))).AsEnumerable());
        }

        #endregion

        #region Deleting books

        public async Task DeleteBook(BookModel book)
        {
            _dbContext.Books.Remove(book);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteBooks(IEnumerable<BookModel> books)
        {
            _dbContext.Books.RemoveRange(books);
            await _dbContext.SaveChangesAsync();
        }

        #endregion

        #region Saving books

        public async Task SaveBook(BookModel book)
        {
            await _dbContext.Books.AddAsync(book);
            await _dbContext.SaveChangesAsync();
        }

        #endregion
    }
}