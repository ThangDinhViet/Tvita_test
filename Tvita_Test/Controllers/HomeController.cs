using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tvita.BAL.Implement;
using Tvita.BAL.Interface;

namespace Tvita_Test.Controllers
{
    public class HomeController : TvitaController
    {
        PostManager postManager = new PostManager();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Farm()
        {
            return View();
        }

        public ActionResult Value()
        {
            return View();
        }

        public ActionResult ChangeLanguage(string lang)
        {
            new LanguageMang().SetLanguage(lang);
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Contact()
        {
            return View();
        }


        public ActionResult getHotNews()
        {
            try
            {
                var res = postManager.GetListNewPost();
                return Json(new { data = res }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

