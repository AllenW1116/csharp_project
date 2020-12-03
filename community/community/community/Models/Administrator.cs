using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace community.Models
{
    public class Administrator
    {
        public int AutoID { get; set; }
        public string Name { get; set; }
        public string Pwd { get; set; }
        //0 管理员   1普通用户
        public int AdminType { get; set; }
        
    }
}