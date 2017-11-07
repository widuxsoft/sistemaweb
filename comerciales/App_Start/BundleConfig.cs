﻿using System.Web;
using System.Web.Optimization;

namespace comerciales
{
    public class BundleConfig
    {
        // Para obtener más información sobre Bundles, visite http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // preparado para la producción y podrá utilizar la herramienta de compilación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
            

            bundles.Add(new ScriptBundle("~/bundles/templatescript").Include(
                      "~/Scripts/app.js",
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/custom.js"));

            bundles.Add(new StyleBundle("~/Content/templatecss").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/essentials.css",
                      "~/Content/layout.css",
                      "~/Content/layout-datatables.css",
                      "~/Content/layout-footable-minimal.css",
                      "~/Content/layout-jqgrid.css",
                      "~/Content/layout-nestable.css",
                      "~/Content/layout-RTL.css",
                      "~/Content/color_scheme/green.css",
                      "~/Content/site.css"));
        }
    }
}
