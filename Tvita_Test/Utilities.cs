using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
            return "VI";
        }
    }
}