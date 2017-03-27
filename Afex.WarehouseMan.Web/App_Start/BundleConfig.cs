using System.Web.Optimization;

namespace SampleLTE.Web
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();

            //VENDOR RESOURCES

            //~/Bundles/App/vendor/css
            bundles.Add(
                new StyleBundle("~/Bundles/App/vendor/css")
                    .Include("~/Content/themes/base/all.css", new CssRewriteUrlTransform())
                    .Include("~/Content/bootstrap-cosmo.min.css", new CssRewriteUrlTransform())
                    .Include("~/Content/toastr.min.css", new CssRewriteUrlTransform())
                    .Include("~/Scripts/sweetalert/sweet-alert.css", new CssRewriteUrlTransform())
                    .Include("~/Content/flags/famfamfam-flags.css", new CssRewriteUrlTransform())
                    .Include("~/Content/font-awesome.min.css", new CssRewriteUrlTransform())
                );

            //~/Bundles/App/vendor/js
            bundles.Add(
                new ScriptBundle("~/Bundles/App/vendor/js")
                    .Include(
                        "~/Abp/Framework/scripts/utils/ie10fix.js",
                        "~/Scripts/json2.min.js",

                        "~/Scripts/modernizr-2.8.3.js",
                        
                        //"~/Scripts/jquery-2.2.0.min.js",
                        //"~/Scripts/jquery-ui-1.11.4.min.js",

                        //"~/Scripts/bootstrap.min.js",

                        "~/Scripts/moment-with-locales.min.js",
                        //"~/Scripts/jquery.validate.min.js",
                        "~/Scripts/jquery.blockUI.js",
                        "~/Scripts/toastr.min.js",
                        "~/Scripts/sweetalert/sweet-alert.min.js",
                        "~/Scripts/others/spinjs/spin.js",
                        "~/Scripts/others/spinjs/jquery.spin.js",

                        "~/Scripts/angular.min.js",
                        "~/Scripts/angular-animate.min.js",
                        "~/Scripts/angular-sanitize.min.js",
                        "~/Scripts/angular-ui-router.min.js",
                        "~/Scripts/angular-ui/ui-bootstrap.min.js",
                        "~/Scripts/angular-ui/ui-bootstrap-tpls.min.js",
                        "~/Scripts/angular-ui/ui-utils.min.js",

                        "~/Abp/Framework/scripts/abp.js",
                        "~/Abp/Framework/scripts/libs/abp.jquery.js",
                        "~/Abp/Framework/scripts/libs/abp.toastr.js",
                        "~/Abp/Framework/scripts/libs/abp.blockUI.js",
                        "~/Abp/Framework/scripts/libs/abp.spin.js",
                        "~/Abp/Framework/scripts/libs/abp.sweet-alert.js",
                        "~/Abp/Framework/scripts/libs/angularjs/abp.ng.js",

                        "~/Scripts/jquery.signalR-2.2.1.min.js"
                    )
                );

            //APPLICATION RESOURCES

            //~/Bundles/App/Main/css
            bundles.Add(
                new StyleBundle("~/Bundles/App/Main/css")
                    .IncludeDirectory("~/App/Main", "*.css", true)
                );

            //~/Bundles/App/Main/js
            bundles.Add(
                new ScriptBundle("~/Bundles/App/Main/js")
                    .IncludeDirectory("~/Common/Scripts", "*.js", true)
                    .IncludeDirectory("~/App/Main", "*.js", true)
                );

            //LTE APPLICATION RESOURCES

            bundles.Add(new ScriptBundle("~/AdminLTE/bootstrap/js").Include(
                "~/AdminLTE/bootstrap/js/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/AdminLTE/dist/js").Include(
                "~/AdminLTE/dist/js/app.js"));

            bundles.Add(new ScriptBundle("~/AdminLTE/documentation/js").Include(
                "~/AdminLTE/documentation/js/docs.js"));

            // plugins | bootstrap-slider
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/bootstrap-slider/js").Include(
                                        "~/AdminLTE/plugins/bootstrap-slider/js/bootstrap-slider.js"));

            // plugins | bootstrap-wysihtml5
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/bootstrap-wysihtml5/js").Include(
                                         "~/AdminLTE/plugins/bootstrap-wysihtml5/js/bootstrap3-wysihtml5.all.min.js"));

            // plugins | chartjs
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/chartjs/js").Include(
                                         "~/AdminLTE/plugins/chartjs/js/chart.min.js"));

            // plugins | ckeditor
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/ckeditor/js").Include(
                                         "~/AdminLTE/plugins/ckeditor/js/ckeditor.js"));

            // plugins | colorpicker
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/colorpicker/js").Include(
                                         "~/AdminLTE/plugins/colorpicker/js/bootstrap-colorpicker.min.js"));

            // plugins | datatables
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/datatables/js").Include(
                                         "~/AdminLTE/plugins/datatables/js/jquery.dataTables.min.js",
                                         "~/AdminLTE/plugins/datatables/js/dataTables.bootstrap.min.js"));

            // plugins | datepicker
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/datepicker/js").Include(
                                         "~/AdminLTE/plugins/datepicker/js/bootstrap-datepicker.js",
                                         "~/AdminLTE/plugins/datepicker/js/locales/bootstrap-datepicker*"));

            // plugins | daterangepicker
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/daterangepicker/js").Include(
                                         "~/AdminLTE/plugins/daterangepicker/js/moment.min.js",
                                         "~/AdminLTE/plugins/daterangepicker/js/daterangepicker.js"));

            // plugins | fastclick
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/fastclick/js").Include(
                                         "~/AdminLTE/plugins/fastclick/js/fastclick.min.js"));

            // plugins | flot
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/flot/js").Include(
                                         "~/AdminLTE/plugins/flot/js/jquery.flot.min.js",
                                         "~/AdminLTE/plugins/flot/js/jquery.flot.resize.min.js",
                                         "~/AdminLTE/plugins/flot/js/jquery.flot.pie.min.js",
                                         "~/AdminLTE/plugins/flot/js/jquery.flot.categories.min.js"));

            // plugins | fullcalendar
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/fullcalendar/js").Include(
                                         "~/AdminLTE/plugins/fullcalendar/js/fullcalendar.min.js"));

            // plugins | icheck
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/icheck/js").Include(
                                         "~/AdminLTE/plugins/icheck/js/icheck.min.js"));

            // plugins | input-mask
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/input-mask/js").Include(
                                         "~/AdminLTE/plugins/input-mask/js/jquery.inputmask.js",
                                         "~/AdminLTE/plugins/input-mask/js/jquery.inputmask.date.extensions.js",
                                         "~/AdminLTE/plugins/input-mask/js/jquery.inputmask.extensions.js"));

            // plugins | ionslider
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/ionslider/js").Include(
                                         "~/AdminLTE/plugins/ionslider/js/ion.rangeSlider.min.js"));

            // plugins | jquery
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/jquery/js").Include(
                                         "~/AdminLTE/plugins/jquery/js/jQuery-2.1.4.min.js"));

            // plugins | jquery-validate
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/jquery-validate/js").Include(
                                         "~/AdminLTE/plugins/jquery-validate/js/jquery.validate*"));

            // plugins | jquery-ui
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/jquery-ui/js").Include(
                                         "~/AdminLTE/plugins/jquery-ui/js/jquery-ui.min.js"));

            // plugins | jvectormap
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/jvectormap/js").Include(
                                         "~/AdminLTE/plugins/jvectormap/js/jquery-jvectormap-1.2.2.min.js",
                                         "~/AdminLTE/plugins/jvectormap/js/jquery-jvectormap-world-mill-en.js"));

            // plugins | knob
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/knob/js").Include(
                                         "~/AdminLTE/plugins/knob/js/jquery.knob.js"));

            // plugins | momentjs
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/momentjs/js").Include(
                                         "~/AdminLTE/plugins/momentjs/js/moment.min.js"));

            // plugins | slimscroll
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/slimscroll/js").Include(
                                         "~/AdminLTE/plugins/slimscroll/js/jquery.slimscroll.min.js"));

            // plugins | timepicker
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/timepicker/js").Include(
                                         "~/AdminLTE/plugins/timepicker/js/bootstrap-timepicker.min.js"));

            // plugins | raphael
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/raphael/js").Include(
                                         "~/AdminLTE/plugins/raphael/js/raphael-min.js"));

            // plugins | select2
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/select2/js").Include(
                                         "~/AdminLTE/plugins/select2/js/select2.full.min.js"));

            // plugins | morris
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/morris/js").Include(
                                         "~/AdminLTE/plugins/morris/js/morris.min.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Shared/_Layout").Include(
                "~/Scripts/Shared/_Layout.js"));

            //bundles.Add(new ScriptBundle("~/Bundles/App/AdminLTE/js")
            //    .Include("~/AdminLTE/documentation/js/docs.js",
            //    "~/AdminLTE/plugins/bootstrap-slider/js/bootstrap-slider.js", "~/AdminLTE/plugins/bootstrap-wysihtml5/js/bootstrap3-wysihtml5.all.min.js",
            //    "~/AdminLTE/plugins/chartjs/js/chart.min.js", "~/AdminLTE/plugins/ckeditor/js/ckeditor.js",
            //    "~/AdminLTE/plugins/colorpicker/js/bootstrap-colorpicker.min.js", "~/AdminLTE/plugins/datatables/js/jquery.dataTables.min.js",
            //    "~/AdminLTE/plugins/datatables/js/dataTables.bootstrap.min.js", "~/AdminLTE/plugins/datepicker/js/bootstrap-datepicker.js",
            //    "~/AdminLTE/plugins/datepicker/js/locales/bootstrap-datepicker*", "~/AdminLTE/plugins/daterangepicker/js/moment.min.js",
            //    "~/AdminLTE/plugins/daterangepicker/js/daterangepicker.js", 
            //    "~/AdminLTE/plugins/flot/js/jquery.flot.min.js", "~/AdminLTE/plugins/flot/js/jquery.flot.resize.min.js",
            //    "~/AdminLTE/plugins/flot/js/jquery.flot.pie.min.js", "~/AdminLTE/plugins/flot/js/jquery.flot.categories.min.js",
            //    "~/AdminLTE/plugins/fullcalendar/js/fullcalendar.min.js", "~/AdminLTE/plugins/icheck/js/icheck.min.js",
            //    "~/AdminLTE/plugins/input-mask/js/jquery.inputmask.js", "~/AdminLTE/plugins/input-mask/js/jquery.inputmask.date.extensions.js",
            //    "~/AdminLTE/plugins/input-mask/js/jquery.inputmask.extensions.js", "~/AdminLTE/plugins/ionslider/js/ion.rangeSlider.min.js",
            //    "~/AdminLTE/plugins/jvectormap/js/jquery-jvectormap-1.2.2.min.js", "~/AdminLTE/plugins/jvectormap/js/jquery-jvectormap-world-mill-en.js",
            //    "~/AdminLTE/plugins/knob/js/jquery.knob.js", 
            //    "~/AdminLTE/plugins/sparkline/js/jquery.sparkline.min.js",
            //    "~/AdminLTE/plugins/timepicker/js/bootstrap-timepicker.min.js", "~/AdminLTE/plugins/timepicker/css/bootstrap-timepicker.min.css",
            //    "~/AdminLTE/plugins/raphael/js/raphael-min.js", "~/AdminLTE/plugins/select2/js/select2.full.min.js",
            //    "~/AdminLTE/plugins/morris/js/morris.min.js", "~/Scripts/Tables/Data.js",
            //    "~/Scripts/Tables/Simple-menu.js", "~/Scripts/Tables/Data-menu.js"
            //    ));

            bundles.Add(new StyleBundle("~/Bundles/App/AdminLTE/css")
                .Include("~/AdminLTE/bootstrap/css/bootstrap.min.css", "~/AdminLTE/dist/css/admin-lte.min.css",
                "~/AdminLTE/dist/css/skins/_all-skins.min.css", "~/AdminLTE/documentation/css/style.css",
                "~/AdminLTE/plugins/bootstrap-slider/css/slider.css", "~/AdminLTE/plugins/bootstrap-wysihtml5/css/bootstrap3-wysihtml5.min.css",
                "~/AdminLTE/plugins/colorpicker/css/bootstrap-colorpicker.css", "~/AdminLTE/plugins/datatables/css/dataTables.bootstrap.css",
                "~/AdminLTE/plugins/datepicker/css/datepicker3.css", "~/AdminLTE/plugins/daterangepicker/css/daterangepicker-bs3.css",
                "~/AdminLTE/plugins/fullcalendar/css/fullcalendar.min.css", "~/AdminLTE/plugins/fullcalendar/css/print/fullcalendar.print.css",
                "~/AdminLTE/plugins/icheck/css/all.css", "~/AdminLTE/plugins/icheck/css/flat/flat.css", "~/AdminLTE/plugins/icheck/css/sqare/blue.css",
                "~/AdminLTE/plugins/ionicons/css/ionicons.min.css", "~/AdminLTE/plugins/ionslider/css/ion.rangeSlider.css",
                "~/AdminLTE/plugins/ionslider/css/ion.rangeSlider.skinNice.css", "~/AdminLTE/plugins/jvectormap/css/jquery-jvectormap-1.2.2.css",
                "~/AdminLTE/plugins/morris/css/morris.css", "~/AdminLTE/plugins/pace/css/pace.min.css"
                , "~/AdminLTE/plugins/timepicker/css/bootstrap-timepicker.min.css", "~/AdminLTE/plugins/select2/css/select2.min.css"));
        }
    }
}