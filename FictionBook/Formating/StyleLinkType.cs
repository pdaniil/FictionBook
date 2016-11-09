namespace FictionBook.Formating
{
    using System.Xml.Serialization;

    using Base;
    using Enum;

    /// <summary>
    /// The style link type.
    /// </summary>
    [XmlType(Namespace = "http://www.gribuser.ru/xml/fictionbook/2.0")]
    public class StyleLinkType : BaseFormatingStyle
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
    }
}