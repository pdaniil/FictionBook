using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Library.FictionBook.Models.Core;
using Library.FictionBook.Models.Interfaces;

namespace Library.FictionBook.Models
{
    public class ValueModel : IModel
    {
        public string Value { get; set; }

        public IEnumerable<Exception> Exceptions { get; }
        public XNamespace BookNamespace { get; set; }

        public void Load(XNode value)
        {
            var eValue = value as XElement;

            if (eValue?.Value != null)
            {
                Value = eValue.Value;
            }
    }

        public XNode Save(string name = "")
        {
            return new XElement(FictionBookSchemaConstants.DefaultNamespace + FictionBookSchemaConstants.SourceUrl, Value);
        }
    }
}