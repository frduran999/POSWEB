using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTIL.Objetos;

namespace BLL
{
    public class Control
    {
        private FactoryAcces Acceso = new FactoryAcces();

        #region Login
        public ObjetoUsuario LoginUsuario(ObjetoUsuario usuario)
        {
            return Acceso.LoginUsuario(usuario);
        }

        public List<ObjetoMenu> MenuUsuario(int Perfil)
        {
            return Acceso.MenuUsuario(Perfil);
        }
        #endregion

        #region Productos
        public List<ObjetoProducto> ListadoProductos()
        {
            return Acceso.ListadoProductos();
        }

        public int AgregarProducto(ObjetoProducto producto)
        {
            return Acceso.AgregarProducto(producto);
        }

        public List<ObjetoProducto> ObtenerProducto(int IdProducto)
        {
            return Acceso.ObtenerProducto(IdProducto);
        }

        public RespuestaModel EliminarProducto(ObjetoProducto Producto)
        {
            return Acceso.EliminarProducto(Producto);
        }

        public RespuestaModel EditarProducto(ObjetoProducto producto)
        {
            return Acceso.EditarProducto(producto);
        }
        #endregion

        #region Familia

        public List<ObjetoFamilia> ListadoFamilia()
        {
            return Acceso.ListadoFamilia();
        }
        
        public int AgregarFamilia(string Familia, string Impresora,int Receta)
        {
            return Acceso.AgregarFamilia(Familia, Impresora, Receta);
        }

        public List<ObjetoFamilia> ObtenerFamilia(string IdFamilia)
        {
            return Acceso.ObtenerFamilia(IdFamilia);
        }

        public RespuestaModel EliminarFamilia(ObjetoFamilia Familia)
        {
            return Acceso.EliminarFamilia(Familia);
        }

        public RespuestaModel EditarFamilia(ObjetoFamilia Familia)
        {
            return Acceso.EditarFamilia(Familia);
        }

        #endregion



        public List<ObjetoReceta> ListadoReceta()
        {
            return Acceso.ListadoReceta();
        }

        public List<ObjetoProducto> ListaIngredientes()
        {
            return Acceso.ListaIngredientes();
        }

        public int grabaReceta(string receta)
        {
            return Acceso.grabaReceta(receta);
        }

        public int grabaDetalleReceta(ObjetoReceta detalleReceta)
        {
            return Acceso.grabaDetalleReceta(detalleReceta);
        }

        public int aperturaCaja(ObjetoCaja caja)
        {
            return Acceso.aperturaCaja(caja);
        }

        public List<ObjetoFamilia> grillaFamilia()
        {
            return Acceso.grillaFamilia();
        }

        public List<ObjetoProducto> grillaProductos(int idFamilia)
        {
            return Acceso.grillaProductos(idFamilia);
        }

        public List<ObjetoProducto> tablaDetalleVenta(int idProducto)
        {
            return Acceso.tablaDetalleVenta(idProducto);
        }


        public RespuestaModel eliminarReceta(ObjetoReceta receta)
        {
            return Acceso.eliminarReceta(receta);
        }
    }
}
