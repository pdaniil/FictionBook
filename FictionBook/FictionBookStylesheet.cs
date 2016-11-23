using System.Xml.Serialization;
using FictionBook.Library.Base;

namespace FictionBook.Library
{
    /// <summary>
    /// The fiction book stylesheet.
    /// </summary>
    [XmlType(AnonymousType = true, Namespace = "http://www.gribuser.ru/xml/fictionbook/2.0")]
    public class FictionBookStylesheet : BaseTextData
    {
        /// <summary>
        /// The type.
        /// </summary>
        [XmlAttribute("type")]
        public string Type { get; set; }

        /// <summary>
        /// The value.
        /// </summary>
        [XmlText]
        public override string Text { get; set; }
    }
}