using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tvita.Model.Table
{
    public class ProductHistoryModel
    {
        public int ProductHistory_ID { get; set; }
        public Nullable<System.DateTime> ProductHistory_Date { get; set; }
        public Nullable<int> ID_Product { get; set; }
        public Nullable<int> ID_ProductionUnit { get; set; }
        public Nullable<double> ProductHistory_Price { get; set; }
        public string IsDelete { get; set; }
    }
}
