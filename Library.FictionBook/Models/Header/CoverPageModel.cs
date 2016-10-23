using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Library.FictionBook.Core.Extensions;
using Library.FictionBook.Models.Core;
using Library.FictionBook.Models.Interfaces;
using Library.FictionBook.Models.Style;

namespace Library.FictionBook.Models.Header
{
    public class CoverPageModel : IModel
    {
        #region Private Members

        private readonly List<InlineImageModel> _images = new List<InlineImageModel>();

        #endregion

        public bool HasImages => _images.Count > 0;
        public IEnumerable<InlineImageModel> CoverpageImages => _images;

        public IEnumerable<Exception> Exceptions => null;

        public XNamespace BookNamespace { get; set; }

        public void Load(XNode coverpage)
        {
            _images.Clear();

            var eCoverpage = coverpage as XElement;

            if (eCoverpage == null)
                throw new ArgumentNullException(nameof(eCoverpage));

            if (eCoverpage.Name.LocalName.IsNot(FictionBookConstants.CoverPage))
                throw new ArgumentException("Element of wrong type passed", nameof(eCoverpage));

            IEnumerable<XElement> images = eCoverpage.Elements(BookNamespace + FictionBookConstants.InlineImage);

            foreach (var image in images)
            {
                var model = new InlineImageModel();

                try
                {
                    model.Load(image);
                    _images.Add(model);
                }
                catch (Exception)
                {
                    //
                }
            }
        }
        public XNode Save(string name = "")
        {
            var coverPage = new XElement(FictionBookSchemaConstants.DefaultNamespace + FictionBookConstants.CoverPage);

            foreach (var image in _images)
            {
                coverPage.Add(image.Save());
            }

            return coverPage;
        }
    }
}