//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tvita.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_Product
    {
        public int Product_ID { get; set; }
        public Nullable<int> ID_GroupProduct { get; set; }
        public string Product_Name { get; set; }
        public string Product_Description { get; set; }
        public Nullable<int> Product_Quantity { get; set; }
        public Nullable<double> Product_Price { get; set; }
        public string Product_Picture { get; set; }
        public Nullable<double> Product_Price_Saleoff { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public string Product_Type { get; set; }
        public string Product_Code { get; set; }
    }
}
