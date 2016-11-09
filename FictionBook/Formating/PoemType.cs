namespace FictionBook.Formating
{
    using System.Xml.Schema;
    using System.Xml.Serialization;

    using Base;
    using Data;

    /// <summary>
    /// The poem type.
    /// </summary>
    [XmlType(Namespace = "http://www.gribuser.ru/xml/fictionbook/2.0")]
    public class PoemType : BaseFormatingStyle
    {
        /// <summary>
        /// The title.
        /// </summary>
        [XmlElement("title")]
        public TitleType Title { get; set; }

        /// <summary>
        ///  The epigraph.
        /// </summary>
        [XmlElement("epigraph")]
        public EpigraphType[] Epigraph { get; set; }

        /// <summary>
        /// The stanza.
        /// </summary>
        [XmlElement("stanza")]
        public PoemTypeStanza[] Stanza { get; set; }

        /// <summary>
        /// The textauthor.
        /// </summary>
        [XmlElement("text-author")]
        public TextFieldType[] TextAuthor { get; set; }

        /// <summary>
        /// The date.
        /// </summary>
        [XmlElement("date")]
        public DateType Date { get; set; }

        /// <summary>
        /// The id.
        /// </summary>
        [XmlAttribute("id", DataType = "ID")]
        public string Id { get; set; }

        /// <summary>
        /// The lang.
        /// </summary>
        [XmlAttribute("lang", Form = XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string Lang { get; set; }
    }
}