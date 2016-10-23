using System.Xml;
using System.Xml.Linq;

namespace Library.FictionBook
{
    public class ReadSettings
    {
        public XmlReaderSettings Settings { get; }
        public LoadOptions Options { get; }

        public ReadSettings(XmlReaderSettings settings, LoadOptions options = LoadOptions.PreserveWhitespace)
        {
            Settings = settings;
            Options = options;
        }
    }
}