using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Windows.Storage;
using Windows.Storage.Pickers;
using Books.App.Core.Storage.Models;
using Books.App.Providers.Contracts;
using Microsoft.Toolkit.Uwp;

namespace Books.App.Providers
{
    public class BookProvider : IBookProvider
    {
        #region Private Members

        private readonly ILocalDbProvider _localDbProvider;

        #endregion

        public BookProvider(ILocalDbProvider localDbProvider)
        {
            _localDbProvider = localDbProvider;
        }

        public async Task<BookModel> GetBookFromFile()
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
                var author = book.Description.TitleInfo.Author[0].Items.Select(x => x.Text).Aggregate((current, next) => current + " " + next);

                var cover = book.Binary.FirstOrDefault(x => x.Id == book.Description.TitleInfo.Coverpage[0].Href.Replace("#", "")).Value;


                var bookId = Guid.NewGuid();
                bookModel = new BookModel
                {
                    Id = bookId,
                    Author = author,
                    Title = title,
                    LastOpenedTime = DateTime.Now
                };

                var bookPath = await SaveBook(pickedFile.Name, book, bookModel, cover);

                bookModel.BookPath = bookPath;
                bookModel.CoverPath = $"{bookPath}.png";

                await _localDbProvider.SaveBook(bookModel);
            }
            catch (Exception ex)
            {

            }

            return bookModel;
        }
        public async Task<IEnumerable<BookModel>> GetBooksFromFolder()
        {
            var folderPicker = new FolderPicker()
            {
                FileTypeFilter = {".fb2"}
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


                    var bookId = Guid.NewGuid();
                    var bookModel = new BookModel
                    {
                        Id = bookId,
                        Author = author,
                        Title = title,
                        LastOpenedTime = DateTime.Now
                    };

                    var bookPath = await SaveBook(pickedFolderFile.Name, book, bookModel, cover);

                    bookModel.BookPath = bookPath;
                    bookModel.CoverPath = $"{bookPath}.png";

                    await _localDbProvider.SaveBook(bookModel);

                    loadedBooks.Add(bookModel);
                }
                catch (Exception ex)
                {

                }
            }

            return loadedBooks;
        }

        private async Task<string> SaveBook(string fileName, FictionBook.Library.FictionBook book, BookModel bookModel, byte[] cover)
        {
            var localFolder = ApplicationData.Current.LocalFolder;
            localFolder = await localFolder.CreateFolderAsync("Books", CreationCollisionOption.OpenIfExists);
            localFolder = await localFolder.CreateFolderAsync(bookModel.Id.ToString(), CreationCollisionOption.OpenIfExists);

            await localFolder.WriteBytesToFileAsync(Serialize(book), fileName);
            await localFolder.WriteBytesToFileAsync(cover, fileName + ".png");

            return $@"Books\{bookModel.Id}\{fileName}";
        }

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
    }
}