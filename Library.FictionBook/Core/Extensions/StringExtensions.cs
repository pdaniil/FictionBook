using System.Xml.Linq;

namespace Library.FictionBook.Core.Extensions
{
    public static class StringExtensions
    {
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
    }
}