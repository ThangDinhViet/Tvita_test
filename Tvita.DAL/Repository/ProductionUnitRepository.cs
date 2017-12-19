using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tvita.DAL.Common;
using Tvita.Model.Table;

namespace Tvita.DAL.Repository
{
    public class ProductionUnitRepository : Repository<tbl_ProductionUnit, int>, IProductionUnitRepository
    {
        private Repository<tbl_ProductionUnit, int> _productionUnitRepository;
        private DbSet<tbl_ProductionUnit> _dbSet;
        private readonly Tvita_TestEntities _dbContext;
        public ProductionUnitRepository(Tvita_TestEntities dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
            _productionUnitRepository = new Repository<tbl_ProductionUnit, int>(_dbContext);
            this._dbSet = _dbContext.Set<tbl_ProductionUnit>();
        }
        public bool AddProductionUnit(ProductionUnitModel model)
        {
            tbl_ProductionUnit productionUnit = new tbl_ProductionUnit();
            try
            {
                productionUnit.ID_Farm = model.ID_Farm;
                productionUnit.IsDelete = false;
                productionUnit.ProductionUnit_Address = model.ProductionUnit_Address;
                productionUnit.ProductionUnit_Area = model.ProductionUnit_Area;
                productionUnit.ProductionUnit_AveragePrice = model.ProductionUnit_AveragePrice;
                productionUnit.ProductionUnit_Capacity = model.ProductionUnit_Capacity;
                productionUnit.ProductionUnit_Code = model.ProductionUnit_Code;
                productionUnit.ProductionUnit_Contract = model.ProductionUnit_Contract;
                productionUnit.ProductionUnit_Distance = model.ProductionUnit_Distance;
                productionUnit.ProductionUnit_Info = model.ProductionUnit_Info;
                productionUnit.ProductionUnit_Name = model.ProductionUnit_Name;
                productionUnit.ProductionUnit_PreviousPrice = model.ProductionUnit_PreviousPrice;
                productionUnit.ProductionUnit_Price = model.ProductionUnit_Price;
                productionUnit.ProductionUnit_QualityStandard = model.ProductionUnit_QualityStandard;
                productionUnit.ProductionUnit_TransportFee = model.ProductionUnit_TransportFee;
                productionUnit.ProductionUnit_Unit = model.ProductionUnit_Unit;
                
                _dbContext.tbl_ProductionUnit.Add(productionUnit);
                Save();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
