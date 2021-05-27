//using AtomicAPI.Models;
//using AtomicParcelAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.SessionState;

using System.Security.Claims;
using System.Web.Routing;
using AtomicSeller.Helpers;
using System.Web.Helpers;
using AtomicSeller.Helpers.Security;

[assembly: PreApplicationStartMethod(typeof(AtomicSeller.MvcApplication), "RegisterHttpModules")]

//[assembly: PreApplicationStartMethod(typeof(ParcelAPI.WebApiApplication), "RegisterHttpModules")]


namespace AtomicSeller
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            GlobalConfiguration.Configure(WebApiConfig.Register);

            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Déclaration de quel Claim est le UniqueIdentifier sur les sessions
            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.Sid;

            try
            {
                //ApplicationWrapper.ErrorList = APIErrors.GetErrors();
                //ApplicationWrapper.TokenList = APIErrorManagement.GetTokenList();

            }
            catch (Exception ex)
            {

            }

            //JobScheduler.GlobalStartAllJobs();
        }

        public static void RegisterHttpModules()
        {
            RegisterModule(typeof(DeobfuscateQueryStringHTTPModule));
        }

        private void Application_Error(Object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
        }

        protected void Application_PostAuthorizeRequest()
        {
            HttpContext.Current.SetSessionStateBehavior(SessionStateBehavior.Required);
        }

        /*
        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            if (_isHttps)
            {
                if (HttpContext.Current.Request.IsSecureConnection.Equals(false) && HttpContext.Current.Request.IsLocal.Equals(false))
                {
                    Response.Redirect("https://" + Request.ServerVariables["HTTP_HOST"]
                + HttpContext.Current.Request.RawUrl);
                }
            }
        }
        */
    }
}

namespace AtomicAPI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode,
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        private bool _isHttps = false;

        public WebApiApplication()
        {
            var appSetting = ConfigurationManager.AppSettings["IsHttps"];
            _isHttps = string.IsNullOrWhiteSpace(appSetting) || appSetting == "0" ? false : true;
        }

        protected void Application_Start()
        {

            try
            {
                if (ConfigurationSettings.AppSettings["SSCertificate"].ToString() == "1")
                {
                    ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                }
            }
            catch (Exception)
            {

            }

            AreaRegistration.RegisterAllAreas();

            GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None;

            //WebApiConfig.Register(GlobalConfiguration.Configuration);
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);

            try
            {
                //ApplicationWrapper.ErrorList = GetErrors();

                //ApplicationWrapper.TokenList = GetTokenList();
            }
            catch (Exception ex)
            {

            }
        }

    }
}