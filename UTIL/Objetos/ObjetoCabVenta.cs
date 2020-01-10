using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTIL.Objetos
{
    public class ObjetoCabVenta
    {
        private int _IdCabecera;
        private int _NumMesa;
        private int _IdGarzon;
        private int _Total;
        private string _Propina;

        public int IdCabecera { get => _IdCabecera; set => _IdCabecera = value; }
        public int NumMesa { get => _NumMesa; set => _NumMesa = value; }
        public int IdGarzon { get => _IdGarzon; set => _IdGarzon = value; }
        public int Total { get => _Total; set => _Total = value; }
        public string Propina { get => _Propina; set => _Propina = value; }
    }
}
