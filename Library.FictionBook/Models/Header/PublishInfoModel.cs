using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Library.FictionBook.Core;
using Library.FictionBook.Models.Core;
using Library.FictionBook.Models.Interfaces;

namespace Library.FictionBook.Models.Header
{
    public class PublishInfoModel : IModel
    {
        #region Private Members

        private readonly List<SequenceModel> _sequences = new List<SequenceModel>();

        #endregion

        public IEnumerable<SequenceModel> Sequences => _sequences;

        public TextFieldModel BookTitle { set; get; }
        public TextFieldModel Isbn { get; set; }
        public int? Year { get; set; }
        public TextFieldModel City { get; set; }
        public TextFieldModel Publisher { get; set; }

        #region IModel implementation

        public XNamespace BookNamespace { get; set; }

        public void Load(XNode publishInfo)
        {
            Clear();

            var ePublishInfo = publishInfo as XElement;

            if (ePublishInfo == null)
                throw new ArgumentNullException(nameof(ePublishInfo));

            #region BookTitle

            BookTitle = ePublishInfo.Element(BookNamespace + FictionBookConstants.BookName).To<TextFieldModel>(BookNamespace);

            #endregion

            #region Publisher

            Publisher = ePublishInfo.Element(BookNamespace + FictionBookConstants.Publisher).To<TextFieldModel>(BookNamespace);

            #endregion

            #region City

            City = ePublishInfo.Element(BookNamespace + FictionBookConstants.City).To<TextFieldModel>(BookNamespace);

            #endregion

            #region Year

            int year;
            var eYear = ePublishInfo.Element(BookNamespace + FictionBookConstants.Year).To<ValueModel>(BookNamespace);

            if (int.TryParse(eYear.Value, out year))
            {
                Year = year;
            }

            #endregion

            #region Isbn

            Isbn = ePublishInfo.Element(BookNamespace + FictionBookConstants.Isbn).To<TextFieldModel>(BookNamespace);

            #endregion

            #region Sequences

            _sequences.AddRange(ePublishInfo.Elements(BookNamespace + FictionBookConstants.Sequence).To<SequenceModel>(BookNamespace));

            #endregion
        }
        public XNode Save(string name = "")
        {
            var publishInfo = new XElement(FictionBookSchemaConstants.DefaultNamespace + FictionBookConstants.PublishInfo);

            #region BookTitle

            if (BookTitle != null)
                publishInfo.Add(BookTitle.Save(FictionBookConstants.BookName));

            #endregion

            #region Publisher

            if (Publisher != null)
                publishInfo.Add(Publisher.Save(FictionBookConstants.Publisher));

            #endregion

            #region City

            if (City != null)
                publishInfo.Add(City.Save(FictionBookConstants.City));

            #endregion

            #region Year

            if (Year != null)
                publishInfo.Add(Year.ToString().ToFictionElement(FictionBookSchemaConstants.DefaultNamespace + FictionBookConstants.Year));

            #endregion

            #region Isbn

            if (Isbn != null)
                publishInfo.Add(Isbn.Save(FictionBookConstants.Isbn));

            #endregion

            #region Sequences

            foreach (var sequence in _sequences)
                publishInfo.Add(sequence.Save());

            #endregion

            return publishInfo;
        }

        public void Clear()
        {
            BookTitle = null;
            Isbn = null;
            Year = null;
            City = null;
            Publisher = null;
            _sequences.Clear();
        }

        #endregion
    }
}