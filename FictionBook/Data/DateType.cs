using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using FictionBook.Library.Base;

namespace FictionBook.Library.Data
{
    /// <summary>
    /// The date type.
    /// </summary>
    [XmlType(Namespace = "http://www.gribuser.ru/xml/fictionbook/2.0")]
    public class DateType : BaseTextData
    {
        /// <summary>
        /// The value.
        /// </summary>
        [XmlAttribute(DataType = "date")]
        public DateTime Value { get; set; }

        /// <summary>
        /// The value specified.
        /// </summary>
        [XmlIgnore]
        public bool ValueSpecified { get; set; }

        /// <summary>
        /// The lang.
        /// </summary>
        [XmlAttribute("lang", Form = XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string Lang { get; set; }

        /// <summary>
        /// The value.
        /// </summary>
        [XmlText]
        public override string Text { get; set; }
    }
}