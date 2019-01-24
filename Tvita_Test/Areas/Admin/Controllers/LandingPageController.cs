using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tvita.BAL.Implement;
using Tvita.BAL.Interface;

namespace Tvita_Test.Areas.Admin.Controllers
{
    public class LandingPageController : Controller
    {
        private OrderLandingPageManager _orderLandingPageManager { get; set; }
        // GET: Admin/LandingPage
        public ActionResult Index()
        {
            _orderLandingPageManager = new OrderLandingPageManager();
            var list = _orderLandingPageManager.GetAll();
            ViewBag.ListOrder = list;
            return View();
        }
    }
}