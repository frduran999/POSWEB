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

        [HttpGet]
        public ActionResult AgregarFamilia()
        {
            IEnumerable<ObjetoFamilia> ListaFamilia = Acceso.ListadoFamilia();
            ViewBag.ListadoFamilia = ListaFamilia;

            IEnumerable<SelectListItem> ListaPerfil = Acceso.ListadoPerfil().Select(c => new SelectListItem()
            {
                Text = c.Descripcion,
                Value = c.Id.ToString()
            }).ToList();
            ViewBag.Perfil = ListaPerfil;

            return View();
        }

        [HttpPost]
        public JsonResult AgregarFamilia(string _Familia, string _Impresora)
        {
            ObjetoFamilia lfamilia = new ObjetoFamilia();
            lfamilia.Familia = _Familia;
            lfamilia.Impresora = _Impresora;

            var resultado = Acceso.AgregarFamilia(lfamilia.Familia,lfamilia.Impresora);

            if (resultado > 0)
            {
                return Json(new RespuestaModel() { Verificador = true, Mensaje = "Familia creada correctamente",NumInt = resultado
 });
            }
            else
            {
                return Json(new RespuestaModel() { Verificador = false, Mensaje = "Error" });
            }
            
        }

        public JsonResult ObtenerFamilia (string _IdFamilia)
        {
            List<ObjetoFamilia> lfamilia = Acceso.ObtenerFamilia(_IdFamilia);
            return Json(new { list = lfamilia }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult EliminarFamilia(string _IdFamilia)
        {
            ObjetoFamilia Familia = new ObjetoFamilia();
            Familia.IdFamilia = int.Parse(_IdFamilia);
            RespuestaModel result = Acceso.EliminarFamilia(Familia);

            return (Json(result));
        }

    }
}