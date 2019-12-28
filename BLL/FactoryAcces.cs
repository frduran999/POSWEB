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

        public List<ObjetoMenu> MenuUsuario(int Perfil)
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

        public List<ObjetoProducto> ListadoProductos()
        {
            var Listado = new List<ObjetoProducto>();
            var data = new Conector().EjecutarProcedimiento("ListadoProductos", new System.Collections.Hashtable());

            if (data.Rows.Count > 0)
            {
                for (var i = 0; i < data.Rows.Count; i++)
                {
                    var validador = new object();
                    var resultadoListado = new ObjetoProducto();

                    validador = data.Rows[i].Field<object>("Id");
                    resultadoListado.IdProducto = validador != null ? data.Rows[i].Field<int>("Id") : -1;

                    validador = data.Rows[i].Field<object>("Producto");
                    resultadoListado.Producto = validador != null ? data.Rows[i].Field<string>("Producto") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("IdFamilia");
                    resultadoListado.IdFamilia = validador != null ? data.Rows[i].Field<int>("IdFamilia") : -1;

                    validador = data.Rows[i].Field<object>("UnidadMedida");
                    resultadoListado.UnidadMedida = validador != null ? data.Rows[i].Field<string>("UnidadMedida") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("Estado");
                    resultadoListado.Estado = validador != null ? data.Rows[i].Field<int>("Estado") : -1;

                    validador = data.Rows[i].Field<object>("Familia");
                    resultadoListado.Familia = validador != null ? data.Rows[i].Field<string>("Familia") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("Precio");
                    resultadoListado.Precio = validador != null ? data.Rows[i].Field<double>("Precio") : 0;

                    Listado.Add(resultadoListado);
                }
            }
            return Listado;
        }

        public List<ObjetoReceta> ListadoReceta()
        {
            var Listado = new List<ObjetoReceta>();
            var data = new Conector().EjecutarProcedimiento("ListadoReceta", new System.Collections.Hashtable());

            if (data.Rows.Count > 0)
            {
                for (var i = 0; i < data.Rows.Count; i++)
                {
                    var validador = new object();
                    var resultadoListado = new ObjetoReceta();

                    validador = data.Rows[i].Field<object>("Id");
                    resultadoListado.IdReceta = validador != null ? data.Rows[i].Field<int>("Id") : -1;

                    validador = data.Rows[i].Field<object>("Nombre");
                    resultadoListado.Nombre = validador != null ? data.Rows[i].Field<string>("Nombre") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("IdProducto");
                    resultadoListado.IdProducto = validador != null ? data.Rows[i].Field<int>("IdProducto") : -1;

                    validador = data.Rows[i].Field<object>("Cantidad");
                    resultadoListado.Cantidad = validador != null ? data.Rows[i].Field<int>("Cantidad") : -1;

                    validador = data.Rows[i].Field<object>("Estado");
                    resultadoListado.Estado = validador != null ? data.Rows[i].Field<int>("Estado") : -1;

                    Listado.Add(resultadoListado);
                }
            }
            return Listado;
        }

        public int AgregarProducto(ObjetoProducto producto)
        {
            int respuesta = 0;
            try
            {
                var data = new Conector().EjecutarProcedimiento("AgregarProducto", new System.Collections.Hashtable()
                                                                                            {
                                                                                                {"Producto", producto.Producto},
                                                                                                {"Familia", producto.Familia},
                                                                                                {"UnidadMedida", producto.UnidadMedida},
                                                                                                {"Precio", producto.Precio},
                                                                                                {"Receta", producto.IdReceta}
                });
                if (data.Rows.Count > 0)
                {
                    respuesta = int.Parse(data.Rows[0][0].ToString());
                }
            }
            catch (Exception ex)
            {
                new CapturaExcepciones(ex);
            }
            return respuesta;
        }


        #region Familia

        public RespuestaModel EliminarFamilia(ObjetoFamilia Familia)
        {
            RespuestaModel resp = new RespuestaModel();
            try
            {
                var data = new Conector().EjecutarProcedimiento("EliminarFamilia", new System.Collections.Hashtable()
                {
                    { "Id", Familia.IdFamilia},
                });


                if (data.Rows.Count > 0)
                {
                    for (var i = 0; i < data.Rows.Count; i++)
                    {
                        var validador = new object();

                        validador = data.Rows[i].Field<object>("Verificador");
                        resp.Verificador = validador != null ? data.Rows[i].Field<bool>("Verificador") : false;

                        validador = data.Rows[i].Field<object>("Mensaje");
                        resp.Mensaje = validador != null ? data.Rows[i].Field<string>("Mensaje") : "NO ASIGNADO";
                    }
                }
                else
                {
                    resp = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resp;
        }

        public RespuestaModel EditarFamilia(ObjetoFamilia Familia)
        {
            RespuestaModel resp = new RespuestaModel();
            try
            {
                var data = new Conector().EjecutarProcedimiento("EditarFamilia", new System.Collections.Hashtable()
                {
                    { "Id", Familia.IdFamilia},
                    { "Familia", Familia.Familia},
                    { "Impresora", Familia.Impresora},
                    { "Receta", Familia.Receta}
                });

                if (data.Rows.Count > 0)
                {
                    for (var i = 0; i < data.Rows.Count; i++)
                    {
                        var validador = new object();

                        validador = data.Rows[i].Field<object>("Verificador");
                        resp.Verificador = validador != null ? data.Rows[i].Field<bool>("Verificador") : false;

                        validador = data.Rows[i].Field<object>("Mensaje");
                        resp.Mensaje = validador != null ? data.Rows[i].Field<string>("Mensaje") : "NO ASIGNADO";
                    }
                }
                else
                {
                    resp = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resp;
        }

        public List<ObjetoFamilia> ListadoFamilia()
        {
            var Listado = new List<ObjetoFamilia>();
            var data = new Conector().EjecutarProcedimiento("ListadoFamilia", new System.Collections.Hashtable());

            if (data.Rows.Count > 0)
            {
                for (var i = 0; i < data.Rows.Count; i++)
                {
                    var validador = new object();
                    var resultadoListado = new ObjetoFamilia();

                    validador = data.Rows[i].Field<object>("Id");
                    resultadoListado.IdFamilia = validador != null ? data.Rows[i].Field<int>("Id") : -1;

                    validador = data.Rows[i].Field<object>("Familia");
                    resultadoListado.Familia = validador != null ? data.Rows[i].Field<string>("Familia") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("Impresora");
                    resultadoListado.Impresora = validador != null ? data.Rows[i].Field<string>("Impresora") : "NO ASIGNADO";

                    Listado.Add(resultadoListado);
                }
            }
            return Listado;
        }

        public List<ObjetoPerfil> ListadoPerfil()
        {
            var Listado = new List<ObjetoPerfil>();
            var data = new Conector().EjecutarProcedimiento("ListadoPerfil", new System.Collections.Hashtable());

            if (data.Rows.Count > 0)
            {
                for (var i = 0; i < data.Rows.Count; i++)
                {
                    var validador = new object();
                    var resultadoListado = new ObjetoPerfil();

                    validador = data.Rows[i].Field<object>("Id");
                    resultadoListado.Id = validador != null ? data.Rows[i].Field<int>("Id") : -1;

                    validador = data.Rows[i].Field<object>("Descripcion");
                    resultadoListado.Descripcion = validador != null ? data.Rows[i].Field<string>("Descripcion") : "NO ASIGNADO";
                    
                    Listado.Add(resultadoListado);
                }
            }
            return Listado;
        } //Impresora

        public List<ObjetoFamilia> ObtenerFamilia(string IdFamilia)
        {
            var Listado = new List<ObjetoFamilia>();
            var data = new Conector().EjecutarProcedimiento("ObtenerFamilia", new System.Collections.Hashtable()
            {
                {"IdFamilia",int.Parse(IdFamilia) }
            });

            if (data.Rows.Count > 0)
            {
                for (var i = 0; i < data.Rows.Count; i++)
                {
                    var validador = new object();
                    var resultadoListado = new ObjetoFamilia();

                    validador = data.Rows[i].Field<object>("Id");
                    resultadoListado.IdFamilia = validador != null ? data.Rows[i].Field<int>("Id") : -1;

                    validador = data.Rows[i].Field<object>("Familia");
                    resultadoListado.Familia = validador != null ? data.Rows[i].Field<string>("Familia") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("Impresora");
                    resultadoListado.Impresora = validador != null ? data.Rows[i].Field<string>("Impresora") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("Receta");
                    resultadoListado.Receta = validador != null ? data.Rows[i].Field<int>("Receta") : -1;

                    Listado.Add(resultadoListado);
                }
            }
            return Listado;
        }

        public int AgregarFamilia(string Familia, string Impresora, int Receta)
        {
            int respuesta = 0;
            try
            {
                var data = new Conector().EjecutarProcedimiento("AgregarFamilia", new System.Collections.Hashtable()
                                                                                            {
                                                                                                {"Familia", Familia},
                                                                                                {"Impresora", Impresora},                                                                                             
                                                                                                {"Receta", Receta}                                                                                                
                });
                if (data.Rows.Count > 0)
                {
                    respuesta = int.Parse(data.Rows[0][0].ToString());
                }
            }
            catch (Exception ex)
            {
                new CapturaExcepciones(ex);
            }
            return respuesta;
        }

        #endregion

    }
}
