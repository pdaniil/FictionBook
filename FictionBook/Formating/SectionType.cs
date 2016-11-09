namespace FictionBook.Formating
{
    using System.Xml.Schema;
    using System.Xml.Serialization;

    using Base;
    using Data;
    using Enum;

    /// <summary>
    /// The section type.
    /// </summary>
    [XmlType(Namespace = "http://www.gribuser.ru/xml/fictionbook/2.0")]
    public class SectionType : BaseFormatingStyle
    {
        /// <summary>
        /// The title.
        /// </summary>
        [XmlElement("title", Order = 0)]
        public TitleType Title { get; set; }

        /// <summary>
        /// The epigraph.
        /// </summary>
        [XmlElement("epigraph", Order = 1)]
        public EpigraphType[] Epigraph { get; set; }

        /// <summary>
        /// The image.
        /// </summary>
        [XmlElement("image", Order = 2)]
        public ImageType Image { get; set; }

        /// <summary>
        /// The annotation.
        /// </summary>
        [XmlElement("annotation", Order = 3)]
        public AnnotationType Annotation { get; set; }

        /// <summary>
        /// The items.
        /// </summary>
        [XmlElement("cite", typeof(CiteType), Order = 4)]
        [XmlElement("empty-line", typeof(BaseFormatingStyle), Order = 4)]
        [XmlElement("image", typeof(ImageType), Order = 4)]
        [XmlElement("p", typeof(PType), Order = 4)]
        [XmlElement("poem", typeof(PoemType), Order = 4)]
        [XmlElement("section", typeof(SectionType), Order = 4)]
        [XmlElement("subtitle", typeof(PType), Order = 4)]
        [XmlElement("table", typeof(TableType), Order = 4)]
        [XmlChoiceIdentifier("ItemsElementName")]
        public BaseFormatingStyle[] Items { get; set; }

        /// <summary>
        /// The items element name.
        /// </summary>
        [XmlElement("ItemsElementName", Order = 5)]
        [XmlIgnore]
        public SectionSupportedEnum[] ItemsElementName { get; set; }

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