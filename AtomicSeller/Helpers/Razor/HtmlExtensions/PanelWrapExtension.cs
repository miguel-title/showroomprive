using System;
using System.IO;
using System.Web.Mvc;

namespace AtomicSeller.Helpers.Razor.HtmlExtensions
{
    public static class PanelWrapExtension
    {
        private class PanelWrapContainer : IDisposable
        {
            private readonly TextWriter writer;

            public PanelWrapContainer(TextWriter writer)
            {
                this.writer = writer;
            }

            public void Dispose()
            {
                writer.Write(
                    "    </div>" +
                    "</div>"
                );
            }
        }

        public enum ContentType
        {
            Table,
            Text,
            Raw
        }

        public static IDisposable PanelWrap(this HtmlHelper htmlHelper, string panelTitle, ContentType type = ContentType.Raw, string classes = "", bool primary=true, string classeTitle = "")
        {
            classes += " panel" + (primary ? " panel-primary" : "");
            var contentWrapClass = type.ToString().ToLowerInvariant() + "-wrap";
            if (type == ContentType.Text)
                contentWrapClass += " panel-body";

            var writer = htmlHelper.ViewContext.Writer;
            writer.WriteLine(
                "<div class=\"" + classes + "\">" +
                "    <div class=\"panel-heading "+ classeTitle +"\">" + panelTitle + "</div>" +
                "    <div class=\"" + contentWrapClass + "\">"
            );
            return new PanelWrapContainer(writer);
        }
    }
}
