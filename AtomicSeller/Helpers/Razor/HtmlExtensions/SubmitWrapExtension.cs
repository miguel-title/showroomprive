using System.Web.Mvc;

namespace AtomicSeller.Helpers.Razor.HtmlExtensions
{
    public static class SubmitWrapExtension
    {
        public const string DefaultIcon = "mdi-chevron-right";
        public const Position DefaultPosition = Position.Offset;
        public const IconPosition DefaultIconPosition = IconPosition.Left;

        public enum Position
        {
            Inline,
            Offset,
            PullRight
        }

        public enum IconPosition
        {
            Left,
            Right
        }

        public static MvcHtmlString SubmitWrap(this HtmlHelper htmlHelper, string text, string icon = DefaultIcon,
            Position position = DefaultPosition, IconPosition iconPosition = DefaultIconPosition)
        {
            const string buttonClasses = "btn btn-primary";

            switch (position)
            {
                case Position.Inline:
                    return new MvcHtmlString(getButton(buttonClasses, text, icon, iconPosition));
                case Position.PullRight:
                    return new MvcHtmlString(getButton(buttonClasses + " pull-right", text, icon, iconPosition) + HtmlConsts.Snippets.ClearFix);
                case Position.Offset:
                default:
                    return new MvcHtmlString(
                        "<div class=\"form-group\">" +
                        "    <div class=\"" + HtmlClasses.ControlOffset + "\">" +
                        "        " + getButton(buttonClasses, text, icon, iconPosition) +
                        "    </div>" +
                        "</div>"
                    );
            }
        }

        private static string getButton(string buttonClasses, string text, string icon, IconPosition iconPosition)
        {
            return "        <button class=\"" + buttonClasses + "\" type=\"submit\">" +
                   "            " + text +
                   "            <i class=\"mdi " + icon + " position-" + iconPosition.ToString().ToLowerInvariant() + "\"></i>" +
                   "        </button>";
        }
    }
}
