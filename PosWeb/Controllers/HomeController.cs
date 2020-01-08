using PosWeb.UTIL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTIL;

namespace PosWeb.Controllers
{
    public class HomeController : Controller
    {
        [Autorizacion]
        public ActionResult Index()
        {
           return View();
        }
    }
}