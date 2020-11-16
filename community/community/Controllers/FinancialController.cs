using community.DAL;
using community.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace community.Controllers
{
    public class FinancialController : Controller
    {
        // GET: Financial
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }
        public JsonResult GetFinancial()
        {
            List<Financial> userInfos = FinancialDAL.GetUserlist();
            return Json(new { data = userInfos });
        }

        public JsonResult AddFinancial(Financial financial)
        {
            Financial obj = new Financial();
            obj.Price = financial.Price;
            obj.Remark = financial.Remark;
            obj.FinType = financial.FinType;
            int result = FinancialDAL.Add(obj);
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
            int result = FinancialDAL.Del(id);
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