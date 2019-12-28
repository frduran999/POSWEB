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

       public ObjetoUsuario LoginUsuario(ObjetoUsuario usuario)
        {
            return Acceso.LoginUsuario(usuario);
        }

        public List<ObjetoMenu> MenuUsuario(int Perfil)
        {
            return Acceso.MenuUsuario(Perfil);
        }
        
        public List<ObjetoProducto> ListadoProductos()
        {
            return Acceso.ListadoProductos();
        }

        public List<ObjetoReceta> ListadoReceta()
        {
            return Acceso.ListadoReceta();
        }

        public int AgregarProducto(ObjetoProducto producto)
        {
            return Acceso.AgregarProducto(producto);
        }

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
    }
}
