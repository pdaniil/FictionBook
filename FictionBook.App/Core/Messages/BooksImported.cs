using System.Collections.Generic;
using Books.App.Models.Database;

namespace Books.App.Core.Messages
{
    public class BooksImported
    {
        #region Private Members

        private readonly List<BookModel> _value = new List<BookModel>();

        #endregion

        public BooksImported(BookModel book)
        {
            _value.Add(book);
        }
        public BooksImported(IEnumerable<BookModel> books)
        {
            _value.AddRange(books);
        }

        public IEnumerable<BookModel> Value => _value;
    }
}