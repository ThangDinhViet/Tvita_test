using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tvita.Model.Table
{
    public class PictureModel
    {
        public int Picture_ID { get; set; }
        public string Picture_Name { get; set; }
        public string Picture_Description { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public string Picture_Url { get; set; }
    }
}
