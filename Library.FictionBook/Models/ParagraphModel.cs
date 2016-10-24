using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Library.FictionBook.Core;
using Library.FictionBook.Models.Core;
using Library.FictionBook.Models.Interfaces;

namespace Library.FictionBook.Models
{
    public class ParagraphModel : IModel
    {
        #region Private Members

        private readonly List<IStyle> _content = new List<IStyle>();

        #endregion

        public string Id { get; set; }
        public string Style { get; set; }
        public string Lang { get; set; }

        public List<IStyle> ParagraphData => _content;

        public XNamespace BookNamespace { get; set; }
        public IEnumerable<Exception> Exceptions { get; }

        public void Load(XNode paragraph)
        {
            _content.Clear();

            var eParagraph = paragraph as XElement;

            if (eParagraph == null)
                throw new ArgumentNullException(nameof(eParagraph));

            if (eParagraph.Name.LocalName.Is(FictionBookConstants.Paragraph))
                throw new ArgumentException("Element of wrong type passed", nameof(eParagraph));

            if (eParagraph.HasElements)
            {
                var nodes = eParagraph.Nodes();

                foreach (var node in nodes)
                {
                    try
                    {
                        if (node.NodeType == XmlNodeType.Element && !IsSimpleText(node))
                        {
                            var element = node as XElement;

                            var style = element.ResolveStyle();
                            style.Load(element);

                            _content.Add(style);
                        }
                        else
                        {
                            IStyle text = ModelFactory.ResolveStyle("SimpleText");

                            text.Load(node);
                            _content.Add(text);

                        }
                    }
                    catch (Exception)
                    {
                        //
                    }
                }

            }
            else if (!string.IsNullOrEmpty(eParagraph.Value))
            {
                IStyle text = ModelFactory.ResolveStyle("SimpleText");

                text.Load(eParagraph);
                _content.Add(text);
            }

            Id = eParagraph.FictionAttribute(FictionBookConstants.Id);
            Style = eParagraph.FictionAttribute(FictionBookConstants.Style);
            Lang = eParagraph.FictionAttribute(XNamespace.Xml + FictionBookConstants.Language);
        } 
        public XNode Save(string name)
        {
            XElement paragraph = new XElement(FictionBookSchemaConstants.DefaultNamespace + FictionBookConstants.Paragraph);

            if (!string.IsNullOrEmpty(Id))
                paragraph.Add(Id.ToFictionAttribute(FictionBookConstants.Id));

            if (!string.IsNullOrEmpty(Style))
                paragraph.Add(Style.ToFictionAttribute(FictionBookConstants.Style));

            if (!string.IsNullOrEmpty(Lang))
            {
                paragraph.Add(Lang.ToFictionAttribute(XNamespace.Xml + FictionBookConstants.Language));
            }

            foreach (IStyle node in _content)
                paragraph.Add(node.Save());

            return paragraph;
        }

        private bool IsSimpleText(XNode node)
        {
            if (node.NodeType != XmlNodeType.Element)
                return true;

            var element = node as XElement;

            if (element.Name.LocalName.Is(FictionBookConstants.InternalLink) ||
                element.Name.LocalName.Is(FictionBookConstants.InlineImage))
                return false;

            return true;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var textItem in _content)
            {
                builder.Append(textItem.ToString());
                builder.Append(" ");
            }
            return builder.ToString();
        }
    }
}