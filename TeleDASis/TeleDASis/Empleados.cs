using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleDASis
{
    class Empleados
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string nombreUsuario { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public int tlfmovil { get; set; }
        public string dni { get; set; }
        public string fechaAlta { get; set; }
        public string fechaBaja { get; set; }
        public string motivodeBaja { get; set; }
        public Empleados(string nombre, string nombreUsuario,int movil, string dni, string fechaDeAlta, string apellido, string apellido2)
        {
            this.nombre = nombre;
            this.nombreUsuario = nombreUsuario;
            this.tlfmovil = movil;
            this.dni = dni;
            this.fechaAlta = fechaDeAlta;
            this.primerApellido = apellido;
            this.segundoApellido = apellido2;

        }
    }
}
