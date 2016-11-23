using System.Xml.Serialization;
using FictionBook.Library.Base;

namespace FictionBook.Library.Formating
{
    /// <summary>
    /// The table type.
    /// </summary>
    [XmlType(Namespace = "http://www.gribuser.ru/xml/fictionbook/2.0")]
    public class TableType : BaseFormatingStyle
    {
        /// <summary>
        /// The tr.
        /// </summary>
        [XmlElement("tr")]
        public TableTypeTr[] Tr { get; set; }
    }
}