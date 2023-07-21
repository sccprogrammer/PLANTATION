using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Plantation.App_Helpers
{
    public static class MenuHelper
    {
        public static string RouteIf(this HtmlHelper htmlHelper, string controller, string action)
        {
            string currentController = (string)htmlHelper.ViewContext.RouteData.Values["controller"];
            string currentAction = (string)htmlHelper.ViewContext.RouteData.Values["action"];

            return currentController == controller && currentAction == action ? "active" : "";
        }
    }
}