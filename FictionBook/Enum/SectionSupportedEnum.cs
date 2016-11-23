using System.Xml.Serialization;

namespace FictionBook.Library.Enum
{
    /// <summary>
    /// The items choice type 5.
    /// </summary>
    [XmlType(Namespace = "http://www.gribuser.ru/xml/fictionbook/2.0", IncludeInSchema = false)]
    public enum SectionSupportedEnum
    {
        /// <summary>
        /// The cite.
        /// </summary>
        [XmlEnum("cite")]
        Cite, 

        /// <summary>
        /// The emptyline.
        /// </summary>
        [XmlEnum("empty-line")]
        Emptyline,

        /// <summary>
        /// The image.
        /// </summary>
        [XmlEnum("image")]
        Image,

        /// <summary>
        /// The p.
        /// </summary>
        [XmlEnum("p")]
        P,

        /// <summary>
        /// The poem.
        /// </summary>
        [XmlEnum("poem")]
        Poem,

        /// <summary>
        /// The section.
        /// </summary>
        [XmlEnum("section")]
        Section,

        /// <summary>
        /// The subtitle.
        /// </summary>
        [XmlEnum("subtitle")]
        Subtitle,

        /// <summary>
        /// The table.
        /// </summary>
        [XmlEnum("table")]
        Table
    }
}