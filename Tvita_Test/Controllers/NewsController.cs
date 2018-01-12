using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tvita.BAL.Implement;

namespace Tvita_Test.Controllers
{
    public class NewsController : TvitaController
    {
        PostManager postManager = new PostManager();
        PictureManager pic = new PictureManager();
        // GET: News
        public ActionResult Index()
        {
            try
            {
                var res = postManager.GetHotNewPost();
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
                for(int i = 0; i < appearPic.Length; i++)
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
        public ActionResult GetRelatedNews(int id)
        {
            try
            {
                var res = postManager.GetRelatedPost(1, id).Take(3);
                foreach (var item in res)
                {
                    if (item.Post_Picture != null)
                    {
                        var appearPic = item.Post_Picture.Split(',').LastOrDefault();
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