using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Bakey.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {                    

            bundles.Add(new ScriptBundle("~/js")
                .Include("~/Scripts/jquery-3.1.0.min.js", 
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/ModalPopupAuth.js"));


            bundles.Add(new StyleBundle("~/css")
               .Include("~/Content/bootstrap.min.css",
               "~/Content/MyStyle.css"));


            bundles.Add(new ScriptBundle("~/webApi")
                .Include("~/Scripts/jQuery.tmpl.min.js",
                "~/Scripts/WebApi.js"));
        }


    }
}