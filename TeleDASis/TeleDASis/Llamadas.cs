using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleDASis
{
    class Llamadas
    {
        public int idLlamadas { get; set; }
        public int telefonoUsuario { get; set; }
        public DateTime fechayHora { get; set; }
        public string solucion { get; set; }
        public int empleado_idEmpleado { get; set; }
        public int usuarios_idUsuario { get; set; }
        public int motivo_idMotivo { get; set; }
        public int servicio { get; set; }
        public string descripcion { get; set; }

        public Llamadas() { }

        public Llamadas(int telefonoUsuario,DateTime fechayHora , string solucion,
                        int empleado_idEmpleado,int usuarios_idUsuario,int motivo_idMotivo,
                        string descripcion, int servicio)
        {
            this.telefonoUsuario = telefonoUsuario;
            this.fechayHora = fechayHora;
            this.solucion = solucion;
            this.empleado_idEmpleado = empleado_idEmpleado;
            this.usuarios_idUsuario = usuarios_idUsuario;
            this.motivo_idMotivo = motivo_idMotivo;
            this.descripcion = descripcion;
            this.servicio = servicio;
        }

    }
}
