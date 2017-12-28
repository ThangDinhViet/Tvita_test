using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tvita_Test.Controllers
{
    public class CommunityDevelopmentController : TvitaController
    {
        // GET: CommunityDevelopment
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details()
        {
            return View("_details");
        }
    }
}