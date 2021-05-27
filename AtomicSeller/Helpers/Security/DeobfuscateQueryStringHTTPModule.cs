using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Web;

namespace AtomicSeller.Helpers.Security
{
    public class DeobfuscateQueryStringHTTPModule : IHttpModule
    {
        private const string HttpContextKeyPrefix = "DeobfuscateQueryStringProcess";
        public const string HttpContextKey_Retry = HttpContextKeyPrefix + "_Retry";
        public const string HttpContextKey_RequestIdentifier = HttpContextKeyPrefix + "_ReqId";

        private HttpContext context;
        private string requestIdentifier;

        public void Init(HttpApplication context)
        {
            context.AcquireRequestState += OnAcquireRequestState;
        }

        public void OnAcquireRequestState(object sender, EventArgs e)
        {
            context = ((HttpApplication)sender).Context;
            var queryString = context.Request.QueryString;
            var session = context.Session;

            // Attach a request identifier
            context.Items[HttpContextKey_RequestIdentifier] = requestIdentifier = GenerateRequestIdentifier();

            // Check if queryString is obfuscated
            if (queryString[QueryStringObfuscation.Key] != null)
            {
                // Check if sessionBag is available
                if (session != null && session.Keys.Count > 0)
                {
                    var sessionBag = (SessionBag)session[SessionBag.SessionKey];
                    if (sessionBag != null)
                    {
                        // Set queryString from readonly to readwrite so we can manipulate it
                        var readonlyProperty = queryString.GetType().GetProperty("IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
                        readonlyProperty.SetValue(queryString, false, null);

                        // Deobfuscate queryString
                        var sharedSecret = sessionBag.GetQueryStringObfuscationSharedSecret();
                        if (sharedSecret != null)
                        {
                            // Let's do this
                            var obf = queryString[QueryStringObfuscation.Key];
                            string deobf;
                            try
                            {
                                deobf = QueryStringObfuscation.Deobfuscate(obf, sharedSecret);
                            }
                            catch (Exception ex)
                            {
                                OnDeobfError("Could not deobfuscate queryString");
                                Debug.WriteLine(ex);
                                return;
                            }

                            Log("Deobfuscated queryString: " + deobf);

                            // Rewrite path
                            var path = GetVirtualPath(context);

                            if (!string.IsNullOrEmpty(path))
                                context.RewritePath(path, string.Empty, deobf);

                            // Restore queryString readonly attribute
                            readonlyProperty.SetValue(queryString, true, null);
                        }
                        else
                        {
                            OnDeobfError("Could not unobfuscate queryString: could not retrieve shared secret.");
                        }
                    }
                    else
                    {
                        OnDeobfError("Could not unobfuscate queryString: SessionBag is null.");
                    }
                }
                else
                {
                    OnDeobfError("Could not unobfuscate queryString: session is empty.");
                }
            }
        }

        /**
         * Called when the deobf process encounters an error
         */
        private void OnDeobfError(string message, bool retry=true)
        {
            var queryString = context.Request.QueryString;

            Log(message);

            // If we want to retry and haven't done it yet, and Http method is GET
            if (retry && !queryString.AllKeys.Contains("retry") && context.Request.HttpMethod.ToUpperInvariant() == "GET")
            {
                context.Items.Add(HttpContextKey_Retry, true);
            }
        }

        private void Log(string message)
        {
            Debug.WriteLine("[" + requestIdentifier + "] " + message);
        }

        private static string GetVirtualPath(HttpContext context)
        {
            string path = context.Request.RawUrl;
            var queryStringLength = path.IndexOf("?");
            path = path.Substring(0, queryStringLength >= 0 ? queryStringLength : path.Length);
            path = path.Substring(path.LastIndexOf("/") + 1);
            return path;
        }

        private string GenerateRequestIdentifier()
        {
            return Util.RandomString(4);
        }

        public void Dispose() { }
    }
}
