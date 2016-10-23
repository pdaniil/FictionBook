using System.Xml.Linq;
using Library.FictionBook.Models.Core;

namespace Library.FictionBook.Models.Author
{
    public class TranslatorModel : AuthorModel
    {
        public override XNode Save(string name = "")
        {
            return base.Save(FictionBookConstants.Translator);
        }
    }
}