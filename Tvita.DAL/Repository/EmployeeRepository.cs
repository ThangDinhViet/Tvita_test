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
    public class EmployeeRepository : Repository<tbl_Emoloyee, int>, IEmployeeRepository
    {
        private Repository<tbl_Emoloyee, int> _employeeRepository;
        private DbSet<tbl_Emoloyee> _dbSet;
        private readonly Tvita_TestEntities _dbContext;
        public EmployeeRepository(Tvita_TestEntities dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
            _employeeRepository = new Repository<tbl_Emoloyee, int>(_dbContext);
            this._dbSet = _dbContext.Set<tbl_Emoloyee>();
        }
        public List<EmployeeModel> GetAllEmployee()
        {
            List<EmployeeModel> result = new List<EmployeeModel>();
            result = (from c in _dbContext.tbl_Emoloyee
                      select new EmployeeModel
                      {
                          
                      }).ToList();
            return result;
        }

        public bool AddEmployee(EmployeeModel model)
        {
            tbl_Emoloyee employee = new tbl_Emoloyee();
            try
            {
                employee.CreatedDate = model.CreatedDate;
                employee.Employee_Address = model.Employee_Address;
                employee.Employee_Code = model.Employee_Code;
                employee.Employee_Name = model.Employee_Name;
                employee.Employee_Phone = model.Employee_Phone;
                _dbContext.tbl_Emoloyee.Add(employee);
                Save();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
