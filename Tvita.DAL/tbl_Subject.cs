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
    
    public partial class tbl_Subject
    {
        public int Subject_ID { get; set; }
        public string Subject_Name { get; set; }
        public string Subject_Description { get; set; }
        public Nullable<int> Subject_NumberPosts { get; set; }
        public string Subject_Picture { get; set; }
        public string Subject_Url { get; set; }
        public string Subject_Keyword { get; set; }
        public Nullable<bool> IsDelete { get; set; }
    }
}
