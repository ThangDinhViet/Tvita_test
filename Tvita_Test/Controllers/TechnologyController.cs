using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tvita.BAL.Implement;

namespace Tvita_Test.Controllers
{
    public class TechnologyController : TvitaController
    {
        PostManager postManager = new PostManager();
        // GET: Technology
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Details(int id)
        {
            ViewBag.id = id;
            return View("_iframe");
        }

        public ActionResult getContent(int id)
        {
            try
            {
                ViewBag.content = postManager.GetPostByID(id).Post_Content.ToString();
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}