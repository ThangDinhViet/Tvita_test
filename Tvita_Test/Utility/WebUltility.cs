using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Tvita_Test.Utility
{
    public static class WebUltility
    {
        public static readonly string WebUrl = ConfigurationManager.AppSettings["WebsiteUrl"];
    }
}