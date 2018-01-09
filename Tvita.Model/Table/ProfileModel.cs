using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tvita.Model.Table
{
    public class ProfileModel
    {
        public string Product { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateEnd { get; set; }
        public string Temple { get; set; }
        public string Barcode { get; set; }
        public string Chanel { get; set; }
        public string Factory { get; set; }
        public string ProductUnitCode { get; set; }
    }

    public class LinkModel
    {
        public string Link { get; set; }
    }
}
