using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tvita.BAL.Implement;
using Tvita.BAL.Interface;
using Tvita.Model.Table;

namespace Tvita_Test.Areas.Admin.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeManager _employeeManager { get; set; }
        // GET: Admin/Employee
        public ActionResult Index()
        {
            _employeeManager = new EmployeeManager();
            var list = _employeeManager.GetAllEmployee();
            ViewBag.ListEmployee = list;
            return View();
        }

        // GET: Admin/Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Employee/Create
        [HttpPost]
        public JsonResult Create(EmployeeModel model)
        {
            try
            {
                _employeeManager = new EmployeeManager();
                _employeeManager.AddEmployee(model);
                return Json("Success", JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json("Eror", JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Admin/Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
