using community.DAL;
using community.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace community.Controllers
{
    public class UserInfoController : Controller
    {
        static int Id = 0;
        // GET: UserInfo
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            Id = id;
            UserInfo user = UserInfoDAL.GetUserlist().Where(c => c.AutoID == Id).FirstOrDefault();
            ViewBag.UserName = user.UserName;
            ViewBag.UserSex = user.UserSex;
            ViewBag.IdentityNumber = user.IdentityNumber;
            ViewBag.ContactAddress = user.ContactAddress;
            ViewBag.ContactPhone = user.ContactPhone;
            ViewBag.Email = user.Email;
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }
        public JsonResult GetUser(string pageIndex, string pageSize)
        {
            List<UserInfo> userInfos = UserInfoDAL.GetUserlist();
            List<UserInfo> userInfo = userInfos.OrderBy(u => u.AutoID).
                    Skip((int.Parse(pageIndex) - 1) * int.Parse(pageSize)).Take(int.Parse(pageSize)).ToList();
            return Json(new { data = userInfo, total = userInfos.Count() });
        }
        public JsonResult GetEdit(UserInfo user)
        {
            UserInfo obj = new UserInfo();
            obj.AutoID = Id;
            obj.UserName = user.UserName;
            obj.UserSex = user.UserSex;
            obj.IdentityNumber = user.IdentityNumber;
            obj.ContactAddress = user.ContactAddress;
            obj.ContactPhone = user.ContactPhone;
            obj.Email = user.Email;
            int result = UserInfoDAL.Edit(obj);
            if (result > 0)
            {
                return Json(new { msg = "OK" });
            }
            else
            {
                return Json(new { data = "error" });
            }
        }

        public JsonResult Adduser(UserInfo user)
        {
            UserInfo obj = new UserInfo();
            obj.UserName = user.UserName;
            obj.UserSex = user.UserSex;
            obj.IdentityNumber = user.IdentityNumber;
            obj.ContactAddress = user.ContactAddress;
            obj.ContactPhone = user.ContactPhone;
            obj.Email = user.Email;
            int result = UserInfoDAL.Add(obj);
            if (result > 0)
            {
                return Json(new { msg = "OK" });
            }
            else
            {
                return Json(new { data = "error" });
            }
        }


        public JsonResult Del(string id)
        {
            int result = UserInfoDAL.Del(id);
            if (result > 0)
            {
                return Json(new { msg = "Ok" });
            }
            else
            {
                return Json(new { msg = "error" });
            }
        }
    }
}