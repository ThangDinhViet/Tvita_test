using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tvita.Model.Table
{
    public class SubjectModel
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
