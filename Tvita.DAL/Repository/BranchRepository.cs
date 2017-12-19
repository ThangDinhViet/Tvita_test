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
    public class BranchRepository : Repository<tbl_Branch, int>, IBranchRepository
    {
        private Repository<tbl_Branch, int> _branchRepository;
        private DbSet<tbl_Branch> _dbSet;
        private readonly Tvita_TestEntities _dbContext;
        public BranchRepository(Tvita_TestEntities dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
            _branchRepository = new Repository<tbl_Branch, int>(_dbContext);
            this._dbSet = _dbContext.Set<tbl_Branch>();
        }
        public bool AddBranch(BranchModel model)
        {
            tbl_Branch branch = new tbl_Branch();
            try
            {
                branch.Branch_Code = model.Branch_Code;
                branch.Branch_Name = model.Branch_Name;
                branch.IsDelete = false;
                _dbContext.tbl_Branch.Add(branch);
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
