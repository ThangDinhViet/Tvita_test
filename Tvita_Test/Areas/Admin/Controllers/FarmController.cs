using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tvita.BAL.Implement;
using Tvita.Model.ExcelModel;
using Tvita.Model.Table;

namespace Tvita_Test.Areas.Admin.Controllers
{
    public class FarmController : Controller
    {
        // GET: Admin/Farm
        public ActionResult Index()
        {
            var productExcelList = new List<ProductionUnitExcelModel>();
            BranchManager branchManager = new BranchManager();
            GroupProductManager groupProductManager = new GroupProductManager();
            ProductManager productManager = new ProductManager();
            FarmManager farmManager = new FarmManager();
            ProductionUnitManager productionUnitManager = new ProductionUnitManager();
            ProductHistoryManager productHistoryManager = new ProductHistoryManager();
            ProductsInFarmManager pifManager = new ProductsInFarmManager();

            var lst = productHistoryManager.GetAllProductHistory();
            foreach (var item in lst)
            {
                ProductionUnitExcelModel pue = new ProductionUnitExcelModel();
                pue.ID = item.ProductHistory_ID;
                var pr = productManager.GetProductByID(item.ID_Product.Value);
                if (pr != null)
                {
                    pue.Product_Code = pr.Product_Code;
                    pue.Product_Name = pr.Product_Name;
                }
                var pu = productionUnitManager.GetProductionUnitByID(item.ID_ProductionUnit.Value);
                if (pu != null)
                {
                    pue.ProductionUnit_Name = pu.ProductionUnit_Name;
                    var fr = farmManager.GetFarmByID(pu.ID_Farm.Value);
                    pue.Farm_Name = fr.Farm_Name;
                }
                pue.ProductHistory_Date = item.ProductHistory_Date.Value;
                var nearestDate = pue.ProductHistory_Date.AddDays(-7);
                pue.ProductsInFarm_AveragePrice = pifManager.GetAveragePrice(pr.Product_ID, pu.ProductionUnit_ID);
                pue.ProductHistory_Price = item.ProductHistory_Price;
                var nearest = productHistoryManager.GetProductHistoryByDate(nearestDate, pr.Product_ID, pu.ProductionUnit_ID);
                if (nearest != null)
                    pue.ProductionUnit_PreviousPrice = nearest.ProductHistory_Price;
                else
                    pue.ProductionUnit_PreviousPrice = 0;
                productExcelList.Add(pue);
            }
            ViewBag.ProductExcelList = productExcelList;
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
                    BranchManager branchManager = new BranchManager();
                    GroupProductManager groupProductManager = new GroupProductManager();
                    ProductManager productManager = new ProductManager();
                    FarmManager farmManager = new FarmManager();
                    ProductionUnitManager productionUnitManager = new ProductionUnitManager();
                    ProductHistoryManager productHistoryManager = new ProductHistoryManager();
                    ProductsInFarmManager pifManager = new ProductsInFarmManager();

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
                            var pif = new ProductsInFarmModel();

                            productionUnitExcel.Branch_Code = workSheet.Cells[rowIterator, 2].Value.ToString();
                            branch.Branch_Code = productionUnitExcel.Branch_Code;

                            productionUnitExcel.Branch_Name = workSheet.Cells[rowIterator, 3].Value.ToString();
                            branch.Branch_Name = productionUnitExcel.Branch_Name;

                            //branchManager.AddBranch(branch);

                            productionUnitExcel.GroupProduct_Code = workSheet.Cells[rowIterator, 4].Value.ToString();
                            groupProduct.GroupProduct_Code = productionUnitExcel.GroupProduct_Code;

                            productionUnitExcel.GroupProduct_Name = workSheet.Cells[rowIterator, 5].Value.ToString();
                            groupProduct.GroupProduct_Name = productionUnitExcel.GroupProduct_Name;

                            var br = branchManager.GetBranchByCode(productionUnitExcel.Branch_Code);
                            if (br != null)
                                groupProduct.ID_Branch = br.Branch_ID;
                            groupProductManager.AddGroupProduct(groupProduct);

                            productionUnitExcel.Product_Code = workSheet.Cells[rowIterator, 6].Value.ToString();
                            product.Product_Code = productionUnitExcel.Product_Code;

                            productionUnitExcel.Product_Name = workSheet.Cells[rowIterator, 7].Value.ToString();
                            product.Product_Name = productionUnitExcel.Product_Name;

                            var gr = groupProductManager.GetGroupProductByCode(productionUnitExcel.GroupProduct_Code);
                            if (gr != null)
                                product.ID_GroupProduct = gr.GroupProduct_ID;
                            productManager.AddProduct(product);

                            productionUnitExcel.Farm_Code = workSheet.Cells[rowIterator, 8].Value.ToString();
                            farm.Farm_Code = productionUnitExcel.Farm_Code;

                            productionUnitExcel.Farm_Name = workSheet.Cells[rowIterator, 9].Value.ToString();
                            farm.Farm_Name = productionUnitExcel.Farm_Name;

                            productionUnitExcel.Farm_Address = workSheet.Cells[rowIterator, 16].Value.ToString();
                            farm.Farm_Address = productionUnitExcel.Farm_Address;

                            productionUnitExcel.Farm_Territory = workSheet.Cells[rowIterator, 17].Value.ToString();
                            farm.Farm_Territory = productionUnitExcel.Farm_Territory;

                            farmManager.AddFarm(farm);

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


                            productionUnitExcel.ProductionUnit_QualityStandard = workSheet.Cells[rowIterator, 18].Value.ToString();
                            productionUnit.ProductionUnit_QualityStandard = productionUnitExcel.ProductionUnit_QualityStandard;

                            productionUnitExcel.ProductionUnit_Unit = workSheet.Cells[rowIterator, 19].Value.ToString();
                            productionUnit.ProductionUnit_Unit = productionUnitExcel.ProductionUnit_Unit;

                            var fr = farmManager.GetFarmByCode(productionUnitExcel.Farm_Code);
                            if (fr != null)
                                productionUnit.ID_Farm = fr.Farm_ID;
                            productionUnitManager.AddProductionUnit(productionUnit);

                            productionUnitExcel.ProductHistory_Price = Convert.ToDouble(workSheet.Cells[rowIterator, 21].Value);
                            productHistory.ProductHistory_Price = productionUnitExcel.ProductHistory_Price;

                            productionUnitExcel.ProductHistory_Date = Convert.ToDateTime(dateView);
                            productHistory.ProductHistory_Date = productionUnitExcel.ProductHistory_Date;

                            var pu = productionUnitManager.GetProductionUnitByCode(productionUnitExcel.ProductionUnit_Code);
                            if (pu != null)
                            {
                                productHistory.ID_ProductionUnit = pu.ProductionUnit_ID;
                                pif.ID_ProductionUnit = pu.ProductionUnit_ID;
                            }
                            var pr = productManager.GetProductByCode(productionUnitExcel.Product_Code);
                            if (pr != null)
                            {
                                productHistory.ID_Product = pr.Product_ID;
                                pif.ID_Product = pr.Product_ID;
                            }
                            productHistoryManager.AddProductHistory(productHistory);
                            pifManager.AddProductsInFarm(pif);
                            productExcelList.Add(productionUnitExcel);
                        }
                        ViewBag.ProductExcelList = productExcelList;
                    }
                    file.SaveAs(Server.MapPath(@"~\Upload\" + file.FileName));

                    var lstPif = pifManager.GetAllProductsInFarm();
                    foreach(var item in lstPif)
                    {
                        var lstPrHistory = productHistoryManager.GetProductHistoryByPIF(item.ID_Product.Value, item.ID_ProductionUnit.Value);
                        var averagePrice = lstPrHistory.Average(x => x.ProductHistory_Price).Value;
                        pifManager.UpdateAverageById(item.PIF_ID, averagePrice);
                    }
                }
            }
            //return View();
            return RedirectToAction("Index");
        }
    }
}
