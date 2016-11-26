namespace Books.App.Providers
{
    using System;
    using System.IO;
    using System.Xml;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Xml.Serialization;
    using System.Collections.Generic;

    using Windows.Storage;
    using Windows.Storage.Pickers;

    using Microsoft.Toolkit.Uwp;

    using Contracts;
    using Models.Database;

    public class LocalBookProvider 
        : IBookProvider
    {
        #region Private Members

        private readonly IDbBookProvider _localDbBookProvider;

        #endregion

        public LocalBookProvider(IDbBookProvider localDbBookProvider)
        {
            _localDbBookProvider = localDbBookProvider;
        }


        #region Importing books

        public async Task<BookModel> ImportBookFromFile()
        {
            var filePicker = new FileOpenPicker()
            {
                FileTypeFilter = { ".fb2" }
            };

            var pickedFile = await filePicker.PickSingleFileAsync();

            BookModel bookModel = null;

            try
            {
                var book = Deserialize<FictionBook.Library.FictionBook>(await pickedFile.OpenStreamForReadAsync());

                var title = book.Description.TitleInfo.BookTitle.Text;
                var author =
                    book.Description.TitleInfo.Author[0].Items.Select(x => x.Text)
                        .Aggregate((current, next) => current + " " + next);

                var cover =
                    book.Binary.FirstOrDefault(
                        x => x.Id == book.Description.TitleInfo.Coverpage[0].Href.Replace("#", "")).Value;


                bookModel = new BookModel
                {
                    Id = Guid.NewGuid(),
                    Author = author,
                    Title = title,
                    LastOpenedTime = DateTime.Now
                };

                var bookPath = await SaveBookToFolder(pickedFile.Name, bookModel.Id.ToString(), Serialize(book), cover);

                bookModel.BookPath = bookPath;
                bookModel.CoverPath = $"{bookPath}.png";
                bookModel.FolderPath = bookModel.Id.ToString();

                await _localDbBookProvider.SaveBook(bookModel);
            }
            catch (Exception)
            {
                //
            }

            return bookModel;
        }
        public async Task<IEnumerable<BookModel>> ImportBooksFromFolder()
        {
            var folderPicker = new FolderPicker()
            {
                FileTypeFilter = { ".fb2" }
            };

            var pickedFolder = await folderPicker.PickSingleFolderAsync();
            var pickedFoderFiles = await pickedFolder.GetFilesAsync();

            var loadedBooks = new List<BookModel>();

            foreach (var pickedFolderFile in pickedFoderFiles)
            {
                try
                {
                    var book =
                        Deserialize<FictionBook.Library.FictionBook>(await pickedFolderFile.OpenStreamForReadAsync());

                    var title = book.Description.TitleInfo.BookTitle.Text;
                    var author =
                        book.Description.TitleInfo.Author[0].Items.Select(x => x.Text)
                            .Aggregate((current, next) => current + " " + next);

                    var cover =
                        book.Binary.FirstOrDefault(
                            x => x.Id == book.Description.TitleInfo.Coverpage[0].Href.Replace("#", "")).Value;

                    var bookModel = new BookModel
                    {
                        Id = Guid.NewGuid(),
                        Author = author,
                        Title = title,
                        LastOpenedTime = DateTime.Now
                    };

                    var bookPath = await SaveBookToFolder(pickedFolderFile.Name, bookModel.Id.ToString(), Serialize(book), cover);

                    bookModel.BookPath = bookPath;
                    bookModel.CoverPath = $"{bookPath}.png";
                    bookModel.FolderPath = bookModel.Id.ToString();

                    await _localDbBookProvider.SaveBook(bookModel);

                    loadedBooks.Add(bookModel);
                }
                catch (Exception)
                {
                    //
                }
            }

            return loadedBooks;
        }

        #endregion

        #region Saving books

        public async Task<string> SaveBookToFolder(string fileName, string directory, byte[] book, byte[] cover)
        {
            var localFolder = ApplicationData.Current.LocalFolder;
            localFolder = await localFolder.CreateFolderAsync("Books", CreationCollisionOption.OpenIfExists);
            localFolder = await localFolder.CreateFolderAsync(directory, CreationCollisionOption.OpenIfExists);

            await localFolder.WriteBytesToFileAsync(book, fileName);
            await localFolder.WriteBytesToFileAsync(cover, fileName + ".png");

            return $@"Books\{directory}\{fileName}";
        }

        #endregion

        #region Deleting books

        public async Task DeleteBook(BookModel book)
        {
            var localFolder = ApplicationData.Current.LocalFolder;
            localFolder = await localFolder.GetFolderAsync("Books");
            localFolder = await localFolder.GetFolderAsync(book.FolderPath);

            await localFolder.DeleteAsync(StorageDeleteOption.PermanentDelete);
        }
        public async Task DeleteBooks(IEnumerable<BookModel> books)
        {
            foreach (var book in books)
            {
                var localFolder = ApplicationData.Current.LocalFolder;
                localFolder = await localFolder.GetFolderAsync("Books");
                localFolder = await localFolder.GetFolderAsync(book.FolderPath);

                await localFolder.DeleteAsync(StorageDeleteOption.PermanentDelete);
            }
        }

        #endregion

        #region Loading books

        public async Task<FictionBook.Library.FictionBook> LoadBook(BookModel bookModel)
        {
            var localFolder = ApplicationData.Current.LocalFolder;
            var book = Deserialize<FictionBook.Library.FictionBook>(await localFolder.OpenStreamForReadAsync(bookModel.BookPath));

            return book;
        }

        #endregion


        #region Serialize/Deserialize

        private byte[] Serialize<T>(T model)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            var ms = new MemoryStream();

            var setting = new XmlWriterSettings()
            {
                CheckCharacters = true
            };

            using (var writer = XmlWriter.Create(ms, setting))
            {

                xmlSerializer.Serialize(ms, model);
                return ms.ToArray();
            }
        }
        private T Deserialize<T>(Stream stream)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));

            var settings = new XmlReaderSettings
            {
                CheckCharacters = true,
                IgnoreComments = true,
                IgnoreWhitespace = true
            };

            using (var reader = XmlReader.Create(stream, settings))
            {
                var result = (T)xmlSerializer.Deserialize(reader);
                return result;
            }
        }

        #endregion
    }
}