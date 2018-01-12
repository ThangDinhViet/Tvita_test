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
        PictureManager pic = new PictureManager();
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


        [HttpGet]
        public ActionResult GetHotNews()
        {
            try
            {
                var res = postManager.GetHotNewPost().Take(5);
                return Json(new { data = res }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public ActionResult GetKitchenNews()
        {
            try
            {
                var res = postManager.GetKitchenNews().Take(3);
                foreach(var item in res)
                {
                    if(item.Post_Picture != null)
                    {
                        var appearPic = item.Post_Picture.Split(',').FirstOrDefault();
                        if (appearPic != null)
                        {
                            var idPic = Convert.ToInt32(appearPic);
                            var p = pic.GetPictureById(idPic);
                            if (p != null)
                                item.Post_Pic_URL = p.Picture_Name;
                        }
                    }
                    
                }
                
                return Json(new { data = res }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

