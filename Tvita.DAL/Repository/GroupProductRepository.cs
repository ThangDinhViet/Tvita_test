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
    class GroupProductRepository : Repository<tbl_GroupProduct, int>, IGroupProductRepository
    {
        private Repository<tbl_GroupProduct, int> _groupProductRepository;
        private DbSet<tbl_GroupProduct> _dbSet;
        private readonly Tvita_TestEntities _dbContext;
        public GroupProductRepository(Tvita_TestEntities dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
            _groupProductRepository = new Repository<tbl_GroupProduct, int>(_dbContext);
            this._dbSet = _dbContext.Set<tbl_GroupProduct>();
        }
        public bool AddGroupProduct(GroupProductModel model)
        {
            tbl_GroupProduct groupProduct = new tbl_GroupProduct();
            try
            {
                groupProduct.GroupProduct_Code = model.GroupProduct_Code;
                groupProduct.GroupProduct_Name = model.GroupProduct_Name;
                groupProduct.GroupProduct_Description = model.GroupProduct_Description;
                groupProduct.GroupProduct_Picture = model.GroupProduct_Picture;
                groupProduct.ID_Branch = model.ID_Branch;
                groupProduct.IsDelete = false;
                _dbContext.tbl_GroupProduct.Add(groupProduct);
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
