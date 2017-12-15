using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tvita.Model.Table
{
    public class CardModel
    {
        public int Card_ID { get; set; }
        public Nullable<int> ID_Order { get; set; }
        public Nullable<double> Card_TotalPrice { get; set; }
        public Nullable<double> Card_TotalPriceSelloff { get; set; }
        public Nullable<double> Card_TraveliingFee { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<bool> IsConfirmSucess { get; set; }
        public Nullable<int> ID_Payments { get; set; }
    }
}
