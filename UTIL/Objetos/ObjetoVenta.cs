using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTIL.Objetos
{
    public class ObjetoVenta
    {
        private int _IdProducto;
        private int _Cantidad;
        private int _Linea;
        private string _Desc;
        private int _TotalLinea;
        private int _IdFamilia;
        private int _Precio;
        private int _IdReceta;
        private int _IdCab;

        public int IdProducto { get => _IdProducto; set => _IdProducto = value; }
        public int Cantidad { get => _Cantidad; set => _Cantidad = value; }
        public int Linea { get => _Linea; set => _Linea = value; }
        public string Desc { get => _Desc; set => _Desc = value; }
        public int TotalLinea { get => _TotalLinea; set => _TotalLinea = value; }
        public int IdFamilia { get => _IdFamilia; set => _IdFamilia = value; }
        public int Precio { get => _Precio; set => _Precio = value; }
        public int IdReceta { get => _IdReceta; set => _IdReceta = value; }
        public int IdCab { get => _IdCab; set => _IdCab = value; }
    }
}
