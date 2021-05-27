using System.Diagnostics;
using System.Web.Mvc;
using System.Web.Routing;
using AtomicSeller.Helpers.Security;

namespace AtomicSeller.Filters
{
    /**
     * This filter allows us to retry a request to let filters initalize context:
     * 
     * HTTPModule cannot deobfuscate request
     * Filters initializes context (authentication, SessionBag)
     * This filter kills the current request and refreshes page
     * HTTPModule can deobfuscate request
     */
    public class QueryStringDeobfCatchupFilter : BaseFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var httpContext = filterContext.HttpContext;
            var requestId = httpContext.Items[DeobfuscateQueryStringHTTPModule.HttpContextKey_RequestIdentifier];

            // We caught an error in HTTPModule
            if (httpContext.Items[DeobfuscateQueryStringHTTPModule.HttpContextKey_Retry] != null)
            {
                Debug.WriteLine("[" + requestId + "] Cauth an unobfuscation error, redirecting to self");

                filterContext.Result = GetRedirectActionResult(
                    filterContext: filterContext,
                    additionalQueryStringValues: new RouteValueDictionary { { "retry", 1} }
                );
            }
        }
    }
}
