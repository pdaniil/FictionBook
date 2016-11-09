namespace FictionBook.Data
{
    using System.Xml.Serialization;

    /// <summary>
    /// The fiction book binary.
    /// </summary>
    [XmlType(AnonymousType = true, Namespace = "http://www.gribuser.ru/xml/fictionbook/2.0")]
    public class FictionBookBinary
    {
        /// <summary>
        /// The contenttype.
        /// </summary>
        [XmlAttribute("content-type")]
        public string ContentType { get; set; }

        /// <summary>
        /// The id.
        /// </summary>
        [XmlAttribute("id", DataType = "ID")]
        public string Id { get; set; }

        /// <summary>
        /// The value.
        /// </summary>
        [XmlText(DataType = "base64Binary")]
        public byte[] Value { get; set; }
    }
}