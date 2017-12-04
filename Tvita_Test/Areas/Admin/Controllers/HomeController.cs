using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tvita.BAL.Implement;
using Tvita.BAL.Interface;

namespace Tvita_Test.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private IEmployeeManager _employeeManager { get; set; }
        // GET: Admin/Home
        public ActionResult Index()
        {
           
            return View();
        }
    }
}