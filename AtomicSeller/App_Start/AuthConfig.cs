using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AtomicSeller;
using AtomicSeller.Helpers;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(AtomicSeller.AuthConfig))]
namespace AtomicSeller
{
    public class AuthConfig
    {
        private const int CookieExpireTimeSpan = 120; // minutes

        public void Configuration(IAppBuilder app)
        {
            var provider = new CookieAuthenticationProvider();
            var url = new UrlHelper(HttpContext.Current.Request.RequestContext);

            // We override the OnApplyRedirect mechanism to generate our own redirect URL
            var originalHandler = provider.OnApplyRedirect;

            /*
            provider.OnApplyRedirect = context =>
            {
                var mvcContext = new HttpContextWrapper(HttpContext.Current);

                var newUrl = url.Action("Login", "Account");
                // Remove ?...
                if (newUrl != null && newUrl.Contains("?"))
                    newUrl = newUrl.Substring(0, newUrl.IndexOf('?'));

                context.RedirectUri = newUrl;
                // Call original handler with the modified context
                originalHandler.Invoke(context);
            };

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"), // <- ignored, but still required
                Provider = provider,
                ExpireTimeSpan = TimeSpan.FromMinutes(CookieExpireTimeSpan)
            });
            */

            //string timeNow = DateTime.Now.ToString();

            //Tools.ErrorHandler("AuthcConfig Launching application at " + timeNow, null, false, true, false, null);
        }
    }
}