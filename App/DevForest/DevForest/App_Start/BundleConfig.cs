using System.Web;
using System.Web.Optimization;

namespace DevForest
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                       "~/Content/css/style.default.css"
                       ));


            bundles.Add(new ScriptBundle("~/bundles/misc").Include(
                    "~/Scripts/script/jquery-migrate-1.2.1.min.js",
                    "~/Scripts/script/jquery-ui-1.10.3.min.js",
                    "~/Scripts/script/jquery.sparkline.min.js",
                    "~/Scripts/script/jquery.cookies.js",
                    "~/Scripts/script/toggles.min.js",
                    "~/Scripts/script/retina.min.js",
                     "~/Scripts/script/custom.js"
                    ));

            bundles.Add(new ScriptBundle("~/bundles/dashboard").Include(
                  "~/Scripts/script/dashboard.js"
                  ));

            bundles.Add(new StyleBundle("~/Content/theme").Include(
                   "~/Content/css/style.greyjoy.css"
                   ));

            bundles.Add(new ScriptBundle("~/bundles/BootstrapTable").Include(
                  "~/Scripts/bootstrap-table-all.js",
                  "~/Scripts/bootstrap-table-export.js"
                  ));

            bundles.Add(new StyleBundle("~/Content/BootstarpTableCSS").Include(
                  "~/Content/css/bootstrap-table.css"
                  ));

        }
    }
}
