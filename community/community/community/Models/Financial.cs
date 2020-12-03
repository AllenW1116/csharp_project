using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace community.Models
{
    public class Financial
    {
        public int AutoID { get; set; }
        public decimal Price { get; set; }
        public string Remark { get; set; }
        public int FinType { get; set; }
    }
}