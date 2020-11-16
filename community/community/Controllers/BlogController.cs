﻿using community.DAL;
using community.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace community.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }

        public JsonResult GetBlog()
        {
            List<Blog> userInfos = BlogDAL.GetRegionInfo();
            return Json(new { data = userInfos });
        }

        public JsonResult AddBlog(Blog info)
        {
            Blog obj = new Blog();
            obj.Title = info.Title;
            obj.Remark = info.Remark;
            int result = BlogDAL.Add(obj);
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
            int result = BlogDAL.Del(id);
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