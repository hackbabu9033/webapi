using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace exercise.Controllers
{
    // 使用MVC的controller，預設繼承System.Web.Mvc底下的controller
    public class MvcDefaultController : Controller
    {
        // GET: MvcDefault
        public ActionResult Index()
        {
            return View();
        }
    }
}