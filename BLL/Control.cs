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
        
        public List<ObjetoFamilia> ListadoFamilia()
        {
            return Acceso.ListadoFamilia();
        }

        public List<ObjetoProducto> ListadoProductos()
        {
            return Acceso.ListadoProductos();
        }

        public List<ObjetoPerfil> ListadoPerfil()
        {
            return Acceso.ListadoPerfil();
        }

        public int AgregarFamilia(string Familia, string Impresora)
        {
            return Acceso.AgregarFamilia(Familia, Impresora);
        }

        public List<ObjetoFamilia> ObtenerFamilia(string IdFamilia)
        {
            return Acceso.ObtenerFamilia(IdFamilia);
        }

        public RespuestaModel EliminarFamilia(ObjetoFamilia Familia)
        {
            return Acceso.EliminarFamilia(Familia);
        }
    }
}
