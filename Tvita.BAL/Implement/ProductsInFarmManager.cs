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
    public class ProductsInFarmManager : IProductsInFarmManager
    {
        public List<ProductsInFarmModel> GetAllProductsInFarm()
        {
            List<ProductsInFarmModel> result = new List<ProductsInFarmModel>();
            using (IUnitOfWork uOW = new UnitOfWork())
            {
                result = uOW.ProductsInFarmRepository.QueryAll().Select(x => new ProductsInFarmModel
                {
                    ID_Product = x.ID_Product,
                    ID_ProductionUnit = x.ID_ProductionUnit,
                    IsDelete = x.IsDelete,
                    PIF_AveragePrice = x.PIF_AveragePrice,
                    PIF_ID = x.PIF_ID
                }).ToList();
            }
            return result;
        }
        
        public bool AddProductsInFarm(ProductsInFarmModel model)
        {
            try
            {
                using (IUnitOfWork uOW = new UnitOfWork())
                {
                    var exist = uOW.ProductsInFarmRepository.GetWhere(x => x.ID_Product == model.ID_Product && x.ID_ProductionUnit == model.ID_ProductionUnit).FirstOrDefault();
                    if (exist == null)
                    {
                        uOW.IProductsInFarmRepository.AddProductsInFarm(model);
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
        public bool UpdateAverageById(int idPif, double average)
        {
            try
            {
                using (IUnitOfWork uOW = new UnitOfWork())
                {
                    var exist = uOW.ProductsInFarmRepository.GetWhere(x => x.PIF_ID == idPif).FirstOrDefault();
                    if (exist != null)
                    {
                        uOW.IProductsInFarmRepository.UpdateAverageById(idPif, average);
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
        public double GetAveragePrice(int idPr, int idPu)
        {
            try
            {
                using (IUnitOfWork uOW = new UnitOfWork())
                {
                    var pif = uOW.ProductsInFarmRepository.GetWhere(x => x.ID_Product == idPr && x.ID_ProductionUnit == idPu).FirstOrDefault();
                    if (pif != null)
                    {
                        return pif.PIF_AveragePrice.Value;
                    }
                    else
                        return 0;

                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
