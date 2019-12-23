using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTIL.Objetos;

namespace BLL
{
    public class FactoryAcces
    {
        public ObjetoUsuario LoginUsuario (ObjetoUsuario datosUsuario)
        {
            var DatosLogin = new ObjetoUsuario();
            var data = new Conector().EjecutarProcedimiento("SP_GET_LOGIN", new System.Collections.Hashtable()
            {
                {"Usuario", datosUsuario.Usuario },
                {"Contrasena", datosUsuario.Contrasena }
            });
            if (data.Rows.Count > 0)
            {
                for (var i = 0; i < data.Rows.Count; i++)
                {
                    var validador = new object();

                    validador = data.Rows[i].Field<object>("Id");
                    DatosLogin.IdUsuario = validador != null ? data.Rows[i].Field<int>("Id") : 0;

                    validador = data.Rows[i].Field<object>("Usuario");
                    DatosLogin.Usuario = validador != null ? data.Rows[i].Field<string>("Usuario") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("Perfil");
                    DatosLogin.Perfil = validador != null ? data.Rows[i].Field<int>("Perfil") : 0;
                }
            }
            else
            {
                DatosLogin = null;
            }
            return DatosLogin;
        }

        public List<ObjetoMenu> MenuUsuario (int Perfil)
        {
            var listadoMenu = new List<ObjetoMenu>();
            var data = new Conector().EjecutarProcedimiento("SP_GET_Menu", new System.Collections.Hashtable()
            {
                {"Perfil", Perfil}
            });
            if (data.Rows.Count > 0)
            {
                for (var i = 0; i < data.Rows.Count; i++)
                {
                    var validador = new object();
                    var resultadoListado = new ObjetoMenu();
                    validador = data.Rows[i].Field<object>("Id");
                    resultadoListado.IdMenu = validador != null ? data.Rows[i].Field<int>("Id") : -1;

                    validador = data.Rows[i].Field<object>("Clase");
                    resultadoListado.Clase = validador != null ? data.Rows[i].Field<string>("Clase") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("PieMenu");
                    resultadoListado.PieMenu = validador != null ? data.Rows[i].Field<string>("PieMenu") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("Titulo");
                    resultadoListado.Titulo = validador != null ? data.Rows[i].Field<string>("Titulo") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("Action");
                    resultadoListado.Action = validador != null ? data.Rows[i].Field<string>("Action") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("Controller");
                    resultadoListado.Controller = validador != null ? data.Rows[i].Field<string>("Controller") : "NO ASIGNADO";

                    listadoMenu.Add(resultadoListado);
                }
            }
            return listadoMenu;
        }
    }
}
