using System.Xml.Serialization;

namespace FictionBook.Library.Formating
{
    /// <summary>
    /// The p type.
    /// </summary>
    [XmlType(Namespace = "http://www.gribuser.ru/xml/fictionbook/2.0")]
    public class PType : StyleType
    {
        /// <summary>
        /// The id.
        /// </summary>
        [XmlAttribute("id", DataType = "ID")]
        public string Id { get; set; }

        /// <summary>
        /// The style.
        /// </summary>
        [XmlAttribute("style")]
        public string Style { get; set; }
    }
}