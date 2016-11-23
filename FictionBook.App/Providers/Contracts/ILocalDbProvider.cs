using System.Collections.Generic;
using System.Threading.Tasks;
using Books.App.Core.Storage.Models;

namespace Books.App.Providers.Contracts
{
    public interface ILocalDbProvider
    {
        Task<BookModel> GetBook();
        Task<IEnumerable<BookModel>> GetAllBooks();
        Task<IEnumerable<BookModel>> GetRecentBooks(int days);
        Task SaveBook(BookModel book);
    }
}