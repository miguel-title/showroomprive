using AtomicSeller.Models;
using System;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;

namespace AtomicSeller.Helpers
{
    public class SessionBag
    {
        public const string SessionKey = "SessionBag";

        // Singleton stuff
        public static SessionBag Instance
        {
            get
            {
                HttpSessionState session = HttpContext.Current.Session;
                return (SessionBag)session[SessionKey];
            }
        }

        private SessionBag() { }

        /**
         * Creates a new SessionBag & puts it in session
         */

        public static SessionBag CreateNew(HttpSessionStateBase session)
        {
            return (SessionBag)(session[SessionKey] = new SessionBag());
        }

        public static SessionBag CreateNew(HttpSessionState session)
        {
            return CreateNew(new HttpSessionStateWrapper(session));
        }

        public static bool Exists(HttpSessionStateBase session)
        {
            return session[SessionKey] != null;
        }

        //public static SessionBag InitSingleton(HttpSessionStateBase session)
        //{
        //    return Instance = (SessionBag)session[SessionKey];
        //}

        // Fields
        public int UserId { get; set; }
        public string ConnectionString { get; set; }

        public string TenantDirectory { get; set; }
        public int ProfileID { get; set; }

        public int ClientID { get; set; }
        public string CheminLogo
        {
            get
            {
                return "/Resources/img/logo.png";
            }
        }

        public void Destroy(HttpSessionStateBase session)
        {
            session[SessionKey] = null;
            //Instance = null;
        }

        public string GetQueryStringObfuscationSharedSecret()
        {
            return SessionBag.Instance.UserId.ToString();
        }

        public static bool IsProd
        {
            get { return !HttpContext.Current.IsDebuggingEnabled; }
        }

    }
}
