using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTIL.Objetos
{
    public class ObjetoFamilia
    {
        private int _IdFamilia;
        private string _Familia;
        private int _Estado;
        private string _Impresora;

        public int IdFamilia { get => _IdFamilia; set => _IdFamilia = value; }
        public string Familia { get => _Familia; set => _Familia = value; }
        public int Estado { get => _Estado; set => _Estado = value; }
        public string Impresora { get => _Impresora; set => _Impresora = value; }
    }
}
