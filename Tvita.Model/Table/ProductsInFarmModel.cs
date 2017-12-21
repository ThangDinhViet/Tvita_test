using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tvita.Model.Table
{
    public class ProductsInFarmModel
    {
        public int PIF_ID { get; set; }
        public Nullable<int> ID_ProductionUnit { get; set; }
        public Nullable<int> ID_Product { get; set; }
        public Nullable<double> PIF_AveragePrice { get; set; }
        public Nullable<bool> IsDelete { get; set; }
    }
}
