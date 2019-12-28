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

        [HttpGet]
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

            IEnumerable<SelectListItem> ListaReceta = Acceso.ListadoReceta().Select(c => new SelectListItem()
            {
                Text = c.Nombre,
                Value = c.IdReceta.ToString()
            }).ToList();
            ViewBag.Receta = ListaReceta;

            return View();
        }

        [HttpGet]
        public ActionResult AgregarFamilia()
        {
            List<string> Impresoras = new List<string>();
            foreach (String strPrinter in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                Impresoras.Add(strPrinter);
            }
            
            ViewBag.Impresoras = Impresoras;
            
            IEnumerable<ObjetoFamilia> ListaFamilia = Acceso.ListadoFamilia();
            ViewBag.ListadoFamilia = ListaFamilia;

            return View();
        }

        [HttpGet]
        public ActionResult CrearReceta()
        {
            IEnumerable<ObjetoReceta> ListaReceta = Acceso.ListadoReceta();
            ViewBag.ListadoReceta = ListaReceta;
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
                return Json(new RespuestaModel() { Verificador = true, Mensaje = "Familia creada correctamente",NumInt = resultado});
            }
            else
            {
                return Json(new RespuestaModel() { Verificador = false, Mensaje = "Error" });
            }
        }

        [HttpPost]
        public JsonResult AgregarProductos(string _Producto, string _Familia, string _Umedida, int _Precio, int _Receta)
        {
            ObjetoProducto producto = new ObjetoProducto();
            producto.Producto = _Producto;
            producto.Familia = _Familia;
            producto.UnidadMedida = _Umedida;
            producto.Precio = _Precio;
            producto.IdReceta = _Receta;

            var resultado = Acceso.AgregarProducto(producto);

            if (resultado > 0)
            {
                return Json(new RespuestaModel() { Verificador = true, Mensaje = "Producto creada correctamente", NumInt = resultado });
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

        public JsonResult ObtenerProductos(int _IdProducto)
        {
            List<ObjetoProducto> lproducto = Acceso.ObtenerProducto(_IdProducto);
            return Json(new { list = lproducto }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult EliminarProducto(int _IdProducto)
        {
            ObjetoProducto Producto = new ObjetoProducto();
            Producto.IdProducto = _IdProducto;
            RespuestaModel result = Acceso.EliminarProducto(Producto);

            return (Json(result));
        }


        public JsonResult EliminarFamilia(string _IdFamilia)
        {
            ObjetoFamilia Familia = new ObjetoFamilia();
            Familia.IdFamilia = int.Parse(_IdFamilia);
            RespuestaModel result = Acceso.EliminarFamilia(Familia);

            return (Json(result));
        }

        public JsonResult EditarFamilia(string _Familia, string _IdFamilia, string _Impresora, int _Receta)
        {
            var validador = 0;
            ObjetoFamilia lfamialia = new ObjetoFamilia();
            lfamialia.Familia = _Familia;
            lfamialia.IdFamilia = int.Parse(_IdFamilia);
            lfamialia.Impresora = _Impresora;
            lfamialia.Receta = _Receta;

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

        public JsonResult EditarProducto(string _IdProducto, string _Producto, string _IdFamilia, string _Umedida, string _Precio)
        {
            var validador = 0;
            ObjetoProducto lproducto = new ObjetoProducto();
            lproducto.IdProducto = int.Parse(_IdProducto);
            lproducto.Producto = _Producto;
            lproducto.IdFamilia = int.Parse(_IdFamilia);
            lproducto.UnidadMedida = _Umedida;
            lproducto.Precio = double.Parse(_Precio);

            RespuestaModel resultado = Acceso.EditarProducto(lproducto);
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