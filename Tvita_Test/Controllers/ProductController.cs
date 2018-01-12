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
            ViewBag.IDBranch = 1;
            return View();
        }

        public ActionResult Processed()
        {
            ViewBag.IDBranch = 2;
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
                if (res.Product_Picture != null)
                {
                    var appearPic = res.Product_Picture.Split(',').FirstOrDefault();
                    if (appearPic != null)
                    {
                        var idPic = Convert.ToInt32(appearPic);
                        var p = pic.GetPictureById(idPic);
                        if (p != null)
                            res.Product_Pic_URL = p.Picture_Name;
                    }
                    var lst = new List<string>();
                    foreach(var item in res.Product_Picture.Split(','))
                    {
                        var idPic = Convert.ToInt32(item);
                        var p = pic.GetPictureById(idPic);
                        if (p != null)
                            lst.Add(p.Picture_Name);
                    }
                    res.Product_Pic_List = lst;
                }
                return Json(new { data = res }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        [HttpGet]
        public ActionResult GetRelatedProducts(int idGroup, int idPr)
        {
            try
            {
                var res = productManager.GetRelatedProducts(idGroup, idPr);
                foreach (var item in res)
                {
                    if (item.Product_Picture != null)
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
                return Json(new { data = res }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}