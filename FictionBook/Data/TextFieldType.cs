namespace FictionBook.Data
{
    using System.Xml.Schema;
    using System.Xml.Serialization;

    using Base;

    /// <summary>
    /// The text field type.
    /// </summary>
    [XmlType(Namespace = "http://www.gribuser.ru/xml/fictionbook/2.0")]
    public class TextFieldType : BaseTextData
    {
        /// <summary>
        /// The lang.
        /// </summary>
        [XmlAttribute("lang", Form = XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string Lang { get; set; }

        /// <summary>
        /// The value.
        /// </summary>
        [XmlText]
        public override string Text { get; set; }
    }
}