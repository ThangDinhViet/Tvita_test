using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tvita.BAL.Implement;
using Tvita.Model.Table;

namespace Tvita_Test.Controllers
{
    public class EditorController : TvitaController
    {
        PostManager postManager = new PostManager();
        // GET: Admin/Editor
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SavePost(string contentPost)
        {
            try
            {
                PostModel post = new PostModel();
                post.Post_Content = contentPost;
                post.Post_Name = "Created auto at " + DateTime.Now;
                post.Post_DateCreated = DateTime.Now;
                postManager.AddPost(post);
                return Json(new { }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}