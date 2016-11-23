using System.Xml.Schema;
using System.Xml.Serialization;
using FictionBook.Library.Base;
using FictionBook.Library.Enum;

namespace FictionBook.Library.Formating
{
    /// <summary>
    /// The link type.
    /// </summary>
    [XmlType(Namespace = "http://www.gribuser.ru/xml/fictionbook/2.0")]
    public class LinkType : BaseFormatingStyle
    {
        /// <summary>
        /// The items.
        /// </summary>
        [XmlElement("emphasis", typeof(StyleLinkType))]
        [XmlElement("strong", typeof(StyleLinkType))]
        [XmlElement("style", typeof(StyleLinkType))]
        [XmlChoiceIdentifier("ItemsElementName")]
        public StyleLinkType[] Items { get; set; }

        /// <summary>
        /// The items element name.
        /// </summary>
        [XmlElement("ItemsElementName")]
        [XmlIgnore]
        public StyleLinkSupportedEnum[] ItemsElementName { get; set; }

        /// <summary>
        /// The text.
        /// </summary>
        [XmlText]
        public string[] Text { get; set; }

        /// <summary>
        /// The type.
        /// </summary>
        [XmlAttribute("type", Form = XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/xlink")]
        public string Type { get; set; } = "simple";

        /// <summary>
        /// The href.
        /// </summary>
        [XmlAttribute("href", Form = XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/xlink")]
        public string Href { get; set; }

        /// <summary>
        /// The type token.
        /// </summary>
        [XmlAttribute("type", DataType = "token")]
        public string TypeToken { get; set; }
    }
}