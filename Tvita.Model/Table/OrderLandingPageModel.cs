using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tvita.Model.Table
{
    public class OrderLandingPageModel
    {
        public int Order_ID { get; set; }
        public string Customer_Name { get; set; }
        public string Customer_PhoneNum { get; set; }
        public string Customer_Address { get; set; }
        public string Customer_Email { get; set; }
        public string Customer_Note { get; set; }
        public Nullable<int> Product1 { get; set; }
        public Nullable<int> Product2 { get; set; }
        public Nullable<int> Product3 { get; set; }
        public Nullable<int> QuantityPro1 { get; set; }
        public Nullable<int> QuantityPro2 { get; set; }
        public Nullable<int> QuantityPro3 { get; set; }
        public Nullable<DateTime> Date_Created { get; set; }
        public Nullable<DateTime> Time_Delivery { get; set; }
        public Nullable<bool> Is_Confirmed { get; set; }
        public Nullable<int> TotalPrice { get; set; }
    }
}
