using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Linq;
using Library.FictionBook.Models;
using Library.FictionBook.Models.Core;
using Library.FictionBook.Models.Interfaces;
using Library.FictionBook.Models.Style;

namespace Library.FictionBook.Core
{
    public enum TextStyle
    {
        Normal = 0,
        Strong, // <strong>
        Emphasis, // <emphasis>
        Code, // <code>
        Sub, // <sub>
        Sup, // <sup>
        Strikethrough, //<strikethrough>
    }

    public static class ModelFactory 
    {
        public static IModel Resolve(this XElement node)
        {
            return Resolve(node.Name.LocalName);
        }
        public static IModel Resolve(this string name)
        {
            IModel model = null;

            if (name == FictionBookConstants.Paragraph)
            {
                //model = new ParagraphModel();
            }

            if (name == FictionBookConstants.Poem)
            {
                
            }

            if (name == FictionBookConstants.Cite)
            {
                
            }

            if (name == FictionBookConstants.Subtitle)
            {
                
            }

            if (name == FictionBookConstants.Table)
            {
                
            }

            if (name == FictionBookConstants.EmptyLine)
            {
                
            }

            return model;

            //switch (name)
            //{
            //    case FictionBookConstants.Paragraph:
            //        ParagraphItem paragraph = new ParagraphItem();
            //        try
            //        {
            //            paragraph.Load(xItem);
            //            content.Add(paragraph);
            //        }
            //        catch (Exception)
            //        {
            //        }
            //        break;
            //    case PoemItem.Fb2PoemElementName:
            //        PoemItem poem = new PoemItem();
            //        try
            //        {
            //            poem.Load(xItem);
            //            content.Add(poem);
            //        }
            //        catch (Exception)
            //        {
            //        }
            //        break;
            //    case CiteItem.Fb2CiteElementName:
            //        CiteItem cite = new CiteItem();
            //        try
            //        {
            //            cite.Load(xItem);
            //            content.Add(cite);
            //        }
            //        catch (Exception)
            //        {
            //        }
            //        break;
            //    case SubTitleItem.Fb2SubtitleElementName:
            //        SubTitleItem subtitle = new SubTitleItem();
            //        try
            //        {
            //            subtitle.Load(xItem);
            //            content.Add(subtitle);
            //        }
            //        catch (Exception)
            //        {
            //        }
            //        break;
            //    case TableItem.Fb2TableElementName:
            //        TableItem table = new TableItem();
            //        try
            //        {
            //            table.Load(xItem);
            //            content.Add(table);
            //        }
            //        catch (Exception)
            //        {
            //        }
            //        break;
            //    case EmptyLineItem.Fb2EmptyLineElementName:
            //        EmptyLineItem eline = new EmptyLineItem();
            //        content.Add(eline);
            //        break;
            //    default:
            //        Debug.WriteLine(string.Format("AnnotationItem:Load - invalid element <{0}> encountered in annotation ."), xItem.Name.LocalName);
            //        break;
            //}
        }

        public static IStyle ResolveStyle(this XElement node)
        {
            return ResolveStyle(node.Name.LocalName);
        }
        public static IStyle ResolveStyle(this string name)
        {
            IStyle node = null;

            if (name == FictionBookSchemaConstants.Style)
                node = new StyleModel();

            if (name == FictionBookConstants.InlineImage)
                node = new InlineImageModel();

            return node;
        }

        public static TextStyle GetTextStyle(this XElement element)
        {
            switch (element.Name.LocalName)
            {
                case "strong":
                    return TextStyle.Strong;
                case "emphasis":
                    return TextStyle.Emphasis;
                case "code":
                    return TextStyle.Code;
                case "sub":
                    return TextStyle.Sub;
                case "sup":
                    return TextStyle.Sup;
                case "strikethrough":
                    return TextStyle.Strikethrough;
                default:
                    return TextStyle.Normal;
            }

        }
        public static string GetTextStyle(this TextStyle style)
        {
            switch (style)
            {
                case TextStyle.Strong:
                    return "strong";
                case TextStyle.Emphasis:
                    return "emphasis";
                case TextStyle.Code:
                    return "code";
                case TextStyle.Sub:
                    return "sub";
                case TextStyle.Sup:
                    return "sup";
                case TextStyle.Strikethrough:
                    return "strikethrough";
                default:
                    return "";
            }
        }
    }
}