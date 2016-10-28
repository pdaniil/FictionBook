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

        #region Implementation of IModel

        public XNamespace BookNamespace { get; set; }

        public void Load(XNode date)
        {
            Clear();

            var eDate = date as XElement;

            if (eDate == null)
                throw new ArgumentNullException(nameof(eDate));

            if (eDate.Name.LocalName != FictionBookConstants.Date)
                throw new ArgumentException("Element of wrong type passed", nameof(eDate));

            #region Text

            if (eDate.Value != null)
                Text = eDate.Value;

            #endregion

            #region Date

            var dateValue = eDate.FictionAttribute("value");
            try
            {
                Date = DateTime.Parse(dateValue);
            }
            catch (Exception e)
            {
                _exceptions.Add(e);
            }

            #endregion

            #region Language

            Language = eDate.FictionAttribute(XNamespace.Xml + FictionBookConstants.Language);

            #endregion
        }
        public XNode Save(string name = "")
        {
            var date = new XElement(FictionBookSchemaConstants.DefaultNamespace + FictionBookConstants.Date);

            #region Text

            if (!string.IsNullOrEmpty(Text))
                date.Value = Text;

            #endregion

            #region Date

            if (!Date.Equals(DateTime.MinValue))
                date.Add(Date.ToString("d").ToFictionAttribute("value"));

            #endregion

            #region Language

            if (!string.IsNullOrEmpty(Language))
                date.Add(Language.ToFictionAttribute(XNamespace.Xml + FictionBookConstants.Language));

            #endregion

            return date;
        }

        public void Clear()
        {
            Text = null;
            Date = DateTime.MinValue;
            Language = null;
        }

        #endregion
    }
}
