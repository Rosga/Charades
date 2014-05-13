using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Charades.WebUI.Models;

namespace Charades.WebUI.HtmlHelpers
{
    /// <summary>
    /// Класс расширяющий HTMLHelper
    /// </summary>
    public static class PageHelpers
    {
        /// <summary>
        /// Представляет помощь в отображении ссылок на страницы 
        /// </summary>
        /// <param name="html">расширяющий класс</param>
        /// <param name="pagingInfo">модель представления страницы</param>
        /// <param name="pageUrl">делегат для генерации ссылок, обеспечивающий просмотр других страниц</param>
        /// <returns>Возвращает HTML-раметку ссылок на страницы</returns>
        public static MvcHtmlString PageLinks(this HtmlHelper html,
            PagingInfo pagingInfo, Func<int, string> pageUrl)
        {

            var result = new StringBuilder();

            //пройтись по всем страницам представления
            for (int i = 1; i <= pagingInfo.TotalPages; i++)
            {
                //создать дескриптор <a> для передачаи ссылок на страницы
                var tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                    //отобразить номер страницы
                tag.InnerHtml = i.ToString();

                //пометить текущую страницу классом selected
                if (i ==pagingInfo.CurrentPage)
                {
                    tag.AddCssClass("selected");
                }
                result.Append(tag.ToString());
            }

            return MvcHtmlString.Create(result.ToString());
        }
    }
}