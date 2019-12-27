using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTIL;
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

            IEnumerable<SelectListItem> ListaFamilia = Acceso.ListadoFamilia().Select(c => new SelectListItem()
            {
                Text = c.Familia,
                Value = c.IdFamilia.ToString()
            }).ToList();
            ViewBag.Familia = ListaFamilia;

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

        [HttpGet]
        public ActionResult CrearReceta()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AgregarFamilia(string _Familia, string _Impresora, int _Receta)
        {
            ObjetoFamilia lfamilia = new ObjetoFamilia();
            lfamilia.Familia = _Familia;
            lfamilia.Impresora = _Impresora;
            lfamilia.Receta = _Receta;

            var resultado = Acceso.AgregarFamilia(lfamilia.Familia,lfamilia.Impresora,lfamilia.Receta);

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

        public JsonResult EditarFamilia(string _Familia, string _IdFamilia, string _Impresora)
        {
            var validador = 0;
            ObjetoFamilia lfamialia = new ObjetoFamilia();
            lfamialia.Familia = _Familia;
            lfamialia.IdFamilia = int.Parse(_IdFamilia);
            lfamialia.Impresora = _Impresora;

            RespuestaModel resultado = Acceso.EditarFamilia(lfamialia);
            if (resultado.Verificador == true)
            {
                validador = 1;
                return Json(validador);
            }
            else
            {
                return Json(validador);
            }            
        }

    }
}