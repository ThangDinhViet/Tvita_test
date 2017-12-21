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
    class ProductsInFarmRepository : Repository<tbl_ProductsInFarm, int>, IProductsInFarmRepository
    {
        private Repository<tbl_ProductsInFarm, int> _productsInFarmRepository;
        private DbSet<tbl_ProductsInFarm> _dbSet;
        private readonly Tvita_TestEntities _dbContext;
        public ProductsInFarmRepository(Tvita_TestEntities dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
            _productsInFarmRepository = new Repository<tbl_ProductsInFarm, int>(_dbContext);
            this._dbSet = _dbContext.Set<tbl_ProductsInFarm>();
        }
        public bool AddProductsInFarm(ProductsInFarmModel model)
        {
            tbl_ProductsInFarm productsInFarm = new tbl_ProductsInFarm();
            try
            {
                productsInFarm.ID_Product = model.ID_Product;
                productsInFarm.ID_ProductionUnit = model.ID_ProductionUnit;
                productsInFarm.IsDelete = false;
                productsInFarm.PIF_AveragePrice = model.PIF_AveragePrice;
                _dbContext.tbl_ProductsInFarm.Add(productsInFarm);
                Save();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool UpdateAverageById(int idPif, double average)
        {
            tbl_ProductsInFarm productsInFarm = new tbl_ProductsInFarm();
            try
            {
                productsInFarm = _dbContext.tbl_ProductsInFarm.Where(x => x.PIF_ID == idPif).First();
                productsInFarm.PIF_AveragePrice = average;
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
