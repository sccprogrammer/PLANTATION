
using System;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Microsoft.Ajax.Utilities;

namespace E_Plantation.App_Helpers
{
    public static class HelperMenuExtensions
    {
        public static IHtmlString IsMenuActive(this HtmlHelper htmlHelper, string controller, string action)
        {
            string currentController = (string)htmlHelper.ViewContext.RouteData.Values["controller"];
            string currentAction = (string)htmlHelper.ViewContext.RouteData.Values["action"];

            var hasController = controller.Equals(currentController, StringComparison.InvariantCultureIgnoreCase);
            var hasAction = controller.Equals(currentAction, StringComparison.InvariantCultureIgnoreCase);

            return hasAction || hasController ? new HtmlString(action) : new HtmlString(string.Empty);
        }
    }
}