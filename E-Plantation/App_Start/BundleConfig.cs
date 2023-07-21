using System.Web;
using System.Web.Optimization;

namespace E_Plantation
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.UseCdn = true;

            bundles.Add(new StyleBundle("~/Content/css").Include(
                    "~/Content/bootstrap.min.css",
                    "~/Content/style.css",
                    "~/Content/quill.snow.css",
                    "~/Content/quill.bubble.css",
                    "~/Content/simple-datatables.css"
              ));

            bundles.Add(new StyleBundle("~/Content/cssFont").Include(
                      "~/Content/bootstrap-icons/bootstrap-icons.css",
                      "~/Content/boxicons/css/boxicons.min.css",
                      "~/Content/remixicon/remixicon.css"
                ));

            bundles.Add(new Bundle("~/bundles/jqueryBundle")
                  .Include("~/Scripts/bootstrap.bundle.min.js"));


            bundles.Add(new Bundle("~/bundles/jqueryMain")
                        .Include("~/Scripts/main.js"));

            bundles.Add(new StyleBundle("~/Content/cssdataTables", "https://cdn.datatables.net/1.13.2/css/jquery.dataTables.css"));

            bundles.Add(new StyleBundle("~/Content/cssselect2", "https://cdn.jsdelivr.net/npm/select2@4.1.0-rc.0/dist/css/select2.min.css"));

            bundles.Add(new StyleBundle("~/Content/cssfontawesome", "https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/fontawesome.min.css"));

            bundles.Add(new StyleBundle("~/Content/cssdatepicker", "https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.3.0/css/datepicker.css"));

            bundles.Add(new ScriptBundle("~/bundles/jsjquery", "https://code.jquery.com/jquery-3.5.0.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jsselect2", "https://cdn.jsdelivr.net/npm/select2@4.1.0-rc.0/dist/js/select2.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jsdatepicker", "https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.3.0/js/bootstrap-datepicker.js"));

            bundles.Add(new ScriptBundle("~/bundles/jssweetalert", "https://cdn.jsdelivr.net/npm/sweetalert2@11"));

        }
    }
}
