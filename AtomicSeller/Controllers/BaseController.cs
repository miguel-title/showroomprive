using System;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AtomicSeller.Helpers;
using AtomicSeller.Helpers.Security.Routing;
using RedirectToRouteResult = AtomicSeller.Helpers.Security.Routing.RedirectToRouteResult;

namespace AtomicSeller.Controllers
{
    public class BaseController : Controller
    {
        public void Flash(FlashMessage flashMessage)
        {
            FlashMessage.Flash(TempData, flashMessage);
        }

        /// <summary>Effectue une redirection vers l'action spécifiée à l'aide du nom d'action et des valeurs d'itinéraire.</summary>
        /// <returns>Objet résultat de la redirection.</returns>
        /// <param name="actionName">Nom de l'action.</param>
        /// <param name="routeValues">Paramètres d'un itinéraire.</param>
        protected internal new RedirectToRouteResult RedirectToAction(string actionName, object routeValues)
        {
            return this.RedirectToAction(actionName, TypeHelper.ObjectToDictionary(routeValues));
        }

        /// <summary>Effectue une redirection vers l'action spécifiée à l'aide du nom d'action et du dictionnaire d'itinéraires.</summary>
        /// <returns>Objet résultat de la redirection.</returns>
        /// <param name="actionName">Nom de l'action.</param>
        /// <param name="routeValues">Paramètres d'un itinéraire.</param>
        protected internal new RedirectToRouteResult RedirectToAction(string actionName, RouteValueDictionary routeValues)
        {
            return this.RedirectToAction(actionName, (string)null, routeValues);
        }

        /// <summary>Effectue une redirection vers l'action spécifiée à l'aide du nom d'action et du nom de contrôleur.</summary>
        /// <returns>Objet résultat de la redirection.</returns>
        /// <param name="actionName">Nom de l'action.</param>
        /// <param name="controllerName">Nom du contrôleur.</param>
        protected internal new RedirectToRouteResult RedirectToAction(string actionName, string controllerName)
        {
            return this.RedirectToAction(actionName, controllerName, (RouteValueDictionary)null);
        }

        /// <summary>Effectue une redirection vers l'action spécifiée à l'aide du nom d'action, du nom de contrôleur et du dictionnaire d'itinéraires.</summary>
        /// <returns>Objet résultat de la redirection.</returns>
        /// <param name="actionName">Nom de l'action.</param>
        /// <param name="controllerName">Nom du contrôleur.</param>
        /// <param name="routeValues">Paramètres d'un itinéraire.</param>
        protected internal new RedirectToRouteResult RedirectToAction(string actionName, string controllerName, object routeValues)
        {
            return this.RedirectToAction(actionName, controllerName, TypeHelper.ObjectToDictionary(routeValues));
        }

        /// <summary>Effectue une redirection vers l'action spécifiée à l'aide du nom d'action, du nom de contrôleur et des valeurs d'itinéraire.</summary>
        /// <returns>Objet résultat de la redirection.</returns>
        /// <param name="actionName">Nom de l'action.</param>
        /// <param name="controllerName">Nom du contrôleur.</param>
        /// <param name="routeValues">Paramètres d'un itinéraire.</param>
        protected internal new virtual RedirectToRouteResult RedirectToAction(string actionName, string controllerName, RouteValueDictionary routeValues)
        {
            return new RedirectToRouteResult(this.RouteData != null ? RouteValuesHelpers.MergeRouteValues(actionName, controllerName, this.RouteData.Values, routeValues, true) : RouteValuesHelpers.MergeRouteValues(actionName, controllerName, (RouteValueDictionary)null, routeValues, true));
        }

        /// <summary>Retourne une instance de la classe <see cref="T:System.Web.Mvc.RedirectResult" /> avec la valeur true attribuée à la propriété Permanent à l'aide du nom d'action et des valeurs d'itinéraire spécifiés.</summary>
        /// <returns>Instance de la classe <see cref="T:System.Web.Mvc.RedirectResult" /> avec la valeur true attribuée à la propriété Permanent à l'aide du nom d'action et des valeurs d'itinéraire spécifiés.</returns>
        /// <param name="actionName">Nom de l'action.</param>
        /// <param name="routeValues">Valeurs d'itinéraire.</param>
        protected internal new RedirectToRouteResult RedirectToActionPermanent(string actionName, object routeValues)
        {
            return this.RedirectToActionPermanent(actionName, TypeHelper.ObjectToDictionary(routeValues));
        }

