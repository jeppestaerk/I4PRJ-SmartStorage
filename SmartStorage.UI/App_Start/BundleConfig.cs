﻿using System.Diagnostics.CodeAnalysis;
using System.Web.Optimization;

namespace SmartStorage.UI
{
  [ExcludeFromCodeCoverage]
  public class BundleConfig
  {
    public static void RegisterBundles(BundleCollection bundles)
    {
      bundles.Add(new StyleBundle("~/Content/css").Include(
          "~/Content/bootstrap.min.css",
          "~/Content/font-awesome.min.css",
          "~/Content/bootstrap-social.css",
          "~/Content/animate.min.css",
           "~/Content/wizardSteps/jquery.steps.css",
          "~/Content/DataTables/datatables.min.css",
          "~/Content/toastr/toastr.css",
          "~/Content/daterangepicker/daterangepicker.css",
          "~/Content/style.css",
          "~/Content/themes/base/*.css"

      ));

      bundles.Add(new ScriptBundle("~/bundles/script").Include(
          "~/Scripts/modernizr/modernizr-2.9.3.js",
          "~/Scripts/jquery/jquery-3.1.1.min.js",
          "~/Scripts/jquery-ui/jquery-ui-1.12.1.min.js",
          "~/Scripts/bootstrap/bootstrap.min.js",
          "~/Scripts/respond/respond.min.js",
          "~/Scripts/slimScroll/jquery.slimscroll.min.js",
          "~/Scripts/mentisMenu/metisMenu.min.js",
          "~/Scripts/toastr/toastr.min.js",
          "~/Scripts/bootbox/bootbox.min.js",
          "~/Scripts/wizardSteps/jquery.steps.js",
          "~/Content/DataTables/datatables.min.js",
          "~/Scripts/site/datatables/settingsDataTables.js",
          "~/Scripts/moment/moment.js",
          "~/Scripts/daterangepicker/daterangepicker.js",
          "~/Scripts/inspinia/inspinia.js"
      ));

      bundles.Add(new ScriptBundle("~/bundles/validate").Include(
          "~/Scripts/jqValidate/jquery.validate.min.js",
          "~/Scripts/jqValidate/jquery.validate.unobtrusive.min.js",
          "~/Scripts/site/jquery.validate.fix.js"
          ));
    }
  }
}