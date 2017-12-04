using System;
using System.Collections.Generic;
using System.Linq;
using Tvita.BAL.Interface;
using Tvita.DAL.Common;
using Tvita.Model.Table;

namespace Tvita.BAL.Implement
{
    public class EmployeeManager : IEmployeeManager
    {

        public List<EmployeeModel> GetAllEmployee()
        {
            var listEmployee = new List<EmployeeModel>();
            using (IUnitOfWork uOW = new UnitOfWork())
            {
                listEmployee = uOW.EmployeeRepository.GetAll().Select(x => new EmployeeModel
                {
                    Employee_Name = x.Employee_Name,
                    Employee_Address = x.Employee_Address,
                    Employee_Code = x.Employee_Code,
                    Employee_Phone = x.Employee_Phone,
                    ID = x.ID,
                    CreatedDate = x.CreatedDate
                }).ToList();
            }
            return listEmployee;
        }
        public bool AddEmployee(EmployeeModel model)
        {
            using (IUnitOfWork uOW = new UnitOfWork())
            {
                uOW.IEmployeeRepository.AddEmployee(model);
                
            }
            return true;
        }
    }
}
