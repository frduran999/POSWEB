using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTIL;

namespace PosWeb.Controllers
{
    public class VentasController : Controller
    {
        // GET: Ventas
        public ActionResult Ventas()
        {
            if (SessionVariables.Session_Datos_Usuarios == null)
            {
                RedirectToAction("SesionExpirada", "Error");
            }
            return View();
        }
        
    }
}
