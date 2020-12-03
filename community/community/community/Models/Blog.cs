using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace community.Models
{
    public class Blog
    {
        public int AutoID { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public string Remark { get; set; }
        public string img { get; set; }
    }
}