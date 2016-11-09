namespace FictionBook.Description
{
    using System.Xml.Serialization;

    using Data;

    /// <summary>
    /// The fiction book description publishinfo.
    /// </summary>
    [XmlType(AnonymousType = true, Namespace = "http://www.gribuser.ru/xml/fictionbook/2.0")]
    public class FictionBookDescriptionPublishinfo
    {
        /// <summary>
        /// The bookname.
        /// </summary>
        [XmlElement("book-name")]
        public TextFieldType BookName { get; set; }

        /// <summary>
        /// The publisher.
        /// </summary>
        [XmlElement("publisher")]
        public TextFieldType Publisher { get; set; }

        /// <summary>
        /// The city.
        /// </summary>
        [XmlElement("city")]
        public TextFieldType City { get; set; }

        /// <summary>
        /// The year.
        /// </summary>
        [XmlElement(DataType = "gYear")]
        public string Year { get; set; }

        /// <summary>
        /// The isbn.
        /// </summary>
        [XmlElement("isbn")]
        public TextFieldType Isbn { get; set; }

        /// <summary>
        /// The sequence.
        /// </summary>
        [XmlElement("sequence")]
        public SequenceType[] Sequence { get; set; }
    }
}