using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTIL.Objetos;

namespace PosWeb.Controllers
{
    public class ProductosController : Controller
    {
        Control Acceso = new Control();
        
        public ActionResult AgregarProductos()
        {
            IEnumerable<ObjetoProducto> ListaProductos = Acceso.ListadoProductos();
            ViewBag.ListadoProductos = ListaProductos;
            return View();
        }

        public ActionResult AgregarFamilia()
        {
            IEnumerable<ObjetoFamilia> ListaFamilia = Acceso.ListadoFamilia();
            ViewBag.ListadoFamilia = ListaFamilia;
            return View();
        }
	}
}