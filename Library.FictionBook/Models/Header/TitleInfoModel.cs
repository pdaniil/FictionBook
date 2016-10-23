using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Linq;
using Library.FictionBook.Models.Core;
using Library.FictionBook.Models.Interfaces;
using Library.FictionBook.Core.Extensions;
using Library.FictionBook.Models.Author;

namespace Library.FictionBook.Models.Header
{
    public class TitleInfoModel : IModel
    {
        #region Private Members

        private readonly List<SequenceModel> _sequences = new List<SequenceModel>();

        private readonly List<AuthorModel> _bookAuthors = new List<AuthorModel>();
        private readonly List<TranslatorModel> _translators = new List<TranslatorModel>();

        private readonly List<TitleGenreModel> _genres = new List<TitleGenreModel>();

        #endregion
        
        public IEnumerable<TitleGenreModel> Genres => _genres;

        public IEnumerable<AuthorModel> BookAuthors => _bookAuthors;
        public IEnumerable<TranslatorModel> Translators => _translators;

        public IEnumerable<SequenceModel> Sequences => _sequences;

        public TextFieldModel BookTitle { set; get; }
        public DateModel BookDate { get; set; }

        public CoverPageModel CoverPage { get; set; }

        public AnnotationModel Annotation { set; get; }
        public TextFieldModel Keywords { get; set; }

        public string Language { set; get; }
        public string SrcLanguage { get; set; }

        public IEnumerable<Exception> Exceptions => null;
        public XNamespace BookNamespace { get; set; }

        public void Load(XNode titleInfo)
        {
            _genres.Clear();
            _bookAuthors.Clear();
            _translators.Clear();
            _sequences.Clear();

            var eTitleInfo = titleInfo as XElement;

            if (eTitleInfo == null)
                throw new ArgumentNullException(nameof(eTitleInfo));

            #region Genres

            _genres.AddRange(eTitleInfo.Elements(BookNamespace + FictionBookConstants.Genre).To<TitleGenreModel>(BookNamespace));
            
            #endregion

            #region Authors

            _bookAuthors.AddRange(eTitleInfo.Elements(BookNamespace + FictionBookConstants.Author).To<AuthorModel>(BookNamespace));

            #endregion

            #region Title

            BookTitle = eTitleInfo.Element(BookNamespace + FictionBookConstants.BookTitle).To<TextFieldModel>(BookNamespace);

            #endregion

            #region Annotation

            Annotation = eTitleInfo.Element(BookNamespace + FictionBookConstants.Annotation).To<AnnotationModel>(BookNamespace);

            #endregion

            #region Keyword

            Keywords = eTitleInfo.Element(BookNamespace + FictionBookConstants.Keywords).To<TextFieldModel>(BookNamespace);

            #endregion

            #region BookDate

            BookDate = eTitleInfo.Element(BookNamespace + FictionBookConstants.Date).To<DateModel>(BookNamespace);

            #endregion

            #region CoverPage

            CoverPage = eTitleInfo.Element(BookNamespace + FictionBookConstants.CoverPage).To<CoverPageModel>(BookNamespace);

            #endregion

            #region Language

            var language = eTitleInfo.Element(BookNamespace + FictionBookConstants.Language);

            if (language != null)
                Language = language.Value;
            else
                Debug.WriteLine("Language not specified in title section");

            #endregion

            #region SourceLanguage

            var sourceLanguage = eTitleInfo.Element(BookNamespace + FictionBookConstants.SourceLanguage);

            if (sourceLanguage != null)
                SrcLanguage = sourceLanguage.Value;
            else
                Debug.WriteLine("SourceLanguage not specified in title section");

            #endregion

            #region Translators

            _translators.AddRange(eTitleInfo.Elements(BookNamespace + FictionBookConstants.Translator).To<TranslatorModel>(BookNamespace));

            #endregion

            #region Sequences

            _sequences.AddRange(eTitleInfo.Elements(BookNamespace + FictionBookConstants.Sequence).To<SequenceModel>(BookNamespace));

            #endregion

        }
        public XNode Save(string name)
        {
            var titleInfo = new XElement(FictionBookSchemaConstants.DefaultNamespace + FictionBookConstants.TitleInfo);

            foreach (var genre in _genres)
            {
                try
                {
                    titleInfo.Add(genre.Save());
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(string.Format("Error converting genre data to XML: {0}", ex.Message));
                }
            }

            foreach (var author in _bookAuthors)
            {
                try
                {
                    titleInfo.Add(author.Save(FictionBookConstants.Author));
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(string.Format("Error converting genre data to XML: {0}", ex.Message));
                }
            }

            if (BookTitle != null)
                titleInfo.Add(BookTitle.Save(FictionBookConstants.BookTitle));

            if (Annotation != null)
                titleInfo.Add(Annotation.Save());

            if (Keywords != null)
                titleInfo.Add(Keywords.Save(FictionBookConstants.Keywords));

            if (BookDate != null)
                titleInfo.Add(BookDate.Save());

            if (CoverPage != null)
                titleInfo.Add(CoverPage.Save());

            if (!string.IsNullOrEmpty(Language))
                titleInfo.Add(Language.ToFictionElement(FictionBookSchemaConstants.DefaultNamespace + FictionBookConstants.Language));

            if (!string.IsNullOrEmpty(SrcLanguage))
                titleInfo.Add(SrcLanguage.ToFictionElement(FictionBookSchemaConstants.DefaultNamespace + FictionBookConstants.SourceLanguage));

            foreach (var translator in _translators)
                titleInfo.Add(translator.Save());

            foreach (var sequence in _sequences)
                titleInfo.Add(sequence.Save());

            return titleInfo;
        }
    }
}