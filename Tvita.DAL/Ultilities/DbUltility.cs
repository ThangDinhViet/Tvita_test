using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tvita.DAL.Ultilities
{
    public class DbUtility
    {
        private readonly Tvita_TestEntities _dbContext;

        public DbUtility(Tvita_TestEntities dbContext)
        {
            this._dbContext = dbContext;
        }

        public long GetNextSequenceId(string sequenceName)
        {
            var rawQuery = _dbContext.Database.SqlQuery<long>("SELECT NEXT VALUE FOR dbo." + sequenceName + ";");
            var task = rawQuery.SingleAsync();
            long nextVal = task.Result;
            return nextVal;
        }
        public long GetNextSequenceFromStore(string sequenceName, string ParameterName)
        {

            var id = new SqlParameter
            {
                ParameterName = ParameterName,
                DbType = DbType.Int32,
                Direction = ParameterDirection.Output
            };
            var result = _dbContext.Database.SqlQuery<int>("EXEC " + sequenceName + " @" + ParameterName, id);
            var task = result.FirstAsync();
            long nextVal = task.Result;
            return nextVal;
        }
        public void ExecuteSql(string sql)
        {
            _dbContext.Database.ExecuteSqlCommand(sql);
        }
    }
}
