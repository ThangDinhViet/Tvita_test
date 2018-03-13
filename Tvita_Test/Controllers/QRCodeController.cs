using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tvita.BAL.Implement;
using Tvita.Model.Table;

namespace Tvita_Test.Controllers
{
    public class QRCodeController : TvitaController
    {
        // GET: QRCode
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            PUManager puManager = new PUManager();
            PictureManager pic = new PictureManager();
            PUModel pu = new PUModel();
            pu = puManager.GetPUByID(id);
            var appearPic = pu.PU_Image.Split(',');
            for (int i = 0; i < appearPic.Length; i++)
            {
                var idPic = Convert.ToInt32(appearPic[i]);
                var p = pic.GetPictureById(idPic);
                if (p != null && i == 0)
                    ViewBag.Post_Pic_URL_1 = p.Picture_Name;
                else if (p != null && i == 1)
                {
                    ViewBag.Post_Pic_URL_2 = p.Picture_Name;
                }
                else if (p != null && i == 2)
                {
                    ViewBag.Post_Pic_URL_3 = p.Picture_Name;
                }
                else if (p != null && i == 3)
                {
                    ViewBag.Post_Pic_URL_4 = p.Picture_Name;
                }
                else if (p != null && i == 4)
                {
                    ViewBag.Post_Pic_URL_5 = p.Picture_Name;
                }
            }
            return View(pu);
        }
    }
}