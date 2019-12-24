using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTIL.Objetos
{
    public class ObjetoPerfil
    {
        private int _Id;
        private string _Descripcion;

        public int Id { get => _Id; set => _Id = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
    }
}
