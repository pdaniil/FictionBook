namespace Books.App.Providers.Contracts
{
    using System;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    
    using Models.Database;

    public interface IDbBookProvider
    {
        Task<BookModel> GetBook(Guid bookId);
        Task<IEnumerable<BookModel>> GetAllBooks();
        Task<IEnumerable<BookModel>> GetRecentBooks(int days);

        Task DeleteBook(BookModel book);
        Task DeleteBooks(IEnumerable<BookModel> books);

        Task SaveBook(BookModel book);
    }
}