using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace WeddingWebsite
{
    public static class MenuItemHelper
    {
        public static MvcHtmlString ListItemAction(this HtmlHelper helper, string name, string actionName)
        {
            var currentControllerName = (string)helper.ViewContext.RouteData.Values["controller"];
            var currentActionName = (string)helper.ViewContext.RouteData.Values["action"];

            var menuItem = new TagBuilder("li");
            var url = new UrlHelper(HttpContext.Current.Request.RequestContext);
            menuItem.InnerHtml = String.Format("<a href=\"{0}\"{2}>{1}</a>", url.Action(actionName), name, currentActionName == actionName ? " class=\"active\"" : "");
            return new MvcHtmlString(menuItem.ToString());
        }
    }
}