using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Website
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/js/jquery-2.1.4.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/js/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/tablesorter").Include(
                      "~/js/jquery.tablesorter.widgets.min.js",
                      "~/js/jquery.tablesorter.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/custom").Include(
                      "~/js/common.js"));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                      "~/css/bootstrap.min.css",
                      "~/css/style.css",
                      "~/css/tablesorter.theme.default.css",
                      "~/css/font-awesome.min.css",
                      "~/css/circle-side.css"));
        }
    }
}