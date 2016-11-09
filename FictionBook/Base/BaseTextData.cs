namespace FictionBook.Base
{
    using System.Xml.Serialization;

    /// <summary>
    /// The base data.
    /// </summary>
    public class BaseTextData : BaseFormatingStyle
    {
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        [XmlText]
        public virtual string Text { get; set; }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="string" /> that represents this instance.</returns>
        public override string ToString()
        {
            return Text;
        }
    }
}