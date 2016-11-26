namespace Books.App.Providers.Contracts
{
    using System.Threading.Tasks;
    using System.Collections.Generic;
    
    using Models.Database;

    public interface IDbBookProvider
    {
        Task<BookModel> GetBook();
        Task<IEnumerable<BookModel>> GetAllBooks();
        Task<IEnumerable<BookModel>> GetRecentBooks(int days);
        Task SaveBook(BookModel book);
    }
}