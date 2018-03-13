using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tvita.DAL.Common;

namespace Tvita.DAL.Repository
{
    public class PURepository : Repository<PU, int>, IPURepository
    {
        private Repository<PU, int> _puRepository;
        private DbSet<PU> _dbSet;
        private readonly Tvita_TestEntities _dbContext;
        public PURepository(Tvita_TestEntities dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
            _puRepository = new Repository<PU, int>(_dbContext);
            this._dbSet = _dbContext.Set<PU>();
        }
        
    }
}
