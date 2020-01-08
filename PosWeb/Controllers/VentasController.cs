using BLL;
using PosWeb.UTIL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTIL;
using UTIL.Objetos;

namespace PosWeb.Controllers
{
    public class VentasController : Controller
    {
        Control Acceso = new Control();

        [Autorizacion]
        public ActionResult Ventas()
        {
            return View();
        }

        public JsonResult grillaFamilia()
        {
            if (SessionVariables.Session_Datos_Usuarios == null)
            {
                RedirectToAction("SesionExpirada", "Error");
            }
            ObjetoFamilia tablaFamilia = new ObjetoFamilia();
            List<ObjetoFamilia> tablaFamiliaLista = new List<ObjetoFamilia>();

            var ListadoFamilia = Acceso.grillaFamilia();
            
            if (ListadoFamilia != null)
            {
                return Json(new { list = ListadoFamilia }, JsonRequestBehavior.AllowGet);
                //return Json(new { list = ListadoFamilia, Mensaje = ViewBag.mensaje }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                ViewBag.mensaje = 0;
                return Json(new { Mensaje = ViewBag.mensaje }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult grillaProductos(int _idFamilia)
        {
            if (SessionVariables.Session_Datos_Usuarios == null)
            {
                RedirectToAction("SesionExpirada", "Error");
            }
            if (_idFamilia != 0)
            {
                var ListadoProductos = Acceso.grillaProductos(_idFamilia);

                if (ListadoProductos != null)   
                {
                    return Json(new { list = ListadoProductos }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    ViewBag.mensaje = 0;
                    return Json(new { Mensaje = ViewBag.mensaje }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return null;
            }
            
        }

        public JsonResult detalleVenta(int _idProducto)
        {
            if (SessionVariables.Session_Datos_Usuarios == null)
            {
                RedirectToAction("SesionExpirada", "Error");
            }
            if (_idProducto != 0)
            {
                var listadoDetalle = Acceso.tablaDetalleVenta(_idProducto);

                if (listadoDetalle != null)
                {
                    return Json(new { list = listadoDetalle }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    ViewBag.mensaje = 0;
                    return Json(new { Mensaje = ViewBag.mensaje }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return null;
            }

        }

        #region Opc.Caja

        public JsonResult aperturaCaja(string _montoApertura, string _glosaApertura)
        {
            var respuesta = 0;
            if (!string.IsNullOrEmpty(_montoApertura) && !string.IsNullOrEmpty(_glosaApertura))
            {
                ObjetoCaja caja = new ObjetoCaja();
                caja.IdUsuario = SessionVariables.Session_Datos_Usuarios.IdUsuario;
                caja.Monto = int.Parse(_montoApertura);
                caja.Glosa = _glosaApertura;
                caja.IdSucursal = 1;

                respuesta = Acceso.aperturaCaja(caja);
                caja.IdCaja = respuesta;
                if (respuesta > 0)
                {
                    SessionVariables.Session_Datos_Caja = caja;
                    return Json(respuesta);
                }
                else
                {
                    return Json(respuesta);
                }
            }
            else
            {
                return Json(-1);
            }
        }

        public JsonResult retiroCaja(string _montoRetiro, string _glosaRetiro)
        {
            if (!string.IsNullOrEmpty(_montoRetiro) && !string.IsNullOrEmpty(_glosaRetiro))
            {
                return Json(1);
            }
            else
            {
                return null;
            }
        }

        public JsonResult cierreCaja(string _glosaCierre)
        {
            if (!string.IsNullOrEmpty(_glosaCierre))
            {
                return Json(1);
            }
            else
            {
                return null;
            }
        }

        #endregion
    }
}
