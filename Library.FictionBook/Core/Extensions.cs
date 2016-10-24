using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Library.FictionBook.Models.Interfaces;

namespace Library.FictionBook.Core
{
    public static class Extensions
    {
        #region String

        public static bool Is(this string value, string forCompare)
        {
            if (value == forCompare)
                return true;
            return false;
        }

        public static bool IsNot(this string value, string forCompare)
        {
            if (value != forCompare)
                return true;
            return false;
        }

        public static XAttribute ToFictionAttribute(this string value, XName name)
        {
            return new XAttribute(name, value);
        }

        public static XElement ToFictionElement(this string value, XName name, params XAttribute[] attributes)
        {
            var element = new XElement(name, value);

            foreach (var attribute in attributes)
            {
                element.Add(attribute);
            }

            return element;
        }

        #endregion

        #region Xml
        
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

        #endregion
    }
}