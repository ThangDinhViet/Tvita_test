using System.Web;
using System.Web.Optimization;

namespace Tvita_Test
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/appscript").Include(
                        "~/Scripts/iframe_api.js",
                        "~/Scripts/tvita/layout.js",
                        "~/Scripts/slideshow/slideshow.js"));

            bundles.Add(new ScriptBundle("~/bundles/multilanguage").Include(
                        "~/Scripts/i18n/libs/CLDRPluralRuleParser/src/CLDRPluralRuleParser.js",
                        "~/Scripts/i18n/src/jquery.i18n.js",
                        "~/Scripts/i18n/src/jquery.i18n.messagestore.js",
                        "~/Scripts/i18n/src/jquery.i18n.fallbacks.js",
                        "~/Scripts/i18n/src/jquery.i18n.parser.js",
                        "~/Scripts/i18n/src/jquery.i18n.emitter.js",
                        "~/Scripts/i18n/src/jquery.i18n.language.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Content/slide_panel/js/main.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/font-awesome.css",
                      "~/Content/site.css",
                      "~/Content/css/tvita_navbar.css",
                      "~/Content/slideshow/slideshow.css"));
            bundles.Add(new StyleBundle("~/Content/csslandingpage").Include(
                     "~/Content/font-awesome.css",
                     "~/Content/css/tvita_navbar.css"));

        }
    }
}
