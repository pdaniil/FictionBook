using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Windows.Graphics.Imaging;
using Windows.Storage.Pickers;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Caliburn.Micro;

namespace Books.App.ViewModels
{
    public class Book
    {
        public BitmapImage Cover { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
    }

    public sealed class LibraryPageViewModel
        : Screen
    {


        public BindableCollection<Book> Source { get; set; }

        public LibraryPageViewModel()
        {
            PickData();
        }


        public async void PickData()
        {
            Source = new BindableCollection<Book>();

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            

            var picker = new FolderPicker();
            picker.FileTypeFilter.Add(".fb2");

            var w = await picker.PickSingleFolderAsync();

            var files = await w.GetFilesAsync();
            foreach (var storageFile in files)
            {

                try
                {
                    var book = Deserialize<FictionBook.FictionBook>(await storageFile.OpenStreamForReadAsync());




                    MemoryStream ms = new MemoryStream(book.Binary.FirstOrDefault(x => x.Id == book.Description.TitleInfo.Coverpage[0].Href.Replace("#", "")).Value, true);
                    ms.Position = 0;

                    var image = new BitmapImage();
                    await image.SetSourceAsync(ms.AsRandomAccessStream());

                    Source.Add(new Book()
                    {
                        Name = book.Description.TitleInfo.BookTitle.Text,
                        Cover = image
                    });
                }
                catch (Exception ex)
                {
                    
                }

            }
        }

        public T Deserialize<T>(Stream stream)
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
                var result = (T) xmlSerializer.Deserialize(reader);
                return result;
            }
        }
    }
}