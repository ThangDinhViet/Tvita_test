using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tvita.BAL.Implement;
using Tvita_Test.Models;

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

        [HttpGet]
        public ActionResult getDetailsJson()
        {
            var model = new Common();
            model.content1 = "Text here";
            model.content2 = "Image here";
            model.content3 = "Image here";
            model.content4 = "Image here";
            var part1 = Utilities.RenderRazorViewToString(this.ControllerContext, "~/Views/Technology/templates/grid_2x2/_part1.cshtml", model);
            var part2 = Utilities.RenderRazorViewToString(this.ControllerContext, "~/Views/Technology/templates/grid_2x2/_part2.cshtml", model);
            var part3 = Utilities.RenderRazorViewToString(this.ControllerContext, "~/Views/Technology/templates/grid_2x2/_part3.cshtml", model);
            var part4 = Utilities.RenderRazorViewToString(this.ControllerContext, "~/Views/Technology/templates/grid_2x2/_part4.cshtml", model);
            var json = Json(new { part1, part2, part3, part4 });
            return Json(new { data = json }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getViewDetails()
        {
            var model = new Common();
            model.content1 = "Text here";
            model.content2 = "Image here";
            model.content3 = "Image here";
            model.content4 = "Image here";
            return View("~/Views/Technology/templates/template1.cshtml", model);
        }
    }
}