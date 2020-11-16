using community.DAL;
using community.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace community.Controllers
{

    public class LoginController : Controller
    {
        public static string LoginUserKey = null;
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Login(string name, string pwd,int type)
        {
            Session["type"] = type.ToString();
            List<Administrator> list = AdministratorDAL.GetUserlist(name, pwd, type);
            if (list.Count()>0)
            {
                return Json(new { code = "Ok" });
            }
            return Json(new { code= "error" });
        }
    }
}