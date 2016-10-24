using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Xml.Linq;
using Library.FictionBook.Core;
using Library.FictionBook.Models.Author;
using Library.FictionBook.Models.Core;
using Library.FictionBook.Models.Interfaces;

namespace Library.FictionBook.Models.Header
{
    public class DocumentInfoModel : IModel
    {
        #region Private Members

        private readonly List<AuthorModel> _authors = new List<AuthorModel>();
        private readonly List<PublisherModel> _publishers = new List<PublisherModel>();
        private readonly List<ValueModel> _sourceUrLs = new List<ValueModel>();

        private ValueModel _id = new ValueModel();

        #endregion
        
        public IEnumerable<AuthorModel> Authors => _authors;
        public IEnumerable<PublisherModel> Publishers => _publishers;     
        public IEnumerable<ValueModel> SourceUrl => _sourceUrLs;
        public TextFieldModel SourceOcr { get; set; }
        public TextFieldModel ProgramUsed { set; get; }
        public DateModel Date { set; get; }
        public ValueModel Id
        {
            get
            {
                if (!string.IsNullOrEmpty(_id.Value))
                {
                    return _id;
                }
                return _id;
            }
            set {
                _id = !string.IsNullOrEmpty(value.Value) ? value : value;
            }
        }
        public float? Version { get; set; }
        public AnnotationModel History { get; set; }

        #region Implementation of IModel

        public XNamespace BookNamespace { get; set; }

        public void Load(XNode documentInfo)
        {
            Clear();

            var eDocumentInfo = documentInfo as XElement;

            if (eDocumentInfo == null)
                throw new ArgumentNullException(nameof(eDocumentInfo));

            #region Authors

            _authors.AddRange(eDocumentInfo.Elements(BookNamespace + FictionBookConstants.Author).To<AuthorModel>(BookNamespace));

            #endregion

            #region ProgramUsed

            ProgramUsed = eDocumentInfo.Element(BookNamespace + FictionBookSchemaConstants.ProgramUsed).To<TextFieldModel>(BookNamespace);

            #endregion

            #region Date

            Date = eDocumentInfo.Element(BookNamespace + FictionBookConstants.Date).To<DateModel>(BookNamespace);

            #endregion

            #region SourceUrl

            _sourceUrLs.AddRange(eDocumentInfo.Elements(BookNamespace + FictionBookSchemaConstants.SourceUrl).To<ValueModel>(BookNamespace));

            #endregion

            #region SourceOcr

            SourceOcr = eDocumentInfo.Element(BookNamespace + FictionBookSchemaConstants.SourceOcr).To<TextFieldModel>(BookNamespace);

            #endregion

            #region Id

            Id = eDocumentInfo.Element(BookNamespace + FictionBookSchemaConstants.Id).To<ValueModel>(BookNamespace);

            #endregion

            #region Version

            var documentVersionValue = eDocumentInfo.Element(BookNamespace + FictionBookSchemaConstants.Version).To<ValueModel>(BookNamespace);
            try
            {
                var cult = new CultureInfo("");

                Version = float.Parse(documentVersionValue.Value, cult.NumberFormat);
            }
            catch (FormatException ex)
            {
                Debug.WriteLine(string.Format("Error reading document version : {0}", ex.Message));
            }

            #endregion

            #region History

            History = eDocumentInfo.Element(BookNamespace + FictionBookSchemaConstants.History).To<AnnotationModel>(BookNamespace);

            #endregion

            #region Publishers

            _publishers.AddRange(eDocumentInfo.Elements(BookNamespace + FictionBookConstants.Author).To<PublisherModel>(BookNamespace));

            #endregion
        }
        public XNode Save(string name = "")
        {
            var documentInfo = new XElement(FictionBookSchemaConstants.DefaultNamespace + FictionBookConstants.DocumentInfo);

            #region Authors

            foreach (var author in _authors)
                documentInfo.Add(author.Save());

            #endregion

            #region ProgramUsed

            if (ProgramUsed != null)
                documentInfo.Add(ProgramUsed.Save(FictionBookSchemaConstants.ProgramUsed));

            #endregion

            #region Date

            if (Date != null)
                documentInfo.Add(Date.Save());

            #endregion

            #region SourceUrl

            foreach (var srcUrl in _sourceUrLs)
                documentInfo.Add(srcUrl.Save());

            #endregion

            #region SourceOcr

            if (SourceOcr != null)
                documentInfo.Add(SourceOcr.Save(FictionBookSchemaConstants.SourceOcr));

            #endregion

            #region Id  

            if (!string.IsNullOrEmpty(Id?.Value))
                documentInfo.Add(Id.Save(FictionBookSchemaConstants.Id));

            #endregion

            #region Version

            if (Version != null)
                documentInfo.Add(string.Format(new CultureInfo("").NumberFormat, "{0:F}", Version).ToFictionElement(FictionBookSchemaConstants.Version));

            #endregion

            #region History

            if (History != null)
            {
                documentInfo.Add(History.Save());
            }

            #endregion

            #region Publishers

            foreach (var publish in _publishers)
                documentInfo.Add(publish.Save());

            #endregion

            return documentInfo;
        }

        public void Clear()
        {
            _authors.Clear();
            _publishers.Clear();
            _sourceUrLs.Clear();

            SourceOcr = null;
            ProgramUsed = null;
            Date = null;
            Id = null;
            Version = null;
            History = null;
        }

        #endregion
    }
}