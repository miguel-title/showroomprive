using System;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace AtomicSeller.Helpers
{
    public class EnumRouteConstraint : IRouteConstraint
    {
        private readonly Type enumType;

        public EnumRouteConstraint(Type enumType)
        {
            this.enumType = enumType;
        }

        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values,
            RouteDirection routeDirection)
        {
            return Enum.GetNames(enumType).Any(s => s.ToLowerInvariant() == values[parameterName].ToString());
        }
    }
}
