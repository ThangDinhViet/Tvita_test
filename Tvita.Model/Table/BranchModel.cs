using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tvita.Model.Table
{
    public class BranchModel
    {
        public int Branch_ID { get; set; }
        public string Branch_Name { get; set; }
        public string Branch_Code { get; set; }
        public Nullable<bool> IsDelete { get; set; }
    }
}
