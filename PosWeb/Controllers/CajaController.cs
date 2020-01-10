using PosWeb.UTIL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PosWeb.Controllers
{
    public class CajaController : Controller
    {
        [Autorizacion]
        public ActionResult Caja()
        {
            return View();
        }
    }
}


