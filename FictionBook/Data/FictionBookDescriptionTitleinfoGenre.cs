namespace FictionBook.Data
{
    using System.ComponentModel;
    using System.Xml.Serialization;

    using Base;

    /// <summary>
    /// The fiction book description titleinfo genre.
    /// </summary>
    [XmlType(AnonymousType = true, Namespace = "http://www.gribuser.ru/xml/fictionbook/2.0")]
    public class FictionBookDescriptionTitleinfoGenre : BaseTextData
    {
        /// <summary>
        /// The match.
        /// </summary>
        [XmlAttribute("match", DataType = "integer")]
        [DefaultValue("100")]
        public string Match { get; set; } = "100";

        /// <summary>
        /// The value.
        /// </summary>
        [XmlText]
        public override string Text { get; set; }
    }
}