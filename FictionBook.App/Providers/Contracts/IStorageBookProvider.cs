namespace Books.App.Providers.Contracts
{
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Models.Database;

    public interface IStorageBookProvider
    {
        Task<IEnumerable<BookModel>> ImportBooks();
        Task<BookModel> ImportBook();

        Task<string> SaveBookToFolder(string fileName, string directory, byte[] book, byte[] cover);

        Task DeleteBook(BookModel book);
        Task DeleteBooks(IEnumerable<BookModel> books);
    }
}