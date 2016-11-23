using System.Xml.Serialization;

namespace FictionBook.Library.Enum
{
    /// <summary>
    /// The items choice type.
    /// </summary>
    [XmlType(Namespace = "http://www.gribuser.ru/xml/fictionbook/2.0", IncludeInSchema = false)]
    public enum AuthorSupportedEnum
    {
        /// <summary>
        /// The email.
        /// </summary>
        [XmlEnum("email")]
        Email, 

        /// <summary>
        /// The firstname.
        /// </summary>
        [XmlEnum("first-name")]
        Firstname, 

        /// <summary>
        /// The homepage.
        /// </summary>
        [XmlEnum("home-page")]
        Homepage, 

        /// <summary>
        /// The lastname.
        /// </summary>
        [XmlEnum("last-name")]
        Lastname, 

        /// <summary>
        /// The middlename.
        /// </summary>
        [XmlEnum("middle-name")]
        Middlename,

        /// <summary>
        /// The nickname.
        /// </summary>
        [XmlEnum("nickname")]
        Nickname
    }
}