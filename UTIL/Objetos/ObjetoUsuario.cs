using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTIL.Objetos
{
    public class ObjetoUsuario
    {
        private int _IdUsuario;
        private string _Usuario;
        private string _Contrasena;
        private string _Email;
        private int _Perfil;
        private string _Nombre;
        private int _Estado;
        private bool _Verificador;

        public int IdUsuario { get => _IdUsuario; set => _IdUsuario = value; }
        public string Usuario { get => _Usuario; set => _Usuario = value; }
        public string Contrasena { get => _Contrasena; set => _Contrasena = value; }
        public string Email { get => _Email; set => _Email = value; }
        public int Perfil { get => _Perfil; set => _Perfil = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public int Estado { get => _Estado; set => _Estado = value; }
        public bool Verificador { get => _Verificador; set => _Verificador = value; }
    }
}
