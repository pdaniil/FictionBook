using System.Collections.Generic;
using System.Threading.Tasks;
using Books.App.Core.Storage.Models;

namespace Books.App.Providers.Contracts
{
    public interface IBookProvider
    {
        Task<IEnumerable<BookModel>> GetBooksFromFolder();
        Task<BookModel> GetBookFromFile();
    }
}