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
    public class ProductionUnitManager : IProductionUnitManager
    {
        public List<ProductionUnitModel> GetAllProductionUnit()
        {
            List<ProductionUnitModel> result = new List<ProductionUnitModel>();
            using (IUnitOfWork uOW = new UnitOfWork())
            {
                result = uOW.ProductionUnitRepository.QueryAll().Select(x => new ProductionUnitModel
                {
                    ProductionUnit_Address = x.ProductionUnit_Address,
                    ProductionUnit_Area = x.ProductionUnit_Area,
                    ProductionUnit_AveragePrice = x.ProductionUnit_AveragePrice,
                    ProductionUnit_Capacity = x.ProductionUnit_Capacity,
                    ProductionUnit_Code = x.ProductionUnit_Code,
                    ProductionUnit_Contract = x.ProductionUnit_Contract,
                    ProductionUnit_Distance = x.ProductionUnit_Distance,
                    ProductionUnit_Info = x.ProductionUnit_Info,
                    ProductionUnit_Name = x.ProductionUnit_Name,
                    ProductionUnit_PreviousPrice = x.ProductionUnit_PreviousPrice,
                    ProductionUnit_ID = x.ProductionUnit_ID,
                    ProductionUnit_Price = x.ProductionUnit_Price,
                    ProductionUnit_QualityStandard = x.ProductionUnit_QualityStandard,
                    ProductionUnit_TransportFee = x.ProductionUnit_TransportFee,
                    ProductionUnit_Unit = x.ProductionUnit_Unit,
                    ID_Farm = x.ID_Farm,
                    IsDelete = x.IsDelete
                }).ToList();
            }
            return result;
        }
        public ProductionUnitModel GetProductionUnitByCode(string code)
        {
            ProductionUnitModel result = new ProductionUnitModel();
            using (IUnitOfWork uOW = new UnitOfWork())
            {
                result = uOW.ProductionUnitRepository.GetWhere(x => x.ProductionUnit_Code == code).Select(x => new ProductionUnitModel
                {
                    ProductionUnit_Address = x.ProductionUnit_Address,
                    ProductionUnit_Area = x.ProductionUnit_Area,
                    ProductionUnit_AveragePrice = x.ProductionUnit_AveragePrice,
                    ProductionUnit_Capacity = x.ProductionUnit_Capacity,
                    ProductionUnit_Code = x.ProductionUnit_Code,
                    ProductionUnit_Contract = x.ProductionUnit_Contract,
                    ProductionUnit_Distance = x.ProductionUnit_Distance,
                    ProductionUnit_Info = x.ProductionUnit_Info,
                    ProductionUnit_Name = x.ProductionUnit_Name,
                    ProductionUnit_PreviousPrice = x.ProductionUnit_PreviousPrice,
                    ProductionUnit_ID = x.ProductionUnit_ID,
                    ProductionUnit_Price = x.ProductionUnit_Price,
                    ProductionUnit_QualityStandard = x.ProductionUnit_QualityStandard,
                    ProductionUnit_TransportFee = x.ProductionUnit_TransportFee,
                    ProductionUnit_Unit = x.ProductionUnit_Unit,
                    ID_Farm = x.ID_Farm,
                    IsDelete = x.IsDelete
                }).FirstOrDefault();
            }
            return result;
        }
        public bool AddProductionUnit(ProductionUnitModel model)
        {
            try
            {
                using (IUnitOfWork uOW = new UnitOfWork())
                {
                    var exist = uOW.ProductionUnitRepository.GetWhere(x => x.ProductionUnit_Code == model.ProductionUnit_Code).FirstOrDefault();
                    if (exist == null)
                    {
                        uOW.IProductionUnitRepository.AddProductionUnit(model);
                        return true;
                    }
                    else return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
