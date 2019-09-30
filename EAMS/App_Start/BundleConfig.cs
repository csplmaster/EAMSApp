using System.Web;
using System.Web.Optimization;

namespace EAMS
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/eamscss").Include(
                      "~/Content/bower_components/bootstrap/dist/css/bootstrap.min.css"));

            bundles.Add(new StyleBundle("~/Content/themify").Include(
                      "~/Content/icon/themify-icons/themify-icons.css"));

            bundles.Add(new StyleBundle("~/Content/iconfont").Include(
                      "~/Content/icon/icofont/css/icofont.css",
                      "~/Content/icon/font-awesome/css/font-awesome.min.css"
                      ));
            
            bundles.Add(new StyleBundle("~/Content/flagicon").Include(
                      "~/Content//pages/flag-icon/flag-icon.min.css"));

            bundles.Add(new StyleBundle("~/Content/menusearch").Include(
                    "~/Content//pages/menu-search/css/component.css"));

            bundles.Add(new StyleBundle("~/Content/horizontaltimeline").Include(
                    "~/Content//pages/dashboard/horizontal-timeline/css/style.css"));

            bundles.Add(new StyleBundle("~/Content/eamsamchart").Include(
                    "~/Content/pages/dashboard/amchart/css/amchart.css"));

            bundles.Add(new StyleBundle("~/Content/styles").Include(
                    "~/Content/css/style.css",
                    "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/eamscolor").Include(
                        "~/Content/css/color/color-1.css"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryb").Include(
                "~/Scripts/jquery-3.1.0.min.js",
                "~/Content/bower_components/jquery/dist/jquery.min.js",
                "~/Content/bower_components/tether/dist/js/tether.min.js",
                "~/Content/bower_components/bootstrap/dist/js/bootstrap.min.js",
                "~/Content/bower_components/jquery-ui/jquery-ui.min.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryslimscroll").Include(
            "~/Content/bower_components/jquery-slimscroll/jquery.slimscroll.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizer").Include(
            "~/Content/bower_components/modernizr/modernizr.js", 
            "~/Content/bower_components/modernizr/feature-detects/css-scrollbars.js", 
            "~/Content/bower_components/classie/classie.js",
            "~/Content/bower_components/d3/d3.js",
            "~/Content/bower_components/rickshaw/rickshaw.js"));

            bundles.Add(new ScriptBundle("~/bundles/eamsmisc").Include(
            "~/Content/bower_components/raphael/raphael.min.js",
            "~/Content/bower_components/morris.js/morris.js",
            "~/Content/pages/dashboard/horizontal-timeline/js/main.js",
            "~/Content/pages/dashboard/amchart/js/amcharts.js",
            "~/Content/pages/dashboard/amchart/js/serial.js",
            "~/Content/pages/dashboard/amchart/js/light.js",
            "~/Content/pages/dashboard/amchart/js/custom-amchart.js",
            "~/Content/bower_components/i18next/i18next.min.js",
            "~/Content/bower_components/i18next-xhr-backend/i18nextXHRBackend.min.js",
            "~/Content/bower_components/i18next-browser-languagedetector/i18nextBrowserLanguageDetector.min.js",
            "~/Content/bower_components/jquery-i18next/jquery-i18next.min.js",
            "~/Content/pages/dashboard/custom-dashboard.js",
            "~/Content/js/script.js"));

            bundles.Add(new StyleBundle("~/Content/EamsDataTables").Include(
                    "~/Content/DataTables/datatables.css"
                ));

            bundles.Add(new ScriptBundle("~/Script/EamsDataTables").Include(
                "~/Content/DataTables/datatables.js",
                "~/Content/DataTables/Other/CustomDataTable.js"
                ));

            bundles.Add(new StyleBundle("~/Content/MultiSelect").Include(
                "~/Content/MultiSelectList/css/bootstrap-multiselect.css",
                "~/Content/bower_components/jquery-ui/jquery-ui.min.css"
                ));

            bundles.Add(new ScriptBundle("~/Script/MultiSelect").Include(
                "~/Content/MultiSelectList/js/bootstrap-multiselect.js"
                ));
        }
    }
}
