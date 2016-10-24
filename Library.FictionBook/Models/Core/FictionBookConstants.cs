using System.Xml.Linq;

namespace Library.FictionBook.Models.Core
{
    public class FictionBookSchemaConstants
    {
        public static readonly XNamespace DefaultNamespace = @"http://www.gribuser.ru/xml/fictionbook/2.0";
        public static readonly XNamespace LinkNamespace = @"http://www.w3.org/1999/xlink";

        public const string Style = "stylesheet";

        public const string ProgramUsed = "program-used";
        public const string SourceUrl = "src-url";
        public const string SourceOcr = "src-ocr";
        public const string Id = "id";
        public const string Version = "version";
        public const string History = "history";
    }

    public class FictionBookConstants
    {
        #region FictionBook

        public const string Body = "body";
        public const string Binary = "binary";
        public const string Description = "description";
        
        public const string TitleInfo = "title-info";
        public const string SrcTitleInfo = "src-title-info";
        public const string DocumentInfo = "document-info";

        #endregion

        #region FictionBook-TitleInfoModel

        public const string Genre = "genre";
        public const string BookTitle = "book-title";
        public const string Annotation = "annotation";
        public const string Keywords = "keywords";
        public const string CoverPage = "coverpage";
        public const string Language = "lang";
        public const string SourceLanguage = "src-lang";

        #endregion

        #region FictionBook-AuthorModel

        public const string Author = "author";
        public const string Translator = "translator";
        public const string Publisher = "publisher";

        public const string FirstName = "first-name";
        public const string MiddleName = "middle-name";
        public const string LastName = "last-name";
        public const string NickName = "nickname";
        public const string HomePage = "home-page";
        public const string Email = "email";
        public const string Id = "id";

        #endregion

        #region FictionBook-Date

        public const string Date = "date";

        #endregion

        #region Factory

        public const string Paragraph = "p";
        public const string Poem = "poem";
        public const string Cite = "cite";
        public const string Subtitle = "subtitle";
        public const string Table = "table";
        public const string EmptyLine = "empty-line";

        #endregion

        public const string InlineImage = "image";
        public const string Href = "href";
        public const string Alt = "alt";
        public const string Type = "type";
        public const string InternalLink = "a";
        public const string Style = "style";
        public const string Sequence = "sequence";
        public const string Name = "name";
        public const string Number = "number";

        public const string BookName = "book-name";
        public const string City = "city";
        public const string Year = "year";
        public const string Isbn = "isbn";

        public const string PublishInfo = "publish-info";
        public const string InfoType = "info-type";
        public const string CustomInfo = "custom-info";
    }
}