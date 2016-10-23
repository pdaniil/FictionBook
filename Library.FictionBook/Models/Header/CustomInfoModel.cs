using System;
using System.Xml.Linq;
using Library.FictionBook.Models.Core;

namespace Library.FictionBook.Models.Header
{
    public class CustomInfoModel : CustomTextFieldModel
    {
        public override void Load(XNode customInfo)
        {
            if (customInfo == null)
                throw new ArgumentNullException(nameof(customInfo));

            base.Load(customInfo);
        }

        public override XNode Save(string name = "")
        {
            XElement xCustomInfo = new XElement(FictionBookSchemaConstants.DefaultNamespace + FictionBookConstants.CustomInfo);
            xCustomInfo.Add(new XAttribute("info-type", InfoType));
            xCustomInfo.Value = Text;
            return xCustomInfo;
        }
    }
}