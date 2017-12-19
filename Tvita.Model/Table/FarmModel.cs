using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tvita.Model.Table
{
    public class FarmModel
    {
        public int Farm_ID { get; set; }
        public string Farm_Code { get; set; }
        public string Farm_Address { get; set; }
        public Nullable<double> Farm_Area { get; set; }
        public string Farm_Info { get; set; }
        public Nullable<double> Farm_Distance { get; set; }
        public string Farm_Territory { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public string Farm_Name { get; set; }
    }
}
