using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Library.FictionBook.Core;
using Library.FictionBook.Models.Core;
using Library.FictionBook.Models.Interfaces;

namespace Library.FictionBook.Models.Style
{
    public class InternalLinkModel : IStyle
    {
        public SimpleTextModel Text { get; set; } = new SimpleTextModel();

        public string Type { get; set; }
        public string Href { get; set; }

        public IEnumerable<Exception> Exceptions => null;

        public XNamespace BookNamespace { get; set; }

        public void Load(XNode link)
        {
            var eLink = link as XElement;

            if (eLink == null)
                throw new ArgumentNullException(nameof(eLink));

            if (eLink.Name.LocalName.IsNot(FictionBookConstants.InternalLink))
                throw new ArgumentException("Element of wrong type passed", nameof(eLink));

            try
            {
                Text.Load(eLink);
            }
            catch (Exception)
            {
                Text = null;
            }

            Type = eLink.FictionAttribute(FictionBookSchemaConstants.LinkNamespace + FictionBookConstants.Type);
            Href = eLink.FictionAttribute(FictionBookSchemaConstants.LinkNamespace + FictionBookConstants.Href);
        }
        public XNode Save(string name)
        {
            var link = new XElement(FictionBookSchemaConstants.DefaultNamespace + FictionBookConstants.InternalLink);

            if (!string.IsNullOrEmpty(Type))
                link.Add(Type.ToFictionAttribute(FictionBookSchemaConstants.LinkNamespace + FictionBookConstants.Type));

            if (!string.IsNullOrEmpty(Href))
                link.Add(Href.ToFictionAttribute(FictionBookSchemaConstants.LinkNamespace + FictionBookConstants.Href));

            if (Text != null)
                link.Add(Text.Save(string.Empty));

            return link;
        }
    }
}