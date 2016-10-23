using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Xml.Linq;
using Library.FictionBook.Core;
using Library.FictionBook.Core.Extensions;
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
        public IEnumerable<Exception> Exceptions => null;

        public XNamespace BookNamespace { get; set; }

        public void Load(XNode annotation)
        {
            var eAnnotation = annotation as XElement;

            _content.Clear();

            if (eAnnotation == null)
                throw new ArgumentNullException(nameof(eAnnotation));

            if (eAnnotation.Name.LocalName.IsNot(FictionBookConstants.Annotation))
                throw new ArgumentException("Element of wrong type passed", nameof(eAnnotation));

            
            IEnumerable<XElement> models = eAnnotation.Elements();

            foreach (var model in models)
            {
                IModel node = model.Resolve();
                node.Load(model);

                _content.Add(node);
            }

            var id = eAnnotation.Attribute("id");
            if (id?.Value != null)
                Id = id.Value;
        }
        public XNode Save(string name = "")
        {
            XElement annotation = new XElement(FictionBookSchemaConstants.DefaultNamespace + FictionBookConstants.Annotation);

            if (Id != null)
                annotation.Add(Id.ToFictionAttribute(FictionBookConstants.Id));

            foreach (IModel model in _content)
                annotation.Add(model.Save());

            return annotation;
        }

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
    }
}
