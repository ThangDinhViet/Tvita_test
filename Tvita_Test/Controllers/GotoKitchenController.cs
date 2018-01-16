using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tvita.BAL.Implement;
using Tvita_Test.Models;
using Tvita.Model.Table;

namespace Tvita_Test.Controllers
{
    public class GotoKitchenController : TvitaController
    {
        PostManager postManager = new PostManager();
        PictureManager pic = new PictureManager();
        // GET: GotoKitchen
        public ActionResult Index()
        {
            try
            {
                var res = postManager.GetKitchenNews();
                foreach (var item in res)
                {
                    if (item.Post_Picture != null)
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
                ViewBag.ListLastest = res.Take(3);
                return View(res);
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        public ActionResult Details(int id)
        {
            var news = postManager.GetPostByID(id);
            if (news.Post_Picture != null)
            {
                var appearPic = news.Post_Picture.Split(',');
                for (int i = 0; i < appearPic.Length; i++)
                {
                    var idPic = Convert.ToInt32(appearPic[i]);
                    var p = pic.GetPictureById(idPic);
                    if (p != null && i == 0)
                        news.Post_Pic_URL = p.Picture_Name;
                    else
                    {
                        news.Post_Pic_In_Content = p.Picture_Name;
                        news.Post_Pic_In_Content_Des = news.Post_Name;
                    }

                }
            }
            return View(news);
        }
        [HttpGet]
        public ActionResult GetRelatedKitchen(int id)
        {
            try
            {
                var res = postManager.GetRelatedPost(4,id).Take(3);
                foreach (var item in res)
                {
                    if (item.Post_Picture != null)
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

        [HttpGet]
        public ActionResult GetItems(LoadMoreParam _param)
        {
            try
            {
                var res = postManager.GetKitchenItems(_param);
                return Json(res, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}