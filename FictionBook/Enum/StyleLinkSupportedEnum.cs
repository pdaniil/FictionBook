using System.Xml.Serialization;

namespace FictionBook.Library.Enum
{
    /// <summary>
    /// The items choice type 1.
    /// </summary>
    [XmlType(Namespace = "http://www.gribuser.ru/xml/fictionbook/2.0", IncludeInSchema = false)]
    public enum StyleLinkSupportedEnum
    {
        /// <summary>
        /// The emphasis.
        /// </summary>
        [XmlEnum("emphasis")]
        Emphasis,

        /// <summary>
        /// The strong.
        /// </summary>
        [XmlEnum("strong")]
        Strong,

        /// <summary>
        /// The style.
        /// </summary>
        [XmlEnum("style")]
        Style
    }
}