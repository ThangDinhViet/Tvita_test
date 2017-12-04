using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tvita.Model.Table
{
    public class CardDetailsModel
    {
        public int ID { get; set; }
        public Nullable<int> ID_Card { get; set; }
        public Nullable<int> ID_Product { get; set; }
        public Nullable<int> Amount { get; set; }
        public Nullable<bool> IsDelete { get; set; }
    }
}
