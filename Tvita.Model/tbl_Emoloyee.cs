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
    
    public partial class tbl_Emoloyee
    {
        public int ID { get; set; }
        public string Employee_Name { get; set; }
        public string Employee_Phone { get; set; }
        public string Employee_Address { get; set; }
        public string Employee_Code { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
    }
}
