using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tvita.Model.Table
{
    public class EmployeeModel
    {
        public int Employee_ID { get; set; }
        public string Employee_Name { get; set; }
        public string Employee_Phone { get; set; }
        public string Employee_Address { get; set; }
        public string Employee_Code { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.DateTime> Employee_CreatedDate { get; set; }
    }
}
