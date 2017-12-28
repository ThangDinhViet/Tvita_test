using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tvita_Test.Models
{
    public class LoadMoreParam
    {
        public int total { get; set; }
        public int recordsInPage { get; set; }
        public int recordsDisplayed { get; set; }
    }

    public class RespondResult
    {
        public LoadMoreParam pageInfo {get; set;}
        public Object data { get; set; }
    }
}