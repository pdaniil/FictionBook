using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Library.FictionBook.Core.Extensions;
using Library.FictionBook.Models.Core;
using Library.FictionBook.Models.Interfaces;

namespace Library.FictionBook.Models
{
    public class StyleModel : IStyle
    {
        public string Type { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;

        public IEnumerable<Exception> Exceptions => null;

        public XNamespace BookNamespace { get; set; }

        public void Load(XNode style)
        {
            var eStyle = style as XElement;

            if (eStyle == null)
                throw new ArgumentNullException(nameof(eStyle));

            if (eStyle.Name.LocalName.IsNot(FictionBookSchemaConstants.Style))
                throw new ArgumentException($"The element is of type {eStyle.Name.LocalName} while StyleElement accepts only {FictionBookSchemaConstants.Style} types");

            if (!string.IsNullOrEmpty(eStyle.Value))
                Value = eStyle.Value;

            var type = eStyle.Attribute("type");
            if (string.IsNullOrEmpty(type?.Value))
                throw new Exception("Type attribute is rewuired by standard");

            Type = type.Value;
        }
        public XNode Save(string name)
        {
            if (string.IsNullOrEmpty(Type))
                throw new Exception("Type attribute is rewuired by standard");

            var style = new XElement(FictionBookSchemaConstants.DefaultNamespace + FictionBookSchemaConstants.Style, new XAttribute(FictionBookConstants.Type, Type));

            if (!string.IsNullOrEmpty(Value))
                style.Value = Value;

            return style;
        }
    }
}