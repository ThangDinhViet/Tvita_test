﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tvita.Model.Table
{
    public class PostModel
    {
        public int Post_ID { get; set; }
        public Nullable<int> ID_SubSubject { get; set; }
        public string Post_Name { get; set; }
        public string Post_Description { get; set; }
        public string Post_Content { get; set; }
        public string Post_Picture { get; set; }
        public string Post_Video { get; set; }
        public string Post_Keyword { get; set; }
        public string Post_Url { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.DateTime> Post_DateCreated { get; set; }
    }
}