using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tvita.Model.Common
{
    public class LoadMoreParam
    {
        public int total { get; set; }
        public int recordsInPage { get; set; }
        public int recordsDisplayed { get; set; }
        public int idBranch { get; set; }
        public int idGroup { get; set; }
    }

    public class RespondResult
    {
        public LoadMoreParam pageInfo { get; set; }
        public Object data { get; set; }
    }
}
