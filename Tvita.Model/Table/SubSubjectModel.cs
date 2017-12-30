using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tvita.Model.Table
{
    public class SubSubjectModel
    {
        public int Sub_ID { get; set; }
        public Nullable<int> ID_Subject { get; set; }
        public string Sub_SubjectName { get; set; }
        public string Sub_Description { get; set; }
        public string Sub_Url { get; set; }
        public string Sub_Keyword { get; set; }
        public string Sub_Picture { get; set; }
        public Nullable<bool> IsDelete { get; set; }
    }
}
