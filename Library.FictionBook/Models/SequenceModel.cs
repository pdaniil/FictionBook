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
        #region Private Members

        private List<SequenceModel> _subSequences;

        #endregion

        public string Name { get; set; }
        public int? Number { get; set; }
        public string Language { get; set; }

        public IEnumerable<SequenceModel> SubSequences => _subSequences;

        #region Implementation of IModel

        public XNamespace BookNamespace { get; set; }

        public void Load(XNode sequense)
        {
            Clear();

            var eSequense = sequense as XElement;

            if (eSequense == null)
                throw new ArgumentNullException(nameof(eSequense));

            if (eSequense.Name.LocalName.IsNot(FictionBookConstants.Sequence))
                throw new ArgumentException("Element of wrong type passed", nameof(eSequense));

            #region Name

            Name = eSequense.FictionAttribute(FictionBookConstants.Name);

            #endregion

            #region Number

            var value = 0;
            var number = eSequense.FictionAttribute(FictionBookConstants.Number);
            if (int.TryParse(number, out value))
                Number = value;

            #endregion

            #region Language

            Language = eSequense.FictionAttribute(FictionBookConstants.Language);

            #endregion

            #region SubSequences

            _subSequences.AddRange(eSequense.Elements(BookNamespace + FictionBookConstants.Sequence).To<SequenceModel>());

            #endregion
        }
        public XNode Save(string name = "")
        {
            var sequence = new XElement(FictionBookSchemaConstants.DefaultNamespace + FictionBookConstants.Sequence);

            #region Name

            if (!string.IsNullOrEmpty(Name))
                sequence.Add(Name.ToFictionAttribute(FictionBookConstants.Name));

            #endregion

            #region Number

            if (Number != null)
                sequence.Add(new XAttribute("number", Number));

            #endregion

            #region Language

            if (!string.IsNullOrEmpty(Language))
                sequence.Add(Language.ToFictionAttribute(XNamespace.Xml + FictionBookConstants.Language));

            #endregion

            #region SubSequences

            foreach (var subSection in SubSequences)
                sequence.Add(subSection.Save());

            #endregion

            return sequence;
        }

        public void Clear()
        {
            _subSequences.Clear();
            Name = null;
            Number = null;
            Language = null;
        }

        #endregion
    }
}