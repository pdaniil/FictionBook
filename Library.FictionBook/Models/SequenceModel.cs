using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Library.FictionBook.Core;
using Library.FictionBook.Models.Core;
using Library.FictionBook.Models.Interfaces;

namespace Library.FictionBook.Models
{
    public class SequenceModel : IModel
    {
        public string Name { get; set; }
        public int? Number { get; set; }
        public string Language { get; set; }

        public List<SequenceModel> SubSections { get; } = new List<SequenceModel>();

        public IEnumerable<Exception> Exceptions { get; }

        public XNamespace BookNamespace { get; set; }

        public void Load(XNode sequense)
        {
            SubSections.Clear();

            var eSequense = sequense as XElement;

            if (eSequense == null)
                throw new ArgumentNullException(nameof(eSequense));

            if (eSequense.Name.LocalName.IsNot(FictionBookConstants.Sequence))
                throw new ArgumentException("Element of wrong type passed", nameof(eSequense));

            SubSections.AddRange(eSequense.Elements(BookNamespace + FictionBookConstants.Sequence).To<SequenceModel>());


            Name = eSequense.FictionAttribute(FictionBookConstants.Name);

            var value = 0;
            var number = eSequense.FictionAttribute(FictionBookConstants.Number);
            if (int.TryParse(number, out value))
                Number = value;

            Language = eSequense.FictionAttribute(FictionBookConstants.Language);
        }
        public XNode Save(string name = "")
        {
            var sequence = new XElement(FictionBookSchemaConstants.DefaultNamespace + FictionBookConstants.Sequence);

            if (!string.IsNullOrEmpty(Name))
                sequence.Add(Name.ToFictionAttribute(FictionBookConstants.Name));

            if (Number != null)
                sequence.Add(new XAttribute("number", Number));

            if (!string.IsNullOrEmpty(Language))
                sequence.Add(Language.ToFictionAttribute(XNamespace.Xml + FictionBookConstants.Language));

            foreach (var subSection in SubSections)
                sequence.Add(subSection.Save());

            return sequence;
        }
    }
}