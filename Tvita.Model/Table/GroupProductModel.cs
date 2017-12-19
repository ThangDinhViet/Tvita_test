using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tvita.Model.Table
{
    public class GroupProductModel
    {
        public int GroupProduct_ID { get; set; }
        public string GroupProduct_Code { get; set; }
        public string GroupProduct_Name { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public string GroupProduct_Description { get; set; }
        public string GroupProduct_Picture { get; set; }
        public Nullable<int> ID_Branch { get; set; }
    }
}
