﻿using System.Web;
using System.Web.Optimization;

namespace ContosoSite
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-1.12.4.js",
                        "~/Scripts/kendo/jszip.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/chart").Include(
                     "~/Scripts/Chart.js"));

            bundles.Add(new ScriptBundle("~/bundles/custom").Include(
                     "~/Scripts/custom.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery/ui").Include(
                     "~/Scripts/jquery-ui-1.12.0.js"));

            bundles.Add(new ScriptBundle("~/bundles/kendo").Include(
                "~/Scripts/kendo/kendo.all.min.js",
                // "~/Scripts/kendo/kendo.timezones.min.js", // uncomment if using the Scheduler
                "~/Scripts/kendo/kendo.aspnetmvc.min.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/kendo/css").Include(
                "~/Content/kendo/kendo.common-bootstrap.min.css",
                "~/Content/kendo/kendo.bootstrap.min.css",
                "~/Content/kendo/kendo.common.min.css",
                "~/Content/kendo/kendo.default.min.css",
                "~/Content/kendo/kendo.default.mobile.min.css",
                "~/Content/kendo/kendo.common-material.min.css"));
        }
    }
}
