using System.Xml.Serialization;

namespace FictionBook.Enum
{
    /// <summary>
    /// The align type.
    /// </summary>
    [XmlType(Namespace = "http://www.gribuser.ru/xml/fictionbook/2.0")]
    public enum AlignType
    {
        /// <summary>
        /// The left.
        /// </summary>
        [XmlEnum("left")]
        Left,

        /// <summary>
        /// The right.
        /// </summary>
        [XmlEnum("right")]
        Right,

        /// <summary>
        /// The center.
        /// </summary>
        [XmlEnum("center")]
        Center
    }
}