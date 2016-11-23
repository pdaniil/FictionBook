using System.Diagnostics;
using System.Xml.Serialization;
using FictionBook.Library.Base;
using FictionBook.Library.Data;
using FictionBook.Library.Enum;

namespace FictionBook.Library.Formating
{
    /// <summary>
    /// The author type.
    /// </summary>
    [DebuggerStepThrough]
    [XmlType(Namespace = "http://www.gribuser.ru/xml/fictionbook/2.0")]
    public class AuthorType
    {
        /// <summary>
        /// The items.
        /// </summary>
        [XmlElement("email", typeof(BaseTextData))]
        [XmlElement("first-name", typeof(TextFieldType))]
        [XmlElement("home-page", typeof(BaseTextData))]
        [XmlElement("last-name", typeof(TextFieldType))]
        [XmlElement("middle-name", typeof(TextFieldType))]
        [XmlElement("nickname", typeof(TextFieldType))]
        [XmlChoiceIdentifier("ItemsElementName")]
        public BaseTextData[] Items { get; set; }

        /// <summary>
        /// The items element name.
        /// </summary>
        [XmlElement("ItemsElementName")]
        [XmlIgnore]
        public AuthorSupportedEnum[] ItemsElementName { get; set; }
    }
}