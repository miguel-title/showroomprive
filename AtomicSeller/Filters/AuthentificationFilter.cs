using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web.Mvc;
using AtomicSeller.Helpers;

namespace AtomicSeller.Filters
{
    /// <summary>
    /// Filtre pour recharger les informations de sessions si on est connecté et qu'elles sont nulles
    /// </summary>
    public class AuthentificationFilter : BaseFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var request = filterContext.HttpContext.Request;
            var session = filterContext.HttpContext.Session;
            var routeData = request.RequestContext.RouteData;

            // Check if authenticated
            if (request.IsAuthenticated)
            {

            }
        }
    }
}
