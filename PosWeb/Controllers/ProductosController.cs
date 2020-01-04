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

        #region Vistas

        [HttpGet]
        public ActionResult AgregarProductos()
        {
            if (SessionVariables.Session_Datos_Usuarios == null)
            {
                RedirectToAction("SesionExpirada", "Error");
            }

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
            if (SessionVariables.Session_Datos_Usuarios == null)
            {
                RedirectToAction("SesionExpirada", "Error");
            }

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
            if (SessionVariables.Session_Datos_Usuarios == null)
            {
                RedirectToAction("SesionExpirada", "Error");
            }

            //AQUIIII CAMBIAAAAR LISTADOOOOOO COMBOBOX
            //IEnumerable<ObjetoReceta> ListaReceta = Acceso.ListadoReceta();
            //ViewBag.ListadoReceta = ListaReceta;


            IEnumerable<SelectListItem> ListaIngredientes = Acceso.ListaIngredientes().Select(c => new SelectListItem()
            {
                Text = c.Producto,
                Value = c.IdProducto.ToString()
            }).ToList();
            ViewBag.Ingredientes = ListaIngredientes;

            return View();
        }

        #endregion

        #region Familia

        [HttpPost]
        public JsonResult AgregarFamilia(string _Familia, string _Impresora, string _Receta)
        {
            if (SessionVariables.Session_Datos_Usuarios == null)
            {
                RedirectToAction("SesionExpirada", "Error");
            }

            ObjetoFamilia lfamilia = new ObjetoFamilia();
            if (!string.IsNullOrEmpty(_Familia) && !string.IsNullOrEmpty(_Impresora) && !string.IsNullOrEmpty(_Receta))
            {
                lfamilia.Familia = _Familia;
                lfamilia.Impresora = _Impresora;
                lfamilia.Receta = int.Parse(_Receta);

                var resultado = Acceso.AgregarFamilia(lfamilia.Familia, lfamilia.Impresora, lfamilia.Receta);

                if (resultado > 0)
                {
                    return Json(new RespuestaModel() { Verificador = true, Mensaje = "Familia creada correctamente", NumInt = resultado });
                }
                else
                {
                    return Json(new RespuestaModel() { Verificador = false, Mensaje = "Error" });
                }
            }
            else
            {
                var validador = 0;
                return Json(validador);
            }

        }

        public JsonResult ObtenerFamilia(string _IdFamilia)
        {
            if (SessionVariables.Session_Datos_Usuarios == null)
            {
                RedirectToAction("SesionExpirada", "Error");
            }

            if (!string.IsNullOrEmpty(_IdFamilia))
            {
                List<ObjetoFamilia> lfamilia = Acceso.ObtenerFamilia(_IdFamilia);
                return Json(new { list = lfamilia }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var validador = 0;
                return Json(validador);
            }

        }

        public JsonResult EliminarFamilia(string _IdFamilia)
        {
            if (SessionVariables.Session_Datos_Usuarios == null)
            {
                RedirectToAction("SesionExpirada", "Error");
            }

            if (!string.IsNullOrEmpty(_IdFamilia))
            {
                ObjetoFamilia Familia = new ObjetoFamilia();
                Familia.IdFamilia = int.Parse(_IdFamilia);
                RespuestaModel result = Acceso.EliminarFamilia(Familia);

                return (Json(result));
            }
            else
            {
                var validador = 0;
                return Json(validador);
            }

        }

        public JsonResult EditarFamilia(string _Familia, string _IdFamilia, string _Impresora, string _Receta)
        {
            if (SessionVariables.Session_Datos_Usuarios == null)
            {
                RedirectToAction("SesionExpirada", "Error");
            }

            var validador = 0;
            if (!string.IsNullOrEmpty(_Familia) && !string.IsNullOrEmpty(_IdFamilia) && !string.IsNullOrEmpty(_Impresora) && !string.IsNullOrEmpty(_Receta))
            {
                ObjetoFamilia lfamialia = new ObjetoFamilia();
                lfamialia.Familia = _Familia;
                lfamialia.IdFamilia = int.Parse(_IdFamilia);
                lfamialia.Impresora = _Impresora;
                lfamialia.Receta = int.Parse(_Receta);

                RespuestaModel resultado = Acceso.EditarFamilia(lfamialia);
                if (resultado.Verificador == true)
                {
                    validador = 1;
                    return Json(validador);
                }
                else
                {
                    validador = 2;
                    return Json(validador);
                }
            }
            else
            {
                return Json(validador);
            }

        }

        #endregion

        #region Poductos

        [HttpPost]
        public JsonResult AgregarProductos(string _Producto, string _Familia, string _Umedida, string _Precio, string _Receta)
        {
            if (SessionVariables.Session_Datos_Usuarios == null)
            {
                RedirectToAction("SesionExpirada", "Error");
            }

            ObjetoProducto producto = new ObjetoProducto();
            if (!string.IsNullOrEmpty(_Producto) && !string.IsNullOrEmpty(_Familia) && !string.IsNullOrEmpty(_Umedida) && !string.IsNullOrEmpty(_Precio) && !string.IsNullOrEmpty(_Receta))
            {
                producto.Producto = _Producto;
                producto.Familia = _Familia;
                producto.UnidadMedida = _Umedida;
                producto.Precio = int.Parse(_Precio);
                producto.IdReceta = int.Parse(_Receta);

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
            else
            {
                return Json(new RespuestaModel() { Verificador = false, Mensaje = "Debe Ingresar Campos Obligatorios" });
            }
        }

        public JsonResult ObtenerProductos(int _IdProducto)
        {
            if (SessionVariables.Session_Datos_Usuarios == null)
            {
                RedirectToAction("SesionExpirada", "Error");
            }

            if (_IdProducto != 0)
            {
                List<ObjetoProducto> lproducto = Acceso.ObtenerProducto(_IdProducto);
                return Json(new { list = lproducto }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var validador = 0;
                return Json(validador);
            }

        }

        public JsonResult EliminarProducto(int _IdProducto)
        {
            if (SessionVariables.Session_Datos_Usuarios == null)
            {
                RedirectToAction("SesionExpirada", "Error");
            }

            ObjetoProducto Producto = new ObjetoProducto();
            if (_IdProducto != 0)
            {
                Producto.IdProducto = _IdProducto;
                RespuestaModel result = Acceso.EliminarProducto(Producto);

                return (Json(result));
            }
            else
            {
                var validador = 0;
                return Json(validador);
            }
        }

        public JsonResult EditarProducto(string _IdProducto, string _Producto, string _Familia, string _Umedida, string _Precio)
        {
            if (SessionVariables.Session_Datos_Usuarios == null)
            {
                RedirectToAction("SesionExpirada", "Error");
            }

            var validador = 0;
            if (!string.IsNullOrEmpty(_IdProducto) && !string.IsNullOrEmpty(_Producto) && !string.IsNullOrEmpty(_Familia) && !string.IsNullOrEmpty(_Umedida) && !string.IsNullOrEmpty(_Precio))
            {
                ObjetoProducto lproducto = new ObjetoProducto();
                lproducto.IdProducto = int.Parse(_IdProducto);
                lproducto.Producto = _Producto;
                lproducto.Familia = _Familia;
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
                    validador = 2;
                    return Json(validador);
                }
            }
            else
            {
                return Json(validador);
            }

        }

        #endregion

        #region Receta
        [HttpPost]
        public JsonResult CrearReceta(List<ObjetoReceta> listIngredientes, string _Receta)
        {
            ObjetoReceta receta = new ObjetoReceta();
            var resultado = Acceso.grabaReceta(_Receta);
            var idDetalle = 0;
            foreach (var item in listIngredientes)
            {
                receta.IdProducto = item.IdProducto;
                receta.Cantidad = item.Cantidad;
                receta.IdReceta = resultado;
                idDetalle = Acceso.grabaDetalleReceta(receta);
            }
            if (idDetalle > 0)
            {
                return Json(idDetalle);
            }
            return Json(-1);
        }

        #endregion

    }
}