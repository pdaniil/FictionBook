using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using Library.FictionBook.Core;
using Library.FictionBook.Models.Core;
using Library.FictionBook.Models.Interfaces;

namespace Library.FictionBook.Models
{
    public class AnnotationModel : IModel
    {
        #region Private Members

        private readonly List<IModel> _content = new List<IModel>();

        #endregion

        public string Id { set; get; }

        public List<IModel> Content => _content;

        #region Implementation of IModel

        public XNamespace BookNamespace { get; set; }

        public void Load(XNode annotation)
        {
            Clear();

            var eAnnotation = annotation as XElement;

            if (eAnnotation == null)
                throw new ArgumentNullException(nameof(eAnnotation));

            if (eAnnotation.Name.LocalName.IsNot(FictionBookConstants.Annotation))
                throw new ArgumentException("Element of wrong type passed", nameof(eAnnotation));

            #region Content

            IEnumerable<XElement> models = eAnnotation.Elements();

            foreach (var model in models)
            {
                IModel node = model.Resolve();
                node.Load(model);

                _content.Add(node);
            }

            #endregion

            #region Id

            var id = eAnnotation.Attribute("id");
            if (id?.Value != null)
                Id = id.Value;

            #endregion
        }
        public XNode Save(string name = "")
        {
            var annotation = new XElement(FictionBookSchemaConstants.DefaultNamespace + FictionBookConstants.Annotation);

            #region Content

            foreach (IModel model in _content)
                annotation.Add(model.Save());

            #endregion

            #region Id

            if (Id != null)
                annotation.Add(Id.ToFictionAttribute(FictionBookConstants.Id));

            #endregion

            return annotation;
        }

        public void Clear()
        {
            Id = null;
            _content.Clear();
        }

        #endregion

        #region Overrides

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var textItem in _content)
            {
                builder.Append(textItem);
                builder.Append(" ");
            }
            return builder.ToString();
        }

        #endregion
    }
}
