using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTIL.Objetos
{
    public class ObjetoReceta
    {
        private int _IdReceta;
        private string _Nombre;
        private int _IdProducto;
        private int _Cantidad;
        private int _Estado;

        public int IdReceta { get => _IdReceta; set => _IdReceta = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public int IdProducto { get => _IdProducto; set => _IdProducto = value; }
        public int Cantidad { get => _Cantidad; set => _Cantidad = value; }
        public int Estado { get => _Estado; set => _Estado = value; }
    }
}
