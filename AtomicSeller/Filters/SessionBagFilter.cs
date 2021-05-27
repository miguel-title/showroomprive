using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web.Mvc;
using AtomicSeller.Helpers;
using AtomicSeller.Helpers.Security;
using AtomicSeller.Models;

namespace AtomicSeller.Filters
{
    public class SessionBagFilter : BaseFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var request = filterContext.HttpContext.Request;
            var session = filterContext.HttpContext.Session;

            // DO NOT MERGE THE IF ABOVE WITH THE ONE BELOW

            // Init singleton if not set
            if (!SessionBag.Exists(session))
            {
                SessionBag.CreateNew(session);
            }

            if (request.IsAuthenticated)
            {
                var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
                var id = identity.Claims.Where(c => c.Type == ClaimTypes.Sid).Select(c => c.Value).SingleOrDefault();

            }
        }
    }
}
