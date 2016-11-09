namespace FictionBook
{
    using System.Xml.Serialization;

    using Description;

    /// <summary>
    /// The fiction book description.
    /// </summary>
    [XmlType(AnonymousType = true, Namespace = "http://www.gribuser.ru/xml/fictionbook/2.0")]
    public class FictionBookDescription
    {
        /// <summary>
        /// The titleinfo.
        /// </summary>
        [XmlElement("title-info")]
        public FictionBookDescriptionTitleinfo TitleInfo { get; set; }

        /// <summary>
        /// The documentinfo.
        /// </summary>
        [XmlElement("document-info")]
        public FictionBookDescriptionDocumentinfo DocumentInfo { get; set; }

        /// <summary>
        /// The publishinfo.
        /// </summary>
        [XmlElement("publish-info")]
        public FictionBookDescriptionPublishinfo PublishInfo { get; set; }

        /// <summary>
        /// The custominfo.
        /// </summary>
        [XmlElement("custom-info")]
        public FictionBookDescriptionCustominfo[] CustomInfo { get; set; }
    }
}