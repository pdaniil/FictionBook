namespace FictionBook.Formating
{
    using System.Xml.Schema;
    using System.Xml.Serialization;

    /// <summary>
    /// The poem type stanza.
    /// </summary>
    [XmlType(AnonymousType = true, Namespace = "http://www.gribuser.ru/xml/fictionbook/2.0")]
    public class PoemTypeStanza
    {
        /// <summary>
        /// The title.
        /// </summary>
        [XmlElement("title")]
        public TitleType Title { get; set; }

        /// <summary>
        /// The subtitle.
        /// </summary>
        [XmlElement("subtitle")]
        public PType Subtitle { get; set; }

        /// <summary>
        /// The v.
        /// </summary>
        [XmlElement("v")]
        public PType[] V { get; set; }

        /// <summary>
        /// The lang.
        /// </summary>
        [XmlAttribute("lang", Form = XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string Lang { get; set; }
    }
}