using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTIL.Objetos
{
    public class ObjetoMenu
    {
        private int _IdMenu;
        private string _Clase;
        private string _PieMenu;
        private string _Titulo;
        private string _Action;
        private string _Controller;
        private string _TipoUsuario;
        private int _Activo;
        private int _Orden;

        public int IdMenu { get => _IdMenu; set => _IdMenu = value; }
        public string Clase { get => _Clase; set => _Clase = value; }
        public string PieMenu { get => _PieMenu; set => _PieMenu = value; }
        public string Titulo { get => _Titulo; set => _Titulo = value; }
        public string Action { get => _Action; set => _Action = value; }
        public string Controller { get => _Controller; set => _Controller = value; }
        public string TipoUsuario { get => _TipoUsuario; set => _TipoUsuario = value; }
        public int Activo { get => _Activo; set => _Activo = value; }
        public int Orden { get => _Orden; set => _Orden = value; }
    }
}
