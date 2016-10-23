using System.Xml.Linq;
using Library.FictionBook.Core.Extensions;
using Library.FictionBook.Models.Core;

namespace Library.FictionBook.Models
{
    public class CustomTextFieldModel : TextFieldModel
    {
        public string InfoType { get; set; }

        public override void Load(XNode text)
        {
            base.Load(text);

            var eText = text as XElement;

            InfoType = eText.Element(FictionBookConstants.InfoType).To<ValueModel>(BookNamespace).Value;
        }
    }
}