using System.Collections.Generic;
using System.Web.Mvc;

namespace AtomicSeller.Helpers.Razor.HtmlExtensions
{
    public static class PaginationExtension
    {
        public static MvcHtmlString Pagination(this HtmlHelper htmlHelper, int currentPage, int pagesCount)
        {
            var links = new List<string>();

            // Previous link
            links.Add(getLink("« Précédent", currentPage == 1 ? -1 : currentPage-1));

            // Add 3 pages links before & 3 after current page
            var fromIndex = currentPage - 3;
            var toIndex = currentPage + 3;

            // Add first page link
            if (fromIndex > 1)
            {
                if (fromIndex - 1 > 1) // There's a hidden link
                    links.Add(getLink(1.ToString(), 1));
                links.Add(getLink("&hellip;"));
            }

            for (var i = fromIndex; i <= toIndex; i++)
            {
                if (i < 1 || i > pagesCount)
                    continue;

                links.Add(getLink(i.ToString(), i, i == currentPage));
            }

            // Add last page link
            if (toIndex < pagesCount)
            {
                if (pagesCount - toIndex > 1) // There's a hidden link
                    links.Add(getLink("&hellip;"));
                links.Add(getLink(pagesCount.ToString(), pagesCount));
            }

            // Next link
            links.Add(getLink("Suivant »", currentPage == pagesCount ? -1 : currentPage + 1));


            var html =
                "<div class=\"pagination-wrap\">" +
                "    <ul class=\"pagination\">";

            foreach (var link in links)
                html += link;

            html +=
                "    </ul>" +
                "</div>";

            return new MvcHtmlString(html);
        }

        private static string getLink(string text, int targetPage=-1, bool active=false)
        {
            var liClasses =
                (targetPage == -1 ? "disabled" : "") + " " +
                (active ? "active" : "");

            var wrapTag = targetPage == -1 ? "span" : "a";
            var wrapAttributes = targetPage == -1 ? "" : "data-page=\"" + targetPage + "\"";

            return
                "<li class=\"" + liClasses + "\">" +
                "    <" + wrapTag + " " + wrapAttributes + ">" +
                "        " + text +
                "    </" + wrapTag + ">" +
                "</li>";
        }
    }
}
