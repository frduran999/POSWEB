using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTIL.Objetos
{
    public class ObjetoMesa
    {
        private int _id;
        private int _numero;
        private string _tipo;//Externa o Interna
        private int _estado;

        public int Id { get => _id; set => _id = value; }
        public int Numero { get => _numero; set => _numero = value; }
        public string Tipo { get => _tipo; set => _tipo = value; }
        public int Estado { get => _estado; set => _estado = value; }
    }
}
