using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Library.FictionBook.Models.Interfaces;

namespace Library.FictionBook.Core.Extensions
{
    public static class XElementExtensions
    {
        public static string FictionAttribute(this XElement element, XName correctName, XName wrongName = null)
        {
            var value = string.Empty;
            var attribute = element.Attribute(correctName);

            if (attribute != null && string.IsNullOrEmpty(attribute.Value))
                value = attribute.Value;
            else
            {
                if (wrongName != null)
                {
                    attribute = element.Attribute(wrongName);

                    if (attribute != null && string.IsNullOrEmpty(attribute.Value))
                        value = attribute.Value;
                }
            }

            return value;
        }

        public static IEnumerable<T> To<T>(this IEnumerable<XElement> elements)
            where T : IModel, new()
        {
            return To<T>(elements, XNamespace.None);
        }
        public static IEnumerable<T> To<T>(this IEnumerable<XElement> elements, XNamespace bookNamespace)
            where T : IModel, new()
        {
            var list = new List<T>();

            foreach (var element in elements)
            {
                try
                {
                    var model = new T() { BookNamespace = bookNamespace };
                    model.Load(element);
                    list.Add(model);
                }
                catch (Exception)
                {
                    //
                }
            }

            return list;
        }
        
        public static T To<T>(this XElement element)
            where T : IModel, new()
        {
            return To<T>(element, XNamespace.None);
        }
        public static T To<T>(this XElement element, XNamespace bookNamespace)
            where T : IModel, new()
        {
            var model = new T { BookNamespace = bookNamespace };

            try
            {
                model.Load(element);
            }
            catch
            {
                //
            }

            return model;
        }
    }
}