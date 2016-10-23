using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Threading.Tasks;

namespace Library.FictionBook
{
    public class FictionBookReader : IFictionBookReader
    {
        public Task<FictionBook> ReadAsync(string xml)
        {
            return Task.Factory.StartNew(() =>
            {
                var book = new FictionBook();
                book.Load(XDocument.Parse(xml));

                return book;
            });
        }

        public Task<FictionBook> ReadAsync(Stream stream, ReadSettings settings)
        {
            var book = new FictionBook();

            using (var reader = XmlReader.Create(stream, settings.Settings))
            {
                book.Load(XDocument.Load(reader, settings.Options));
            }
            
            return Task.FromResult(book);
        }
    }
}