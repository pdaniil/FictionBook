using System.Xml.Serialization;
using FictionBook.Library.Data;

namespace FictionBook.Library.Description
{
    /// <summary>
    /// The fiction book description custominfo.
    /// </summary>
    [XmlType(AnonymousType = true, Namespace = "http://www.gribuser.ru/xml/fictionbook/2.0")]
    public class FictionBookDescriptionCustominfo : TextFieldType
    {
        /// <summary>
        /// The infotype.
        /// </summary>
        [XmlAttribute("info-type")]
        public string InfoType { get; set; }
    }
}