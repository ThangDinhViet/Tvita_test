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
        // GET: Product
        public ActionResult Fresh()
        {
            return View();
        }

        public ActionResult Processed()
        {
            return View();
        }

        public ActionResult Detail()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetProduct(LoadMoreParam _param)
        {
            try
            {
                ProductManager productManager = new ProductManager();
                List<ProductModel> result = new List<ProductModel>();
                int count = productManager.GetAllProduct().Count();
                result = productManager.GetAllProduct().Skip(_param.recordsDisplayed).Take(_param.recordsInPage).ToList();
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
    }
}