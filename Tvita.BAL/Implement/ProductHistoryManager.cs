using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tvita.BAL.Interface;
using Tvita.DAL.Common;
using Tvita.Model.Table;

namespace Tvita.BAL.Implement
{
    public class ProductHistoryManager : IProductHistoryManager
    {
        public List<ProductHistoryModel> GetAllProductHistory()
        {
            List<ProductHistoryModel> result = new List<ProductHistoryModel>();
            using (IUnitOfWork uOW = new UnitOfWork())
            {
                result = uOW.ProductHistoryRepository.QueryAll().Select(x => new ProductHistoryModel
                {
                    ID_Product = x.ID_Product,
                    ID_ProductionUnit = x.ID_ProductionUnit,
                    ProductHistory_Date = x.ProductHistory_Date,
                    ProductHistory_ID = x.ProductHistory_ID,
                    ProductHistory_Price = x.ProductHistory_Price,
                    IsDelete = x.IsDelete
                }).ToList();
            }
            return result;
        }
        public ProductHistoryModel GetProductHistoryByID(int id)
        {
            ProductHistoryModel result = new ProductHistoryModel();
            using (IUnitOfWork uOW = new UnitOfWork())
            {
                result = uOW.ProductHistoryRepository.GetWhere(x => x.ProductHistory_ID == id).Select(x => new ProductHistoryModel
                {
                    ID_Product = x.ID_Product,
                    ID_ProductionUnit = x.ID_ProductionUnit,
                    ProductHistory_Date = x.ProductHistory_Date,
                    ProductHistory_ID = x.ProductHistory_ID,
                    ProductHistory_Price = x.ProductHistory_Price,
                    IsDelete = x.IsDelete
                }).FirstOrDefault();
            }
            return result;
        }
        public List<ProductHistoryModel> GetProductHistoryByPIF(int idPr, int idPu)
        {
            List<ProductHistoryModel> result = new List<ProductHistoryModel>();
            using (IUnitOfWork uOW = new UnitOfWork())
            {
                result = uOW.ProductHistoryRepository.GetWhere(x => x.ID_Product == idPr && x.ID_ProductionUnit == idPu).Select(x => new ProductHistoryModel
                {
                    ID_Product = x.ID_Product,
                    ID_ProductionUnit = x.ID_ProductionUnit,
                    ProductHistory_Date = x.ProductHistory_Date,
                    ProductHistory_ID = x.ProductHistory_ID,
                    ProductHistory_Price = x.ProductHistory_Price,
                    IsDelete = x.IsDelete
                }).ToList();
            }
            return result;
        }
        public ProductHistoryModel GetProductHistoryByDate(DateTime date, int idPr, int idPu)
        {
            ProductHistoryModel result = new ProductHistoryModel();
            using (IUnitOfWork uOW = new UnitOfWork())
            {
                result = uOW.ProductHistoryRepository.GetWhere(x => x.ID_Product == idPr && x.ID_ProductionUnit == idPu && x.ProductHistory_Date == date).Select(x => new ProductHistoryModel
                {
                    ID_Product = x.ID_Product,
                    ID_ProductionUnit = x.ID_ProductionUnit,
                    ProductHistory_Date = x.ProductHistory_Date,
                    ProductHistory_ID = x.ProductHistory_ID,
                    ProductHistory_Price = x.ProductHistory_Price,
                    IsDelete = x.IsDelete
                }).FirstOrDefault();
            }
            return result;
        }
        public bool AddProductHistory(ProductHistoryModel model)
        {
            try
            {
                using (IUnitOfWork uOW = new UnitOfWork())
                {
                    var exist = uOW.ProductHistoryRepository.GetWhere(x => x.ProductHistory_Date == model.ProductHistory_Date && x.ID_Product == model.ID_Product && x.ID_ProductionUnit == model.ID_ProductionUnit).FirstOrDefault();
                    if (exist == null)
                    {
                        uOW.IProductHistoryRepository.AddProductHistory(model);
                        return true;
                    }
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
