using System;
using System.IO;
using System.Web.Mvc;

namespace AtomicSeller.Helpers.Razor.HtmlExtensions
{
    public static class FieldsWrapExtension
    {
        private class FieldsWrapContainer : IDisposable
        {
            private readonly TextWriter writer;

            public FieldsWrapContainer(TextWriter writer)
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

        public static IDisposable FieldsWrap(this HtmlHelper htmlHelper, string labelText)
        {
            var writer = htmlHelper.ViewContext.Writer;
            writer.WriteLine(
                "<div class=\"form-group\">" +
                "    <label class=\"" + HtmlClasses.Label + "\">" + labelText + "</label>" +
                "    <div class=\"" + HtmlClasses.Control + "\">"
            );
            return new FieldsWrapContainer(writer);
        }
    }
}
