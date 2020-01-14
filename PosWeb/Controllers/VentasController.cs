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
            IEnumerable<SelectListItem> listGarzones = Acceso.listarGarzones().Select(c => new SelectListItem()
            {
                Text = c.Nombre,
                Value = c.IdEmpleado.ToString()
            }).ToList();
            ViewBag.garzones = listGarzones;
            return View();
        }

        public JsonResult obtenerMesa()
        {
            List<ObjetoMesa> lmesas = Acceso.ObtenerMesas();
            return Json(new { list = lmesas }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult grillaFamilia()
        {
            ObjetoFamilia tablaFamilia = new ObjetoFamilia();
            List<ObjetoFamilia> tablaFamiliaLista = new List<ObjetoFamilia>();

            var ListadoFamilia = Acceso.grillaFamilia();
            
            if (ListadoFamilia != null)
            {
                return Json(new { list = ListadoFamilia }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                ViewBag.mensaje = 0;
                return Json(new { Mensaje = ViewBag.mensaje }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult grillaProductos(int _idFamilia)
        {
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

        public JsonResult generaVenta(List<ObjetoVenta> detalleVenta, List<ObjetoCabVenta> cabeceraVenta)
        {
            var resultadoCab = 0;
            var resultadoDet = 0;
            ObjetoCabVenta cabecera = new ObjetoCabVenta();
            ObjetoVenta detalle = new ObjetoVenta();
            foreach (var Cab in cabeceraVenta)
            {
                cabecera.IdGarzon = Cab.IdGarzon;
                cabecera.NumMesa = Cab.NumMesa;
                string[] propina = Cab.Propina.Split('$');
                cabecera.Propina = propina[1];
                cabecera.Total = Cab.Total;
                //resultadoCab = Acceso.grabaCabVenta(cabecera);
            }
            if (resultadoCab > 0)
            {
                foreach (var Detalle in detalleVenta)
                {
                    detalle.IdProducto = Detalle.IdProducto;
                    detalle.Cantidad = Detalle.Cantidad;
                    detalle.Linea = Detalle.Linea;
                    detalle.Desc = Detalle.Desc;
                    detalle.TotalLinea = Detalle.TotalLinea;
                    detalle.IdFamilia = Detalle.IdFamilia;
                    detalle.Precio = Detalle.Precio;
                    detalle.IdReceta = Detalle.IdReceta;
                    detalle.IdCab = resultadoCab;
                    //resultadoDet = Acceso.grabaDetalleVenta(detalle);
                }
            }
            return Json(-1);
        }

        public JsonResult agregarMesa(string _numMesa, string _tipo)
        {
            var respuesta = 0;
            ObjetoMesa mesas = new ObjetoMesa();
            if (!string.IsNullOrEmpty(_numMesa) && !string.IsNullOrEmpty(_tipo))
            {
                mesas.Numero = int.Parse(_numMesa);
                mesas.Tipo = _tipo;
                
                respuesta = Acceso.agregarMesa(mesas);
                if (respuesta == -666)
                {
                    return Json(respuesta);
                }
                if (respuesta > 0)
                {
                    return Json(respuesta);
                }
                else
                {
                    return Json(-2);
                }
            }
            else
            {
                return Json(-1);
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
                var idUsuario = SessionVariables.Session_Datos_Usuarios.IdUsuario;
                RespuestaModel result = Acceso.cierreCaja(idUsuario,_glosaCierre);

                return Json(result);
            }
            else
            {
                return null;
            }
        }

        public JsonResult validaApertura()
        {
            var idUsuario = SessionVariables.Session_Datos_Usuarios.IdUsuario;
            RespuestaModel result = Acceso.validaApertura(idUsuario);
            
            return Json(result);
        }

        #endregion
    }
}
