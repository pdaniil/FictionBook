using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Library.FictionBook.Models.Interfaces
{
    public interface IModel
    {
        IEnumerable<Exception> Exceptions { get; }
        XNamespace BookNamespace { get; set; }

        void Load(XNode element);
        XNode Save(string name = "");
    }
}