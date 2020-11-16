using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace community.Controllers
{
    public abstract class BaseController : Controller
    {
        /// <summary>
        /// 该方法在其他方法之前执行
        /// </summary>
        /// <returns></returns>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            //若用户未登录(已登录的用户信息保存在Session全局对象中
            if (Session[LoginController.LoginUserKey] == null)
            {
                filterContext.Result = Redirect("/Login/Index");
            }
        }
    }
}