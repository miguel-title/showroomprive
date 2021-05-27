using System.Web.Mvc;
using System.Web.Routing;

namespace AtomicSeller.Filters
{
    public class BaseFilter : ActionFilterAttribute
    {
        protected RedirectToRouteResult GetRedirectActionResult(ActionExecutingContext filterContext, bool keepQueryString = true, string controller=null, string action=null,
            RouteValueDictionary additionalQueryStringValues=null)
        {
            var request = filterContext.HttpContext.Request;
            var routeData = request.RequestContext.RouteData;

            var routeValueDictionary = new RouteValueDictionary(new
            {
                controller = controller ?? routeData.Values["controller"],
                action = action ?? routeData.Values["action"]
            });

            if (keepQueryString)
            {
                foreach (var key in request.QueryString.AllKeys)
                    routeValueDictionary.Add(key, request.QueryString[key]);
            }

            if (additionalQueryStringValues != null)
            {
                foreach (var item in additionalQueryStringValues)
                    routeValueDictionary.Add(item.Key, item.Value);
            }

            return new RedirectToRouteResult(routeValueDictionary);
        }
    }
}
