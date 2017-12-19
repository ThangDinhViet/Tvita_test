using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tvita.Model.ExcelModel;
using Tvita.Model.Table;

namespace Tvita_Test.Areas.Admin.Controllers
{
    public class FarmController : Controller
    {
        // GET: Admin/Farm
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Farm/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Farm/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Farm/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Farm/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Farm/Edit/5
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

        // GET: Admin/Farm/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Farm/Delete/5
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

        [HttpPost]
        public ActionResult Upload(FormCollection formCollection)
        {
            if (Request != null)
            {
                HttpPostedFileBase file = Request.Files["UploadedFile"];
                if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                {
                    string fileName = file.FileName;
                    string fileContentType = file.ContentType;
                    byte[] fileBytes = new byte[file.ContentLength];
                    var data = file.InputStream.Read(fileBytes, 0, Convert.ToInt32(file.ContentLength));
                    var productionUnitList = new List<ProductionUnitExcelModel>();
                    using (var package = new ExcelPackage(file.InputStream))
                    {
                        var currentSheet = package.Workbook.Worksheets;
                        var workSheet = currentSheet.First();
                        var noOfCol = workSheet.Dimension.End.Column;
                        var noOfRow = workSheet.Dimension.End.Row;
                        var dateView = workSheet.Cells[3, 3].Value.ToString();

                        List<ProductionUnitExcelModel> productExcelList = new List<ProductionUnitExcelModel>();

                        for (int rowIterator = 7; rowIterator <= noOfRow; rowIterator++)
                        {
                            var productionUnitExcel = new ProductionUnitExcelModel();
                            var product = new ProductModel();
                            var branch = new BranchModel();
                            var groupProduct = new GroupProductModel();
                            var farm = new FarmModel();
                            var productionUnit = new ProductionUnitModel();
                            var productHistory = new ProductHistoryModel();

                            productionUnitExcel.Branch_Code = workSheet.Cells[rowIterator, 2].Value.ToString();
                            branch.Branch_Code = productionUnitExcel.Branch_Code;

                            productionUnitExcel.Branch_Name = workSheet.Cells[rowIterator, 3].Value.ToString();
                            branch.Branch_Name = productionUnitExcel.Branch_Name;

                            productionUnitExcel.GroupProduct_Code = workSheet.Cells[rowIterator, 4].Value.ToString();
                            groupProduct.GroupProduct_Code = productionUnitExcel.GroupProduct_Code;

                            productionUnitExcel.GroupProduct_Name = workSheet.Cells[rowIterator, 5].Value.ToString();
                            groupProduct.GroupProduct_Name = productionUnitExcel.GroupProduct_Name;

                            productionUnitExcel.Product_Code = workSheet.Cells[rowIterator, 6].Value.ToString();
                            product.Product_Code = productionUnitExcel.Product_Code;

                            productionUnitExcel.Product_Name = workSheet.Cells[rowIterator, 7].Value.ToString();
                            product.Product_Name = productionUnitExcel.Product_Name;

                            productionUnitExcel.Farm_Code = workSheet.Cells[rowIterator, 8].Value.ToString();
                            farm.Farm_Code = productionUnitExcel.Farm_Code;

                            productionUnitExcel.Farm_Name = workSheet.Cells[rowIterator, 9].Value.ToString();
                            farm.Farm_Name = productionUnitExcel.Farm_Name;

                            productionUnitExcel.ProductionUnit_Code = workSheet.Cells[rowIterator, 10].Value.ToString();
                            productionUnit.ProductionUnit_Code = productionUnitExcel.ProductionUnit_Code;

                            productionUnitExcel.ProductionUnit_Name = workSheet.Cells[rowIterator, 11].Value.ToString();
                            productionUnit.ProductionUnit_Name = productionUnitExcel.ProductionUnit_Name;

                            productionUnitExcel.ProductionUnit_Info = workSheet.Cells[rowIterator, 12].Value.ToString();
                            productionUnit.ProductionUnit_Info = productionUnitExcel.ProductionUnit_Info;

                            productionUnitExcel.ProductionUnit_Area = Convert.ToDouble(workSheet.Cells[rowIterator, 13].Value);
                            productionUnit.ProductionUnit_Area = productionUnitExcel.ProductionUnit_Area;

                            productionUnitExcel.ProductionUnit_Capacity = workSheet.Cells[rowIterator, 14].Value.ToString();
                            productionUnit.ProductionUnit_Capacity = productionUnitExcel.ProductionUnit_Capacity;

                            productionUnitExcel.ProductionUnit_Address = workSheet.Cells[rowIterator, 15].Value.ToString();
                            productionUnit.ProductionUnit_Address = productionUnitExcel.ProductionUnit_Address;

                            productionUnitExcel.Farm_Address = workSheet.Cells[rowIterator, 16].Value.ToString();
                            farm.Farm_Address = productionUnitExcel.Farm_Address;

                            productionUnitExcel.Farm_Territory = workSheet.Cells[rowIterator, 17].Value.ToString();
                            farm.Farm_Territory = productionUnitExcel.Farm_Territory;

                            productionUnitExcel.ProductionUnit_QualityStandard = workSheet.Cells[rowIterator, 18].Value.ToString();
                            productionUnit.ProductionUnit_QualityStandard = productionUnitExcel.ProductionUnit_QualityStandard;

                            productionUnitExcel.ProductionUnit_Unit = workSheet.Cells[rowIterator, 19].Value.ToString();
                            productionUnit.ProductionUnit_Unit = productionUnitExcel.ProductionUnit_Unit;

                            //productionUnitExcel.ProductionUnit_PreviousPrice = Convert.ToDouble(workSheet.Cells[rowIterator, 20].Value);
                            //productionUnit.ProductionUnit_PreviousPrice = productionUnitExcel.ProductionUnit_PreviousPrice;

                            productionUnitExcel.ProductHistory_Price = Convert.ToDouble(workSheet.Cells[rowIterator, 21].Value);
                            productHistory.ProductHistory_Price = productionUnitExcel.ProductHistory_Price;

                            productionUnitExcel.ProductHistory_Date = Convert.ToDateTime(dateView);
                            productHistory.ProductHistory_Date = productionUnitExcel.ProductHistory_Date;

                            productExcelList.Add(productionUnitExcel);
                        }
                        ViewBag.ProductExcelList = productExcelList;
                    }
                    file.SaveAs(Server.MapPath(@"~\Upload\" + file.FileName));
                }
            }
            return View();
        }
    }
}
