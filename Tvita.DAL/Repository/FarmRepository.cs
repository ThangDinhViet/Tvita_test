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
    public class FarmRepository : Repository<tbl_Farm, int>, IFarmRepository
    {
        private Repository<tbl_Farm, int> _farmRepository;
        private DbSet<tbl_Farm> _dbSet;
        private readonly Tvita_TestEntities _dbContext;
        public FarmRepository(Tvita_TestEntities dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
            _farmRepository = new Repository<tbl_Farm, int>(_dbContext);
            this._dbSet = _dbContext.Set<tbl_Farm>();
        }
        public bool AddFarm(FarmModel model)
        {
            tbl_Farm farm = new tbl_Farm();
            try
            {
                farm.Farm_Address = model.Farm_Address;
                farm.Farm_Area = model.Farm_Area;
                farm.Farm_Code = model.Farm_Code;
                farm.Farm_Distance = model.Farm_Distance;
                farm.Farm_Info = model.Farm_Info;
                farm.Farm_Name = model.Farm_Name;
                farm.Farm_Territory = model.Farm_Territory;

                _dbContext.tbl_Farm.Add(farm);
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
