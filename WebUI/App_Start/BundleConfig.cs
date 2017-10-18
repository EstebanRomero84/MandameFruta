using System.Web;
using System.Web.Optimization;

namespace WebUI
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/bootstrap.css",
                        "~/Content/toastr.min.css",
                        "~/Content/typeahead.css",
                        "~/Content/custom.css"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/umd/popper.js",
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                      "~/Scripts/toastr.min.js",
                      "~/Scripts/jquery.blockui.min.js",
                      "~/Scripts/app.js"));

            bundles.Add(new ScriptBundle("~/bundles/typeahead").Include(
                      "~/Scripts/typeahead.bundle.min.js",
                      "~/Scripts/buscador.js"));

            bundles.Add(new ScriptBundle("~/bundles/GeoPicker").Include(
                      "~/Scripts/Geopicker.js"));
            bundles.Add(new ScriptBundle("~/bundles/mapa").Include(
                      "~/Scripts/Mapa.js"));

            bundles.Add(new ScriptBundle("~/bundles/login").Include(
                      "~/Scripts/jquery.unobtrusive-ajax.js",
                      "~/Scripts/login.js"));
        }
    }
}
