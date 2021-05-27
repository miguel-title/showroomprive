using System.Web.Mvc;
using AtomicSeller.Filters;

namespace AtomicSeller
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthentificationFilter());
            filters.Add(new SessionBagFilter());
            filters.Add(new QueryStringDeobfCatchupFilter());
            filters.Add(new AuthorizeAttribute());
        }
    }
}
