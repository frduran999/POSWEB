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
        public ActionResult Index()
        {
            if (SessionVariables.Session_Datos_Usuarios == null)
            {
                RedirectToAction("SesionExpirada", "Error");
            }
            return View();
        }
    }
}