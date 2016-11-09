namespace FictionBook.Formating
{
    using System.Xml.Schema;
    using System.Xml.Serialization;

    using Base;

    /// <summary>
    /// The title type.
    /// </summary>
    [XmlType(Namespace = "http://www.gribuser.ru/xml/fictionbook/2.0")]
    public class TitleType : BaseFormatingStyle
    {
        /// <summary>
        /// The items.
        /// </summary>
        [XmlElement("empty-line", typeof(BaseFormatingStyle))]
        [XmlElement("p", typeof(PType))]
        public BaseFormatingStyle[] Items { get; set; }

        /// <summary>
        /// The lang.
        /// </summary>
        [XmlAttribute("lang", Form = XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string Lang { get; set; }
    }
}