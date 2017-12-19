using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tvita.Model.Table
{
    public class ProductionUnitModel
    {
        public int ProductionUnit_ID { get; set; }
        public Nullable<int> ID_Farm { get; set; }
        public string ProductionUnit_Code { get; set; }
        public string ProductionUnit_Name { get; set; }
        public Nullable<double> ProductionUnit_Area { get; set; }
        public string ProductionUnit_Info { get; set; }
        public string ProductionUnit_Capacity { get; set; }
        public string ProductionUnit_Address { get; set; }
        public string ProductionUnit_QualityStandard { get; set; }
        public string ProductionUnit_Unit { get; set; }
        public Nullable<double> ProductionUnit_Price { get; set; }
        public Nullable<double> ProductionUnit_PreviousPrice { get; set; }
        public Nullable<double> ProductionUnit_AveragePrice { get; set; }
        public Nullable<double> ProductionUnit_TransportFee { get; set; }
        public Nullable<double> ProductionUnit_Distance { get; set; }
        public string ProductionUnit_Contract { get; set; }
        public Nullable<bool> IsDelete { get; set; }
    }
}
