using System;
using System.IO;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace AtomicSeller.Helpers.Razor.HtmlExtensions
{
    public static class Wraps
    {
        /* FieldWrap */
        public enum FieldWrapType
        {
            /**
             * Default mode (uses EditorFor)
             */
            Default,
            /**
             * TextAreaFor
             */
            TextArea,
            /**
             * DisplayFor
             */
            Display,
            /**
             * DisplayFor + HiddenFor
             */
            DisplayWithHidden
        }

        private static string getFieldWrapStart(MvcHtmlString label)
        {
            return
                "<div class=\"form-group\">" +
                "    " + label +
                "    <div class=\"" + HtmlClasses.Control + "\">";
        }

        private static string getFieldWrapEnd()
        {
            return
                "    </div>" +
                "</div>";
        }

        public static MvcHtmlString getEditor<TModel, TValue>(HtmlHelper<TModel> html,
            Expression<Func<TModel, TValue>> expression, FieldWrapType type)
        {
            var attrs = new
            {
                @class = HtmlClasses.Input
            };

            switch (type)
            {
                case FieldWrapType.TextArea:
                    return html.TextAreaFor(expression, attrs);
                case FieldWrapType.Display:
                    return html.DisplayFor(expression);
                case FieldWrapType.DisplayWithHidden:
                    return HtmlHelpers.Concat(
                        html.DisplayFor(expression),
                        html.HiddenFor(expression)
                    );
                case FieldWrapType.Default:
                default:
                    return html.EditorFor(expression, attrs);
            }
        }

        /**
         * Standard FieldWrap (@Html.FieldWrap)
         */
        public static MvcHtmlString FieldWrap<TModel, TValue>(this HtmlHelper<TModel> html,
            Expression<Func<TModel, TValue>> expression, FieldWrapType type = FieldWrapType.Default)
        {
            var label = html.LabelFor(expression, new
            {
                @class = HtmlClasses.Label
            });
            var editor = getEditor(html, expression, type);

            return new MvcHtmlString(
                getFieldWrapStart(label) +
                editor +
                getFieldWrapEnd()
            );
        }

        /* Disposable FieldWrap (using FieldWrapWrap) */
        public class FieldWrapWrapContainer : IDisposable
        {
            private readonly TextWriter writer;

            public FieldWrapWrapContainer(TextWriter writer)
            {
                this.writer = writer;
            }

            public void Dispose()
            {
                writer.Write(getFieldWrapEnd());
            }
        }

        public static IDisposable FieldWrapWrap(this HtmlHelper html, string labelText)
        {
            var writer = html.ViewContext.Writer;

            var label = html.Label(labelText, new
            {
                @class = HtmlClasses.Label
            });
            writer.WriteLine(getFieldWrapStart(label));

            return new FieldWrapWrapContainer(writer);
        }
    }
}
