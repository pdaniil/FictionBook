namespace Books.App.Providers.Contracts
{
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Models.Database;

    public interface IBookProvider
    {
        Task<IEnumerable<BookModel>> LoadBooksFromFolder();
        Task<BookModel> LoadBookFromFile();

        Task<string> SaveBookToFolder(string fileName, string directory, byte[] book, byte[] cover);

        Task DeleteBook(BookModel book);
    }
}