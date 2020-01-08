using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using UTIL;
using UTIL.Objetos;

namespace PosWeb.UTIL
{
    public class Autorizacion : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string action = filterContext.ActionDescriptor.ActionName;
            string controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;

            ObjetoUsuario objetoUsuario = SessionVariables.Session_Datos_Usuarios;

            //SESION TERMINADA
            if (objetoUsuario == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { controller = "Error", action = "SesionExpirada" })
                    );

                filterContext.Result.ExecuteResult(filterContext.Controller.ControllerContext);
            }
        }
    }
}