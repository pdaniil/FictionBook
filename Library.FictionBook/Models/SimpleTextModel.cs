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
    public class SimpleTextModel : IModel
    {
        #region Private Members

        private TextStyle _style = TextStyle.Normal;
        private readonly List<IStyle> _content = new List<IStyle>();

        #endregion

        public string Text { get; set; }
        public List<IStyle> Children => _content;
        public TextStyle Style
        {
            get { return _style; }
            set { _style = value; }
        }

        public bool HasChildren => _content.Count > 0;

        public IEnumerable<Exception> Exceptions => null;

        public XNamespace BookNamespace { get; set; }

        public void Load(XNode text)
        {
            _content.Clear();

            if (text == null)
                throw new ArgumentNullException(nameof(text));

            if (text.NodeType == XmlNodeType.Text)
            {
                var textNode = (XText)text;

                if (!string.IsNullOrEmpty(textNode.Value))
                {
                    Text = textNode.Value;
                    _style = TextStyle.Normal;
                }
            }
            else if (text.NodeType == XmlNodeType.Element)
            {
                var eText = (XElement)text;

                if (eText.HasElements)
                {
                    Text = string.Empty;
                    Style = eText.GetTextStyle();

                    var nodes = eText.Nodes();
                    foreach (var node in nodes)
                    {
                        try
                        {
                            if (node.NodeType == XmlNodeType.Element)
                            {
                                XElement element = (XElement)node;

                                var model = element.ResolveStyle();
                                model.Load(element);

                                _content.Add(model);
                            }
                            else
                            {
                                IStyle sText = ModelFactory.ResolveStyle("SimpleText");

                                sText.Load(node);
                                _content.Add(sText);

                            }
                        }
                        catch (Exception)
                        {
                            //
                        }
                    }
                }
                else
                {
                    _style = eText.GetTextStyle();
                    Text = eText.Value;
                }
            }
        }
        public XNode Save(string name)
        {
            if (string.IsNullOrEmpty(Text))
            {
                var simpleText = new XElement(FictionBookSchemaConstants.DefaultNamespace + _style.GetTextStyle());

                foreach (IStyle child in _content)
                {
                    simpleText.Add(child.Save());
                }

                return simpleText;
            }

            if (_style != TextStyle.Normal)
                return Text.ToFictionElement(FictionBookSchemaConstants.DefaultNamespace + _style.GetTextStyle());

            return new XText(Text);
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(Text))
            {
                StringBuilder builder = new StringBuilder();
                foreach (var textItem in _content)
                {
                    builder.Append(textItem.ToString());
                    builder.Append(" ");
                }
                return builder.ToString();
            }
            return Text;
        }
    }
}