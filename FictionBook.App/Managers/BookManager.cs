using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Books.App.Managers.Contracts;
using Books.App.Models.Database;
using Books.App.Providers.Contracts;

namespace Books.App.Managers
{
    public class BookManager 
        : IBookManager
    {
        #region Private Members

        private readonly IDbBookProvider _dbBookProvider;
        private readonly IStorageBookProvider _storageBookProvider;

        #endregion

        public BookManager(IDbBookProvider dbBookProvider, IStorageBookProvider storageBookProvider)
        {
            _dbBookProvider = dbBookProvider;
            _storageBookProvider = storageBookProvider;
        }

        #region Implementation of IBookManager

        public async Task<BookModel> ImportBook()
        {
            return await _storageBookProvider.ImportBookFromFile();
        }
        public async Task<IEnumerable<BookModel>> ImportBooks()
        {
            return await _storageBookProvider.ImportBooksFromFolder();
        }

        public Task<FictionBook.Library.FictionBook> LoadBook()
        {
            throw new System.NotImplementedException();
        }

        public async Task<BookModel> GetBook(Guid bookId)
        {
            return await _dbBookProvider.GetBook(bookId);
        }
        public async Task<IEnumerable<BookModel>> GetBooks()
        {
            return await _dbBookProvider.GetBooks();
        }
        public async Task<IEnumerable<BookModel>> GetBooks(int days)
        {
            return await _dbBookProvider.GetBooks(days);
        }

        public async Task DeleteBook(BookModel book)
        {
            await _storageBookProvider.DeleteBook(book);
            await _dbBookProvider.DeleteBook(book);
        }
        public async Task DeleteBooks(IEnumerable<BookModel> books)
        {
            await _storageBookProvider.DeleteBooks(books);
            await _dbBookProvider.DeleteBooks(books);
        }

        #endregion
    }
}
