namespace Books.App.Providers.Contracts
{
    using System;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    
    using Models.Database;

    public interface IDbBookProvider
    {
        Task<BookModel> GetBook(Guid bookId);
        Task<IEnumerable<BookModel>> GetBooks();
        Task<IEnumerable<BookModel>> GetBooks(int days);

        Task DeleteBook(BookModel book);
        Task DeleteBooks(IEnumerable<BookModel> books);

        Task SaveBook(BookModel book);
    }
}