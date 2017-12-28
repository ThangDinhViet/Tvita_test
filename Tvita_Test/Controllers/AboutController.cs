using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tvita_Test.Controllers
{
    public class AboutController : TvitaController
    {
        // GET: About
        public ActionResult History()
        {
            return View();
        }
        public ActionResult VisionAndMission()
        {
            return View();
        }
        public ActionResult Quality()
        {
            return View();
        }
    }
}