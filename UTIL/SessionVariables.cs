using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using UTIL.Objetos;

namespace UTIL
{
    public class SessionVariables
    {
        public static ObjetoUsuario Session_Datos_Usuarios
        {
            get { return (ObjetoUsuario)HttpContext.Current.Session["VariableSesionUsuario"]; }
            set { HttpContext.Current.Session["VariableSesionUsuario"] = value; }
        }
    }
}
