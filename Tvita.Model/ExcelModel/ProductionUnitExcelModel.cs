using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tvita.Model.ExcelModel
{
    public class ProductionUnitExcelModel
    {
        public int ID { get; set; }
        public string Branch_Code { get; set; }
        public string Branch_Name { get; set; }
        public string GroupProduct_Name { get; set; }
        public string GroupProduct_Code { get; set; }
        public string Product_Code { get; set; }
        public string Product_Name { get; set; }
        public string Farm_Name { get; set; }
        public string Farm_Code { get; set; }
        public string ProductionUnit_Code { get; set; }
        public string ProductionUnit_Name { get; set; }
        public Nullable<double> ProductionUnit_Area { get; set; }
        public string ProductionUnit_Info { get; set; }
        public string ProductionUnit_Capacity { get; set; }
        public string ProductionUnit_Address { get; set; }
        public string Farm_Address { get; set; }
        public string Farm_Territory { get; set; }
        public string Farm_Info { get; set; }
        public string ProductionUnit_QualityStandard { get; set; }
        public string ProductionUnit_Unit { get; set; }
        public Nullable<double> ProductionUnit_Price { get; set; }
        public Nullable<double> ProductionUnit_PreviousPrice { get; set; }
        public Nullable<double> ProductionUnit_AveragePrice { get; set; }
        public Nullable<double> ProductionUnit_TransportFee { get; set; }
        public Nullable<double> ProductionUnit_Distance { get; set; }
        public string ProductionUnit_Contract { get; set; }
        public bool IsDelete { get; set; }
        public DateTime ProductHistory_Date { get; set; }
        public Nullable<double> ProductHistory_Price { get; set; }
    }
}
