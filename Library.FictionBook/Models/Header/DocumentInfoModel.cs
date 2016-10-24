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

        public IEnumerable<Exception> Exceptions { get; }
        public XNamespace BookNamespace { get; set; }

        public void Load(XNode documentInfo)
        {
            var eDocumentInfo = documentInfo as XElement;


            if (eDocumentInfo == null)
                throw new ArgumentNullException(nameof(eDocumentInfo));

            _authors.Clear();

            _authors.AddRange(eDocumentInfo.Elements(BookNamespace + FictionBookConstants.Author).To<AuthorModel>(BookNamespace));

            ProgramUsed = eDocumentInfo.Element(BookNamespace + FictionBookSchemaConstants.ProgramUsed).To<TextFieldModel>(BookNamespace);

            Date = eDocumentInfo.Element(BookNamespace + FictionBookConstants.Date).To<DateModel>(BookNamespace);

            _sourceUrLs.AddRange(eDocumentInfo.Elements(BookNamespace + FictionBookSchemaConstants.SourceUrl).To<ValueModel>(BookNamespace));

            SourceOcr = eDocumentInfo.Element(BookNamespace + FictionBookSchemaConstants.SourceOcr).To<TextFieldModel>(BookNamespace);

            Id = eDocumentInfo.Element(BookNamespace + FictionBookSchemaConstants.Id).To<ValueModel>(BookNamespace);

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

            History = eDocumentInfo.Element(BookNamespace + FictionBookSchemaConstants.History).To<AnnotationModel>(BookNamespace);
            
            _publishers.AddRange(eDocumentInfo.Elements(BookNamespace + FictionBookConstants.Author).To<PublisherModel>(BookNamespace));
        }

        public XNode Save(string name = "")
        {
            var documentInfo = new XElement(FictionBookSchemaConstants.DefaultNamespace + FictionBookConstants.DocumentInfo);
            foreach (var author in _authors)
            {
                documentInfo.Add(author.Save(FictionBookConstants.Author));
            }

            if (ProgramUsed != null)
            {
                documentInfo.Add(ProgramUsed.Save(FictionBookSchemaConstants.ProgramUsed));
            }

            if (Date != null)
            {
                documentInfo.Add(Date.Save());
            }

            foreach (var srcUrl in _sourceUrLs)
            {
                documentInfo.Add(srcUrl.Save());
            }

            if (SourceOcr != null)
            {
                documentInfo.Add(SourceOcr.Save(FictionBookSchemaConstants.SourceOcr));
            }

            if (!string.IsNullOrEmpty(Id?.Value))
            {
                documentInfo.Add(Id.Save(FictionBookSchemaConstants.Id));
            }

            if (Version != null)
            {
                var cult = new CultureInfo("");
                documentInfo.Add(string.Format(cult.NumberFormat, "{0:F}", Version).ToFictionElement(FictionBookSchemaConstants.Version));
            }

            if (History != null)
            {
                documentInfo.Add(History.Save());
            }

            foreach (var publish in _publishers)
            {
                documentInfo.Add(publish.Save());
            }

            return documentInfo;
        }
    }
}