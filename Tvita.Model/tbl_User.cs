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
    
    public partial class tbl_User
    {
        public int User_ID { get; set; }
        public Nullable<int> ID_Employee { get; set; }
        public string User_Name { get; set; }
        public string User_Password { get; set; }
        public Nullable<int> ID_Group { get; set; }
        public Nullable<bool> IsDelete { get; set; }
    }
}
