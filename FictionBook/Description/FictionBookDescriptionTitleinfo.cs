using System.Xml.Serialization;
using FictionBook.Library.Data;
using FictionBook.Library.Formating;

namespace FictionBook.Library.Description
{
    /// <summary>
    /// The fiction book description titleinfo.
    /// </summary>
    [XmlType(AnonymousType = true, Namespace = "http://www.gribuser.ru/xml/fictionbook/2.0")]
    public class FictionBookDescriptionTitleinfo
    {
        /// <summary>
        /// The genre.
        /// </summary>
        [XmlElement("genre")]
        public FictionBookDescriptionTitleinfoGenre[] Genre { get; set; }

        /// <summary>
        /// The author.
        /// </summary>
        [XmlElement("author")]
        public AuthorType[] Author { get; set; }

        /// <summary>
        /// The booktitle.
        /// </summary>
        [XmlElement("book-title")]
        public TextFieldType BookTitle { get; set; }

        /// <summary>
        /// The annotation.
        /// </summary>
        [XmlElement("annotation")]
        public AnnotationType Annotation { get; set; }

        /// <summary>
        /// The keywords.
        /// </summary>
        [XmlElement("keywords")]
        public TextFieldType Keywords { get; set; }

        /// <summary>
        /// The date.
        /// </summary>
        [XmlElement("date")]
        public DateType Date { get; set; }

        /// <summary>
        /// The coverpage.
        /// </summary>
        [XmlArray("coverpage")]
        [XmlArrayItem("image", IsNullable = false)]
        public ImageType[] Coverpage { get; set; }

        /// <summary>
        /// The lang.
        /// </summary>
        [XmlElement("lang", DataType = "language")]
        public string Lang { get; set; }

        /// <summary>
        /// The srclang.
        /// </summary>
        [XmlElement("src-lang", DataType = "language")]
        public string Srclang { get; set; }

        /// <summary>
        /// The translator.
        /// </summary>
        [XmlElement("translator")]
        public AuthorType[] Translator { get; set; }

        /// <summary>
        /// The sequence.
        /// </summary>
        [XmlElement("sequence")]
        public SequenceType[] Sequence { get; set; }
    }
}