using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTIL.Objetos
{
    public class ObjetoEmpleado
    {
        private int _idEmpleado;
        private string _nombre;
        private string _cargo;
        private int _estado;

        public int IdEmpleado { get => _idEmpleado; set => _idEmpleado = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Cargo { get => _cargo; set => _cargo = value; }
        public int Estado { get => _estado; set => _estado = value; }
    }
}
