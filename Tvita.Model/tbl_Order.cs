//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tvita.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_Order
    {
        public int Order_ID { get; set; }
        public string Customer_Name { get; set; }
        public string Customer_Phone { get; set; }
        public string Customer_Address { get; set; }
        public Nullable<int> ID_Card { get; set; }
        public string Customer_Note { get; set; }
        public string IsDelete { get; set; }
    }
}
