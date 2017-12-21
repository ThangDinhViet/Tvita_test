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
    class ProductHistoryRepository : Repository<tbl_ProductHistory, int>, IProductHistoryRepository
    {
        private Repository<tbl_ProductHistory, int> _productHistoryRepository;
        private DbSet<tbl_ProductHistory> _dbSet;
        private readonly Tvita_TestEntities _dbContext;
        public ProductHistoryRepository(Tvita_TestEntities dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
            _productHistoryRepository = new Repository<tbl_ProductHistory, int>(_dbContext);
            this._dbSet = _dbContext.Set<tbl_ProductHistory>();
        }
        public bool AddProductHistory(ProductHistoryModel model)
        {
            tbl_ProductHistory productHistory = new tbl_ProductHistory();
            try
            {
                productHistory.ID_Product = model.ID_Product;
                productHistory.ID_ProductionUnit = model.ID_ProductionUnit;
                productHistory.IsDelete = false;
                productHistory.ProductHistory_Date = model.ProductHistory_Date;
                productHistory.ProductHistory_Price = model.ProductHistory_Price;
 
                _dbContext.tbl_ProductHistory.Add(productHistory);
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
