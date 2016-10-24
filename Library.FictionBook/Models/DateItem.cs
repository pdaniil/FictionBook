using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Library.FictionBook.Core;
using Library.FictionBook.Models.Core;
using Library.FictionBook.Models.Interfaces;

namespace Library.FictionBook.Models
{
    public class DateModel : IModel
    {
        #region PrivateMembers

        private List<Exception> _exceptions = new List<Exception>();

        #endregion

        public string Text { get; set; }
        public DateTime Date { get;set; }
        public string Language { get; set; }

        public IEnumerable<Exception> Exceptions => _exceptions;

        public XNamespace BookNamespace { get; set; }

        public void Load(XNode date)
        {
            var eDate = date as XElement;

            if (eDate == null)
                throw new ArgumentNullException(nameof(eDate));

            if (eDate.Name.LocalName != FictionBookConstants.Date)
                throw new ArgumentException("Element of wrong type passed", nameof(eDate));

            if (eDate.Value != null)
                Text = eDate.Value;

            var dateValue = eDate.FictionAttribute("value");
            try
            {
                Date = DateTime.Parse(dateValue);
            }
            catch (Exception e)
            {
                _exceptions.Add(e);     
            }

            Language = eDate.FictionAttribute(XNamespace.Xml + FictionBookConstants.Language);
        }
        public XNode Save(string name = "")
        {
            var date = new XElement(FictionBookSchemaConstants.DefaultNamespace + FictionBookConstants.Date);

            if (!string.IsNullOrEmpty(Text))
                date.Value = Text;

            if (!string.IsNullOrEmpty(Language))
                date.Add(Language.ToFictionAttribute(XNamespace.Xml + FictionBookConstants.Language));

            if (!Date.Equals(DateTime.MinValue))
                date.Add(Date.ToString("d").ToFictionAttribute("value"));

            return date;
        }
    }
}
