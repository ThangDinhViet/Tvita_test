using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tvita.Model.Table
{
    public class CardDetailsModel
    {
        public int CardDetails_ID { get; set; }
        public Nullable<int> ID_Card { get; set; }
        public Nullable<int> ID_Product { get; set; }
        public Nullable<int> CardDetails_Amount { get; set; }
        public Nullable<bool> IsDelete { get; set; }
    }
}
