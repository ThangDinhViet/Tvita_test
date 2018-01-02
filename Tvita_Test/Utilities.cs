using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tvita_Test
{
    public class Utilities
    {
        public static bool menuIsActive(string controllerName, string actionName)
        {
            if (HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString() == controllerName &&
                HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString() == actionName)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string languageIsActive()
        {
            var userLanguage = HttpContext.Current.Request.Cookies["culture"];
            return userLanguage.Value;
        }

        public static string Translate(string key)
        {
            return Tvita.ResourceManager.GetString(key);
        }

        public static String RenderRazorViewToString(ControllerContext controllerContext, String viewName, Object model)
        {
            controllerContext.Controller.ViewData.Model = model;

            using (var sw = new StringWriter())
            {
                var ViewResult = ViewEngines.Engines.FindPartialView(controllerContext, viewName);
                var ViewContext = new ViewContext(controllerContext, ViewResult.View, controllerContext.Controller.ViewData, controllerContext.Controller.TempData, sw);
                ViewResult.View.Render(ViewContext, sw);
                ViewResult.ViewEngine.ReleaseView(controllerContext, ViewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }
    }
}