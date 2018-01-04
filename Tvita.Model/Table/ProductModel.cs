using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tvita.Model.Table
{
    public class ProductModel
    {
        public int Product_ID { get; set; }
        public Nullable<int> ID_GroupProduct { get; set; }
        public string Product_Name { get; set; }
        public string Product_Description { get; set; }
        public Nullable<int> Product_Quantity { get; set; }
        public Nullable<double> Product_Price { get; set; }
        public string Product_Picture { get; set; }
        public Nullable<double> Product_Price_Saleoff { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public string Product_Type { get; set; }
        public string Product_Code { get; set; }
        public string Product_Original { get; set; }
        public string Product_PakageStandard { get; set; }
        public string Product_Guide { get; set; }
        public string Product_Preserve { get; set; }
    }
}
