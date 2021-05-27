using System.Web.Optimization;

namespace AtomicSeller
{
    public class BundleConfig
    {
        private const string ThirdPartyLibsDir = "~/Resources/3d";

        // Pour plus d'informations sur le regroupement, visitez http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Dépendances JS tierce-parties
            bundles.Add(new ScriptBundle("~/bundles/js3d").Include(
                        ThirdPartyLibsDir + "/js/bootstrap-datepicker.js",
                        ThirdPartyLibsDir + "/js/bootstrap-datepicker.fr.min.js",
                        ThirdPartyLibsDir + "/js/bootstrap-timepicker.js",

                        ThirdPartyLibsDir + "/js/globalize/globalize.js",
                        ThirdPartyLibsDir + "/js/globalize/cultures/globalize.culture.fr-FR.js",

                        ThirdPartyLibsDir + "/js/jquery.maskedinput.min.js",
                        ThirdPartyLibsDir + "/js/autoNumeric.min.js",
                        ThirdPartyLibsDir + "/js/jquery.validate.min.js",
                        ThirdPartyLibsDir + "/js/validation.js",

                        ThirdPartyLibsDir + "/js/filebutton.js",
                        ThirdPartyLibsDir + "/js/jquery.joyride-2.1.js",
                        ThirdPartyLibsDir + "/js/jquery.cookie.js",
                        ThirdPartyLibsDir + "/js/Select2/select2.js",
                        ThirdPartyLibsDir + "/js/Chart.bundle.min.js"
            ));

            // JS perso (principal + libs)
            bundles.Add(new ScriptBundle("~/bundles/javascript").Include(
                      "~/Resources/js/lib/lib-utils.js",
                      "~/Resources/js/lib/lib-forms.js",
                      "~/Resources/js/lib/lib-metier.js",
                      "~/Resources/js/lib/component-confirm.js",
                      "~/Resources/js/lib/component-drawer.js",
                      "~/Resources/js/lib/component-form-dynamism.js",
                      "~/Resources/js/lib/component-password-strength.js",
                      "~/Resources/js/visite-guidee.js",
                      "~/Resources/js/script.js"
            ));

            // CSS is directly imported in its own tag in _Layout & _Layout-login

            bundles.IgnoreList.Clear();

            // To group & mignify resources in debug just as it's done in prod, uncomment the following line:
            //BundleTable.EnableOptimizations = true;
        }
    }
}

/*
namespace ParcelAPI
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));
        }
    }
}
*/