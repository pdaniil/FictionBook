using System.IO;
using System.Xml;
using Library.FictionBook;

namespace Program
{
    class Loader
    {
        public async void Load()
        {
            FictionBookReader book = new FictionBookReader();

            using (var stream = new FileStream(@"I:\Mahouka.fb2", FileMode.Open, FileAccess.Read))
            {
                await book.ReadAsync(stream, new ReadSettings(new XmlReaderSettings()));
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
           var loader = new Loader();
            loader.Load();
        }
    }
}
