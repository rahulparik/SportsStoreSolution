using SportsStoreMVCWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SportsStoreMVCWebApp.HtmlHelpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, PagingInfo pagingInfo, string category, Func<int, string> pageUrl)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= pagingInfo.TotalPage; i++)
            {
                TagBuilder tag = new TagBuilder("a"); //Creates a element "<a>"
                tag.MergeAttribute("href", pageUrl(i));
                if (category == null)
                {
                    tag.InnerHtml = string.Format("{0}", i); 
                }
                else
                {
                    tag.InnerHtml = string.Format("{0}:{1}", category, i);
                }
                if (i == pagingInfo.CurrentPage)
                {
                    tag.AddCssClass("selected");
                }
                sb.Append(tag.ToString());
            }
            return MvcHtmlString.Create(sb.ToString());
        }


        #region Without Category
        public static MvcHtmlString PageLinks(this HtmlHelper html, PagingInfo pagingInfo, Func<int, string> pageUrl)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= pagingInfo.TotalPage; i++)
            {
                TagBuilder tag = new TagBuilder("a"); //Creates a element "<a>"
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = string.Format("{0}", i);
                if (i == pagingInfo.CurrentPage)
                {
                    tag.AddCssClass("selected");
                }
                sb.Append(tag.ToString());
            }
            return MvcHtmlString.Create(sb.ToString());
        } 
        #endregion
    }
}