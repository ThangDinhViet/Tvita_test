using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tvita_Test.Models;
using Tvita.BAL.Implement;
using Tvita.Model.Table;

namespace Tvita_Test.Controllers
{
    public class ProductController : TvitaController
    {
        ProductManager productManager = new ProductManager();
        PictureManager pic = new PictureManager();
        // GET: Product
        public ActionResult Fresh()
        {
            return View();
        }

        public ActionResult Processed()
        {
            return View();
        }

        public ActionResult Detail(int id)
        {
            ViewBag.productId = id;
            return View();
        }

        [HttpGet]
        public ActionResult GetProduct(LoadMoreParam _param)
        {
            try
            {
                List<ProductModel> result = new List<ProductModel>();
                int count = productManager.GetProductByBranch(_param.idBranch).Count();
                result = productManager.GetProductByBranch(_param.idBranch).Skip(_param.recordsDisplayed).Take(_param.recordsInPage).ToList();
                foreach(var item in result)
                {
                    if(item.Product_Picture != null)
                    {
                        var appearPic = item.Product_Picture.Split(',').FirstOrDefault();
                        if (appearPic != null)
                        {
                            var idPic = Convert.ToInt32(appearPic);
                            var p = pic.GetPictureById(idPic);
                            if (p != null)
                                item.Product_Pic_URL = p.Picture_Name;
                        }
                    }   
                }
                int displayed = _param.recordsDisplayed + result.Count();
                var res = new RespondResult();
                res.data = result;
                res.pageInfo = new LoadMoreParam() { recordsDisplayed = displayed, total = count, recordsInPage = _param.recordsInPage };
                return Json(res, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public ActionResult GetProductDetail(int id)
        {
            try
            {
                var res = productManager.GetProductByID(id);
                return Json(new { data = res }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpGet]
        public ActionResult GetRelatedProducts(int idGroup)
        {
            try
            {
                var res = productManager.GetRelatedProducts(idGroup);
                return Json(new { data = res }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}