        /// <summary>Retourne une instance de la classe <see cref="T:System.Web.Mvc.RedirectResult" /> avec la valeur true attribuée à la propriété Permanent à l'aide du nom d'action et des valeurs d'itinéraire spécifiés.</summary>
        /// <returns>Instance de la classe <see cref="T:System.Web.Mvc.RedirectResult" /> avec la valeur true attribuée à la propriété Permanent à l'aide du nom d'action et des valeurs d'itinéraire spécifiés.</returns>
        /// <param name="actionName">Nom de l'action.</param>
        /// <param name="routeValues">Valeurs d'itinéraire.</param>
        protected internal new RedirectToRouteResult RedirectToActionPermanent(string actionName, RouteValueDictionary routeValues)
        {
            return this.RedirectToActionPermanent(actionName, (string)null, routeValues);
        }

        /// <summary>Effectue une redirection vers l'action spécifiée à l'aide du nom d'action et du nom de contrôleur.</summary>
        /// <returns>Objet résultat de la redirection.</returns>
        /// <param name="actionName">Nom de l'action.</param>
        /// <param name="controllerName">Nom du contrôleur.</param>
        protected internal new RedirectToRouteResult RedirectToActionPermanent(string actionName, string controllerName)
        {
            return this.RedirectToActionPermanent(actionName, controllerName, (RouteValueDictionary)null);
        }

        /// <summary>Retourne une instance de la classe <see cref="T:System.Web.Mvc.RedirectResult" /> avec la valeur true attribuée à la propriété Permanent à l'aide du nom d'action, du nom de contrôleur et des valeurs d'itinéraire spécifiés.</summary>
        /// <returns>Instance de la classe <see cref="T:System.Web.Mvc.RedirectResult" /> avec la valeur true attribuée à la propriété Permanent à l'aide du nom d'action, du nom de contrôleur et des valeurs d'itinéraire spécifiés.</returns>
        /// <param name="actionName">Nom de l'action.</param>
        /// <param name="controllerName">Nom du contrôleur.</param>
        /// <param name="routeValues">Valeurs d'itinéraire.</param>
        protected internal new RedirectToRouteResult RedirectToActionPermanent(string actionName, string controllerName, object routeValues)
        {
            return this.RedirectToActionPermanent(actionName, controllerName, TypeHelper.ObjectToDictionary(routeValues));
        }

        /// <summary>Retourne une instance de la classe <see cref="T:System.Web.Mvc.RedirectResult" /> avec la valeur true attribuée à la propriété Permanent à l'aide du nom d'action, du nom de contrôleur et des valeurs d'itinéraire spécifiés.</summary>
        /// <returns>Instance de la classe <see cref="T:System.Web.Mvc.RedirectResult" /> avec la valeur true attribuée à la propriété Permanent à l'aide du nom d'action, du nom de contrôleur et des valeurs d'itinéraire spécifiés.</returns>
        /// <param name="actionName">Nom de l'action.</param>
        /// <param name="controllerName">Nom du contrôleur.</param>
        /// <param name="routeValues">Valeurs d'itinéraire.</param>
        protected internal new virtual RedirectToRouteResult RedirectToActionPermanent(string actionName, string controllerName, RouteValueDictionary routeValues)
        {
            RouteValueDictionary implicitRouteValues = this.RouteData != null ? this.RouteData.Values : (RouteValueDictionary)null;
            return new RedirectToRouteResult((string)null, RouteValuesHelpers.MergeRouteValues(actionName, controllerName, implicitRouteValues, routeValues, true), true);
        }

        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            string cultureName = null;

            // Attempt to read the culture cookie from Request
            HttpCookie cultureCookie = Request.Cookies["_culture"];
            if (cultureCookie != null)
                cultureName = cultureCookie.Value;
            else
                cultureName = Request.UserLanguages != null && Request.UserLanguages.Length > 0 ?
                        Request.UserLanguages[0] :  // obtain it from HTTP header AcceptLanguages
                        null;
            // Validate culture name
            cultureName = CultureHelper.GetImplementedCulture(cultureName); // This is safe

            // Modify current thread's cultures            
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cultureName);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

            ////// Ajout Patrice 21/01/2019 sur conseils Bryan
            cultureName = Thread.CurrentThread.CurrentUICulture.Name.ToLowerInvariant();
            System.Globalization.CultureInfo Culture;
            Culture = Thread.CurrentThread.CurrentUICulture;
            string CultureCode = Culture.Name;

            return base.BeginExecuteCore(callback, state);
        }
    }
}
