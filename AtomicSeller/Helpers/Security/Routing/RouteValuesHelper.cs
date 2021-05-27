// Decompiled with JetBrains decompiler
// Type: System.Web.Mvc.RouteValuesHelpers
// Assembly: System.Web.Mvc, Version=5.2.3.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CC73190B-AB9D-435C-8315-10FF295C572A
// Assembly location: C:\Workspace\Axinod V3 TMA\Developpement Monaco\AtomicSeller\packages\Microsoft.AspNet.Mvc.5.2.3\lib\net45\System.Web.Mvc.dll

using System.Collections.Generic;
using System.Web.Routing;

namespace AtomicSeller.Helpers.Security.Routing
{
    internal static class RouteValuesHelpers
    {
        public static RouteValueDictionary GetRouteValues(RouteValueDictionary routeValues)
        {
            if (routeValues == null)
                return new RouteValueDictionary();
            return new RouteValueDictionary((IDictionary<string, object>)routeValues);
        }

        public static RouteValueDictionary MergeRouteValues(string actionName, string controllerName, RouteValueDictionary implicitRouteValues, RouteValueDictionary routeValues, bool includeImplicitMvcValues)
        {
            RouteValueDictionary routeValueDictionary = new RouteValueDictionary();
            if (includeImplicitMvcValues)
            {
                object obj;
                if (implicitRouteValues != null && implicitRouteValues.TryGetValue("action", out obj))
                    routeValueDictionary["action"] = obj;
                if (implicitRouteValues != null && implicitRouteValues.TryGetValue("controller", out obj))
                    routeValueDictionary["controller"] = obj;
            }
            if (routeValues != null)
            {
                foreach (KeyValuePair<string, object> routeValue in RouteValuesHelpers.GetRouteValues(routeValues))
                    routeValueDictionary[routeValue.Key] = routeValue.Value;
            }
            if (actionName != null)
                routeValueDictionary["action"] = (object)actionName;
            if (controllerName != null)
                routeValueDictionary["controller"] = (object)controllerName;
            return routeValueDictionary;
        }
    }
}
