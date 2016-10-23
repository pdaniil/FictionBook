using System.Xml.Linq;

namespace Library.FictionBook.Models.Core
{
    public class FictionBookSchemaConstants
    {
        public static readonly XNamespace DefaultNamespace = @"http://www.gribuser.ru/xml/fictionbook/2.0";
        public static readonly XNamespace LinkNamespace = @"http://www.w3.org/1999/xlink";

        public static readonly string Style = "stylesheet";

        public static readonly string ProgramUsed = "program-used";
        public static readonly string SourceUrl = "src-url";
        public static readonly string SourceOcr = "src-ocr";
        public static readonly string Id = "id";
        public static readonly string Version = "version";
        public static readonly string History = "history";
    }

    public class FictionBookConstants
    {
        #region FictionBook

        public static readonly string Body = "body";
        public static readonly string Binary = "binary";
        public static readonly string Description = "description";
        
        public static readonly string TitleInfo = "title-info";
        public static readonly string SrcTitleInfo = "src-title-info";
        public static readonly string DocumentInfo = "document-info";

        #endregion

        #region FictionBook-TitleInfoModel

        public static readonly string Genre = "genre";
        public static readonly string BookTitle = "book-title";
        public static readonly string Annotation = "annotation";
        public static readonly string Keywords = "keywords";
        public static readonly string CoverPage = "coverpage";
        public static readonly string Language = "lang";
        public static readonly string SourceLanguage = "src-lang";

        #endregion

        #region FictionBook-AuthorModel

        public static readonly string Author = "author";
        public static readonly string Translator = "translator";
        public static readonly string Publisher = "publisher";

        public static readonly string FirstName = "first-name";
        public static readonly string MiddleName = "middle-name";
        public static readonly string LastName = "last-name";
        public static readonly string NickName = "nickname";
        public static readonly string HomePage = "home-page";
        public static readonly string Email = "email";
        public static readonly string Id = "id";

        #endregion

        #region FictionBook-Date

        public static readonly string Date = "date";

        #endregion

        #region Factory

        public static readonly string Paragraph = "p";
        public static readonly string Poem = "poem";
        public static readonly string Cite = "cite";
        public static readonly string Subtitle = "subtitle";
        public static readonly string Table = "table";
        public static readonly string EmptyLine = "empty-line";

        #endregion

        public static readonly string InlineImage = "image";
        public static readonly string Href = "href";
        public static readonly string Alt = "alt";
        public static readonly string Type = "type";
        public static readonly string InternalLink = "a";
        public static readonly string Style = "style";
        public static readonly string Sequence = "sequence";
        public static readonly string Name = "name";
        public static readonly string Number = "number";

        public static readonly string BookName = "book-name";
        public static readonly string City = "city";
        public static readonly string Year = "year";
        public static readonly string Isbn = "isbn";

        public static readonly string PublishInfo = "publish-info";
        public static readonly string InfoType = "info-type";
        public static readonly string CustomInfo = "custom-info";
    }
}