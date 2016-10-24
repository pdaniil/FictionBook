using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Library.FictionBook.Core;
using Library.FictionBook.Models;
using Library.FictionBook.Models.Core;
using Library.FictionBook.Models.Header;

namespace Library.FictionBook
{
    public class FictionBook
    {
        private XNamespace _bookNamespace;

        private TitleInfoModel _titleInfo = new TitleInfoModel();
        private TitleInfoModel _srcTitleInfo = new TitleInfoModel();
        private DocumentInfoModel _documentInfo = new DocumentInfoModel();
        private PublishInfoModel _publishInfo = new PublishInfoModel();
        private CustomInfoModel _customInfo = new CustomInfoModel();
        
        //private BodyItem _mainBody;
        

        private List<StyleModel> _styles = new List<StyleModel>();
        //private readonly List<BodyItem> _bodiesList = new List<BodyItem>();
        private List<Exception> _exceptions = new List<Exception>();
        
        public void Load(XDocument book)
        {
            _styles.Clear();
            _exceptions.Clear();

            if (book == null)
                throw new ArgumentNullException(nameof(book));
            
            if (book.Root == null)
                throw new ArgumentException($"'{nameof(book)}' argrument root is null");

            _bookNamespace = book.Root.GetDefaultNamespace();

            LoadStyles(book);
            LoadDescription(book);

            //if (!loadHeaderOnly)
            //{
            //    XNamespace bookNamespace = _namespace;
            //    // Load body elements (first is main text)
            //    if (document.Root != null)
            //    {
            //        IEnumerable<XElement> xBodys = document.Root.Elements(_namespace + Fb2TextBodyElementName).ToArray();
            //        // try to read some badly formatted FB2 files
            //        if (!xBodys.Any())
            //        {
            //            bookNamespace = "";
            //            xBodys = document.Root.Elements(bookNamespace + Fb2TextBodyElementName);
            //        }
            //        foreach (var body in xBodys)
            //        {
            //            var bodyItem = new BodyItem() { NameSpace = bookNamespace };
            //            try
            //            {
            //                bodyItem.Load(body);
            //            }
            //            catch (Exception)
            //            {
            //                continue;
            //            }
            //            _bodiesList.Add(bodyItem);
            //        }
            //    }
            //    if (_bodiesList.Count > 0)
            //    {
            //        _mainBody = _bodiesList[0];
            //    }


            //    // Load binaries sections (currently images only)
            //    if (document.Root != null)
            //    {
            //        IEnumerable<XElement> xBinaryes = document.Root.Elements(bookNamespace + Fb2BinaryElementName).ToArray();
            //        if (!xBinaryes.Any())
            //        {
            //            xBinaryes = document.Root.Elements(Fb2BinaryElementName);
            //        }
            //        foreach (var binarye in xBinaryes)
            //        {
            //            var item = new BinaryItem();
            //            try
            //            {
            //                item.Load(binarye);
            //            }
            //            catch
            //            {
            //                continue;
            //            }
            //            // add just unique IDs to fix some invalid FB2s 
            //            if (!_binaryObjects.ContainsKey(item.Id))
            //            {
            //                _binaryObjects.Add(item.Id, item);
            //            }
            //        }
            //    }
            //}
        }

        private void LoadStyles(XDocument book)
        {
            var styles = book.Elements(_bookNamespace + FictionBookSchemaConstants.Style).ToArray();
          
            if (!styles.Any())
                styles = book.Elements(FictionBookSchemaConstants.Style).ToArray();

            foreach (var style in styles)
            {
                try
                {
                    var model = new StyleModel();
                    model.Load(style);
                    
                    _styles.Add(model);
                }
                catch (Exception e)
                {
                    _exceptions.Add(e);
                }
            }
        }

        private void LoadDescription(XDocument document, bool loadBinaryItems = true)
        {
            var bookNamespace = _bookNamespace;

            var description = document.Root.Element(_bookNamespace + FictionBookConstants.Description);
            if (description == null)
            {
                _bookNamespace = string.Empty;
                description = document.Root.Element(FictionBookConstants.Description);
            }

            if (description != null)
            {
                #region TitleInfo

                _titleInfo = description
                    .Element(bookNamespace + FictionBookConstants.TitleInfo)
                    .To<TitleInfoModel>(bookNamespace);

                #endregion

                #region SourceTitleInfo

                _srcTitleInfo = description
                    .Element(bookNamespace + FictionBookConstants.SrcTitleInfo)
                    .To<TitleInfoModel>(bookNamespace);

                #endregion

                #region DocumentInfo

                _documentInfo = description
                    .Element(bookNamespace + FictionBookConstants.DocumentInfo)
                    .To<DocumentInfoModel>(bookNamespace);

                #endregion

                #region PublishInfo

                _publishInfo = description
                    .Element(bookNamespace + FictionBookConstants.PublishInfo)
                    .To<PublishInfoModel>(bookNamespace);

                #endregion

                #region CustomInfo

                _customInfo = description
                    .Element(bookNamespace + FictionBookConstants.CustomInfo)
                    .To<CustomInfoModel>(bookNamespace);

                #endregion


                //IEnumerable<XElement> xInstructions = description.Elements(description.Name.Namespace + "output");
                //int outputCount = 0;
                //_output.Clear();
                //foreach (var xInstruction in xInstructions)
                //{
                //    // only two elements allowed by scheme
                //    if (outputCount > 1)
                //    {
                //        break;
                //    }
                //    var outp = new ShareInstructionType { Namespace = bookNamespace };
                //    try
                //    {
                //        outp.Load(xInstruction);
                //        _output.Add(outp);
                //    }
                //    catch (Exception ex)
                //    {
                //        Debug.WriteLine("Error reading output instructions : {0}", ex);
                //    }
                //    finally
                //    {
                //        outputCount++;
                //    }
                //}

                //if (loadBinaryItems && _titleInfo.Cover != null)
                //{

                //    foreach (InlineImageItem coverImag in _titleInfo.Cover.CoverpageImages)
                //    {
                //        if (string.IsNullOrEmpty(coverImag.HRef))
                //        {
                //            continue;
                //        }
                //        string coverref = coverImag.HRef.Substring(0, 1) == "#" ? coverImag.HRef.Substring(1) : coverImag.HRef;
                //        IEnumerable<XElement> xBinaryes =
                //            document.Root.Elements(_fileNameSpace + Fb2BinaryElementName).Where(
                //                cov => ((cov.Attribute("id") != null) && (cov.Attribute("id").Value == coverref)));
                //        foreach (var binarye in xBinaryes)
                //        {
                //            var item = new BinaryItem();
                //            try
                //            {
                //                item.Load(binarye);
                //            }
                //            catch (Exception)
                //            {

                //                continue;
                //            }
                //            // add just unique IDs to fix some invalid FB2s 
                //            if (!_binaryObjects.ContainsKey(item.Id))
                //            {
                //                _binaryObjects.Add(item.Id, item);
                //            }
                //        }
                //    }
                //}
            }
        }
    }
}