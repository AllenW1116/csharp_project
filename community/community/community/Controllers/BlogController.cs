using community.DAL;
using community.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace community.Controllers
{
    public class BlogController : Controller
    {
        private static string img = "";
        // GET: Blog
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult Addblog2()
        {
            return View();
        }
        public ActionResult Show(int Id)
        {
            Blog userInfos = BlogDAL.GetRegionInfo().Where(c =>c.AutoID==Id).FirstOrDefault();
            ViewData["Title"] = userInfos.Title;
            ViewData["Abstract"] = userInfos.Abstract;
            ViewData["img"] = userInfos.img;
            return View();
        }
        public ActionResult UploadEditImg(HttpPostedFileBase file)
        {
            EditorDataResult editorResult = new EditorDataResult();
            if (file != null && !string.IsNullOrEmpty(file.FileName))
            {
                string saveAbsolutePath = Server.MapPath("~/CourseImages");
                string saveFileName = Guid.NewGuid().ToString("N") + "_" + file.FileName;
                string fileName = Path.Combine(saveAbsolutePath, saveFileName);
                file.SaveAs(fileName);
                editorResult.code = 0;
                editorResult.msg = "图片上传成功!";
                editorResult.data = new Dictionary<string, string>()
                                {
                                         { "src","/CourseImages/" + saveFileName },
                     { "title","图片名称" }
                                     };
                img += "/CourseImages/" + saveFileName + ",";
            }
            else
            {
                editorResult.code = 1;
                editorResult.msg = "图片上传失败!";
                editorResult.data = new Dictionary<string, string>()
                 {
                                         { "src","" }
                };
            }
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string data = jss.Serialize(editorResult);//转换为Json格式!

            return Json(data);
        }
        public JsonResult AddblogDate(Blog typeInfo)
        {
            Blog obj = new Blog();
            obj.Title = typeInfo.Title;
            obj.Abstract = typeInfo.Abstract;
            obj.Remark = typeInfo.Remark;
            if (img == null || img == "")
            {
                obj.img = "";
            }
            else {
                obj.img = img.Substring(0, img.Length - 1);
            }
            int result = BlogDAL.Add(obj);
            if (result > 0)
            {
                img = "";
                return Json(new { msg = "OK" });
            }
            else
            {
                return Json(new { data = "error" });
            }

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
                return Json(new { data = "Ok" });
            }
            else
            {
                return Json(new { data = "error" });
            }
        }
        public JsonResult Del(string Id)
        {
            int result = BlogDAL.Del(Id);
            if (result > 0)
            {
                return Json(new { data = "Ok" });
            }
            else
            {
                return Json(new { data = "error" });
            }
        }
    }
}