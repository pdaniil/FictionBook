using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Books.App.Models.Database;

namespace Books.App.Managers.Contracts
{
    public interface IBookManager
    {
        Task<BookModel> ImportBook();
        Task<IEnumerable<BookModel>> ImportBooks();

        Task<FictionBook.Library.FictionBook> LoadBook();

        Task<BookModel> GetBook(Guid bookId);
        Task<IEnumerable<BookModel>> GetBooks();
        Task<IEnumerable<BookModel>> GetBooks(int days);
        
        Task DeleteBook(BookModel book);
        Task DeleteBooks(IEnumerable<BookModel> books);
    }
}