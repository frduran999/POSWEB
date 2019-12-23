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
    }
}
