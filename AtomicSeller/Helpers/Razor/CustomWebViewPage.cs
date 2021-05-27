using System.Web.Mvc;
using System.Web.Routing;

namespace AtomicSeller.Helpers.Razor
{
    public class CustomWebViewPage : WebViewPage
    {
        protected override void InitializePage()
        {
            Url = new UrlHelper(this.Request.RequestContext, RouteTable.Routes);
        }
        public new UrlHelper Url { get; private set; }

        public override void Execute() { }
    }

    public class CustomWebViewPage<T> : WebViewPage<T>
    {
        protected override void InitializePage()
        {
            customUrlHelper = new UrlHelper(this.Request.RequestContext, RouteTable.Routes);
        }

        private UrlHelper customUrlHelper;
        public new UrlHelper Url { get { return customUrlHelper; } }


        public override void Execute() { }
    }
}
