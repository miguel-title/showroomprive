using System.Web.Mvc;

namespace AtomicSeller.Helpers.Razor.HtmlExtensions
{
    public static class Extensions
    {
        public static MvcHtmlString NoDataMessage(this HtmlHelper helper, string message = "Aucune donnée.", string icon = "mdi-package-variant")
        {
            return new MvcHtmlString("<p class=\"info-message--huge\"><i class=\"mdi " + icon + "\"></i> " + message + "</p>");
        }
    }
}
