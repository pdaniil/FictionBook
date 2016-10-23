using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Library.FictionBook.Core.Extensions;
using Library.FictionBook.Models.Core;
using Library.FictionBook.Models.Interfaces;

namespace Library.FictionBook.Models.Style
{
    public class InlineImageModel : IStyle
    {
        public string Type { get; set; }
        public string Href { get; set; }
        public string Alt { get; set; }

        public IEnumerable<Exception> Exceptions => null;

        public XNamespace BookNamespace { get; set; }

        public void Load(XNode image)
        {
            var eImage = image as XElement;

            if (eImage == null)
                throw new ArgumentNullException(nameof(eImage));

            if (eImage.Name.LocalName.IsNot(FictionBookConstants.InlineImage))
                throw new ArgumentException("Element of wrong type passed", nameof(eImage));


            Type = eImage.FictionAttribute(
                FictionBookSchemaConstants.LinkNamespace + FictionBookConstants.Type,
                FictionBookConstants.Type
            );

            Href = eImage.FictionAttribute(
                FictionBookSchemaConstants.LinkNamespace + FictionBookConstants.Href,
                FictionBookConstants.Href
            );

            Alt = eImage.FictionAttribute(
                FictionBookSchemaConstants.LinkNamespace + FictionBookConstants.Alt,
                FictionBookConstants.Alt
            );
        }
        public XNode Save(string name = "")
        {
            var image = new XElement(FictionBookSchemaConstants.DefaultNamespace + FictionBookConstants.InlineImage);

            if (!string.IsNullOrEmpty(Type))
                image.Add(Type.ToFictionAttribute(FictionBookSchemaConstants.LinkNamespace + FictionBookConstants.Type));

            if (!string.IsNullOrEmpty(Href))
                image.Add(Href.ToFictionAttribute(FictionBookSchemaConstants.LinkNamespace + FictionBookConstants.Href));

            if (!string.IsNullOrEmpty(Alt))
                image.Add(Alt.ToFictionAttribute(FictionBookSchemaConstants.LinkNamespace + FictionBookConstants.Alt));
            
            return image;
        }
    }
}