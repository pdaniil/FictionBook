using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Library.FictionBook.Core;
using Library.FictionBook.Models.Core;
using Library.FictionBook.Models.Interfaces;

namespace Library.FictionBook.Models
{
    public class GenreModel : IModel
    {
        #region PrivateMembers

        private int _match = 100;

        #endregion

        public int Match
        {
            get { return _match; }
            set { _match = value > 0 && value <= 100 ? value : 100; }
        }
        public string Genre { get; set; }

        public IEnumerable<Exception> Exceptions => null;

        public XNamespace BookNamespace { get; set; }

        public void Load(XNode genre)
        {
            var eGenre = genre as XElement;

            if(eGenre == null)
                throw new ArgumentNullException(nameof(eGenre));

            Genre = eGenre.Value;

            var match = eGenre.Attribute("match");

            if (!string.IsNullOrEmpty(match?.Value))
            {
                int percentage;
                if (int.TryParse(match.Value, out percentage))
                {
                    Match = percentage;
                }
            }
        }
        public XNode Save(string name = "")
        {
            if (string.IsNullOrEmpty(Genre))
                throw new ArgumentException("Genre is empty");

            var genre = new XElement(FictionBookSchemaConstants.DefaultNamespace + FictionBookConstants.Genre, Genre);

            if (_match > 0 && _match < 100)
                genre.Add(_match.ToString().ToFictionAttribute("match"));

            return genre;
        }
    }
}
