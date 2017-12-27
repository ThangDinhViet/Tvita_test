using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tvita_Test.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Fresh()
        {
            return View();
        }

        public ActionResult Processed()
        {
            return View();
        }

        public ActionResult Detail()
        {
            return View();
        }
    }
}