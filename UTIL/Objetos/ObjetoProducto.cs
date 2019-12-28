using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTIL.Objetos
{
    public class ObjetoProducto
    {
        private int _IdProducto;
        private string _Producto;
        private int _IdFamilia;
        private string _UnidadMedida;
        private int _Estado;
        private string _Familia;
        private double _Precio;
        private int _IdReceta;

        public int IdProducto { get => _IdProducto; set => _IdProducto = value; }
        public string Producto { get => _Producto; set => _Producto = value; }
        public int IdFamilia { get => _IdFamilia; set => _IdFamilia = value; }
        public string UnidadMedida { get => _UnidadMedida; set => _UnidadMedida = value; }
        public int Estado { get => _Estado; set => _Estado = value; }
        public string Familia { get => _Familia; set => _Familia = value; }
        public double Precio { get => _Precio; set => _Precio = value; }
        public int IdReceta { get => _IdReceta; set => _IdReceta = value; }
    }
}
