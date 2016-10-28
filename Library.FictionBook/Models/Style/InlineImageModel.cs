using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Library.FictionBook.Core;
using Library.FictionBook.Models.Core;
using Library.FictionBook.Models.Interfaces;

namespace Library.FictionBook.Models.Style
{
    public class InlineImageModel : IStyle
    {
        public string Type { get; set; }
        public string Href { get; set; }
        public string Alt { get; set; }

        #region Implementaion of IModel

        public XNamespace BookNamespace { get; set; }

        public void Load(XNode image)
        {
            Clear();

            var eImage = image as XElement;

            if (eImage == null)
                throw new ArgumentNullException(nameof(eImage));

            if (eImage.Name.LocalName.IsNot(FictionBookConstants.InlineImage))
                throw new ArgumentException("Element of wrong type passed", nameof(eImage));

            #region Type

            Type = eImage.FictionAttribute(
                FictionBookSchemaConstants.LinkNamespace + FictionBookConstants.Type,
                FictionBookConstants.Type
            );

            #endregion

            #region Href

            Href = eImage.FictionAttribute(
                FictionBookSchemaConstants.LinkNamespace + FictionBookConstants.Href,
                FictionBookConstants.Href
            );

            #endregion

            #region Alt

            Alt = eImage.FictionAttribute(
                FictionBookSchemaConstants.LinkNamespace + FictionBookConstants.Alt,
                FictionBookConstants.Alt
            );

            #endregion

        }
        public XNode Save(string name = "")
        {
            var image = new XElement(FictionBookSchemaConstants.DefaultNamespace + FictionBookConstants.InlineImage);

            #region Type


            if (!string.IsNullOrEmpty(Type))
                image.Add(Type.ToFictionAttribute(FictionBookSchemaConstants.LinkNamespace + FictionBookConstants.Type));

            #endregion

            #region Href

            if (!string.IsNullOrEmpty(Href))
                image.Add(Href.ToFictionAttribute(FictionBookSchemaConstants.LinkNamespace + FictionBookConstants.Href));

            #endregion

            #region Alt

            if (!string.IsNullOrEmpty(Alt))
                image.Add(Alt.ToFictionAttribute(FictionBookSchemaConstants.LinkNamespace + FictionBookConstants.Alt));

            #endregion

            return image;
        }

        public void Clear()
        {
            Type = null;
            Href = null;
            Alt = null;
        }

        #endregion
    }
}