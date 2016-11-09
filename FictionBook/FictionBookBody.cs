namespace FictionBook
{
    using System.Xml.Schema;
    using System.Xml.Serialization;

    using Data;
    using Formating;

    /// <summary>
    /// The fiction book body.
    /// </summary>
    [XmlType(AnonymousType = true, Namespace = "http://www.gribuser.ru/xml/fictionbook/2.0")]
    public class FictionBookBody
    {
        /// <summary>
        /// The image.
        /// </summary>
        [XmlElement("image")]
        public ImageType Image { get; set; }

        /// <summary>
        /// The title.
        /// </summary>
        [XmlElement("title")]
        public TitleType Title { get; set; }

        /// <summary>
        /// The epigraph.
        /// </summary>
        [XmlElement("epigraph")]
        public EpigraphType[] Epigraph { get; set; }

        /// <summary>
        /// The section.
        /// </summary>
        [XmlElement("section")]
        public SectionType[] Section { get; set; }

        /// <summary>
        /// The name.
        /// </summary>
        [XmlAttribute("name")]
        public string Name { get; set; }

        /// <summary>
        /// The lang.
        /// </summary>
        [XmlAttribute("lang", Form = XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string Lang { get; set; }
    }
}