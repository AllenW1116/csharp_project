using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace community.Models
{
    public class EditorDataResult
    {
        public int code { get; set; }

        public string msg { get; set; }

        public Dictionary<string, string> data { get; set; }
    }
}