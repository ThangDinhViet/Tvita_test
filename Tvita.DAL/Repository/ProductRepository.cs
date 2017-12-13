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
    public class ProductRepository : Repository<tbl_Product, int>, IProductRepository
    {
        private Repository<tbl_Product, int> _productRepository;
        private DbSet<tbl_Product> _dbSet;
        private readonly Tvita_TestEntities _dbContext;
        public ProductRepository(Tvita_TestEntities dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
            _productRepository = new Repository<tbl_Product, int>(_dbContext);
            this._dbSet = _dbContext.Set<tbl_Product>();
        }
        public List<ProductModel> GetAllProduct()
        {
            List<ProductModel> result = new List<ProductModel>();
            result = (from c in _dbContext.tbl_Product
                      select new ProductModel
                      {
                          
                      }).ToList();
            return result;
        }
    }
}
