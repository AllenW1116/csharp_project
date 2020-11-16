using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace community.Models
{
    public class UserInfo
    {
        public int AutoID { get; set; }
        public string UserName { get; set; }
        public int UserSex { get; set; }
        public string IdentityNumber { get; set; }
        public string ContactAddress { get; set; }
        public string ContactPhone { get; set; }
        public string Email { get; set; }
       
    }
}