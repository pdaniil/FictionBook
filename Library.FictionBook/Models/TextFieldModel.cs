using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Library.FictionBook.Core;
using Library.FictionBook.Models.Core;
using Library.FictionBook.Models.Interfaces;

namespace Library.FictionBook.Models
{
    public class TextFieldModel : IModel
    {
        public string Text { get; set; } = string.Empty;
        public string Language { get; set; } = null;
        
        public TextFieldModel()
        {
            
        }
        public TextFieldModel(XElement text)
        {
            Load(text);            
        }

        #region IModel implementation

        public IEnumerable<Exception> Exceptions => null;
        public XNamespace BookNamespace { get; set; }

        public virtual void Load(XNode text)
        {
            var eElement = text as XElement;

            if (eElement == null)
                throw new ArgumentNullException(nameof(eElement));

            if (!string.IsNullOrEmpty(eElement.Value))
                Text = eElement.Value;

            Language = eElement.FictionAttribute(XNamespace.Xml + "lang");
        }
        public virtual XNode Save(string name)
        {
            var text = new XElement(FictionBookSchemaConstants.DefaultNamespace + name, Text);

            if (Language != null)
                text.Add(Language.ToFictionAttribute(XNamespace.Xml + "lang"));

            return text;
        }

        #endregion

        #region Overrides

        public override string ToString()
        {
            return Text;
        }

        #endregion
    }
}
