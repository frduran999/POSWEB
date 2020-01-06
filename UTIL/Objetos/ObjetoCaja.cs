using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTIL.Objetos
{
    public class ObjetoCaja
    {
        private int _idCaja;
        private string _accion;
        private int _idUsuario;
        private int _monto;
        private DateTime _fecha;
        private string _glosa;
        private string _fechaCierre;
        private int _idSucursal;

        public int IdCaja { get => _idCaja; set => _idCaja = value; }
        public string Accion { get => _accion; set => _accion = value; }
        public int IdUsuario { get => _idUsuario; set => _idUsuario = value; }
        public int Monto { get => _monto; set => _monto = value; }
        public DateTime Fecha { get => _fecha; set => _fecha = value; }
        public string Glosa { get => _glosa; set => _glosa = value; }
        public string FechaCierre { get => _fechaCierre; set => _fechaCierre = value; }
        public int IdSucursal { get => _idSucursal; set => _idSucursal = value; }
    }
}
