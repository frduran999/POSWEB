using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTIL;
using UTIL.Objetos;
using UTIL.Validaciones;

namespace PosWeb.Controllers
{
    public class LoginController : Controller
    {
        Control Acceso = new Control();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public JsonResult Login(string _Nombre, string _Contrasena)
        {
            var datosUsuario = new ObjetoUsuario();
            SessionVariables.Session_Datos_Usuarios = null;
            var validador = 0;
            datosUsuario.Usuario = _Nombre;
            datosUsuario.Contrasena = _Contrasena;
            datosUsuario.Contrasena = HashMd5.GetMD5(datosUsuario.Contrasena);

            var resultado = Acceso.LoginUsuario(datosUsuario);

            SessionVariables.Session_Datos_Usuarios = resultado;

            if (resultado != null)
            {
                validador = 2;
                return Json(validador);
            }
            else
            {
                return Json(new RespuestaModel() { Verificador = false, Mensaje = "Error de Usuario y/o Contraseña" });
            }
        }

        public ActionResult LogOut()
        {
            SessionVariables.Session_Datos_Usuarios = null;
            return RedirectToAction("Login","Login");
        }
    }
}
