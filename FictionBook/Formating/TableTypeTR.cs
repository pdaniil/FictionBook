using System.ComponentModel;
using System.Xml.Serialization;
using FictionBook.Library.Enum;

namespace FictionBook.Library.Formating
{
    /// <summary>
    /// The table type tr.
    /// </summary>
    [XmlType(AnonymousType = true, Namespace = "http://www.gribuser.ru/xml/fictionbook/2.0")]
    public class TableTypeTr
    {
        /// <summary>
        /// The td.
        /// </summary>
        [XmlElement("td")]
        public PType[] Td { get; set; }

        /// <summary>
        /// The align.
        /// </summary>
        [XmlAttribute("align")]
        [DefaultValue(AlignType.Left)]
        public AlignType Align { get; set; } = AlignType.Left;
    }
}