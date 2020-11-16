using community.DAL;
using community.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace community.Controllers
{
    public class RegionInfoController : Controller
    {
        // GET: RegionInfo
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }
        public JsonResult GetRegionInfo()
        {
            List<RegionInfo> userInfos = RegionInfoDAL.GetRegionInfo();
            return Json(new { data = userInfos });
        }

        public JsonResult Addreginon(RegionInfo info)
        {
            RegionInfo obj = new RegionInfo();
            obj.Name = info.Name;
            obj.Remark = info.Remark;
            int result = RegionInfoDAL.Add(obj);
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
            int result = RegionInfoDAL.Del(id);
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