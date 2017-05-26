using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace WebAPIDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Indexs()
        {
            return View();
        }
        public ActionResult Index1()
        {
            return View();
        }
    }
}