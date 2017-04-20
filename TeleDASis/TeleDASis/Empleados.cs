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
        public string passwd { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public string tlfmovil { get; set; }
        public string rol { get; set; }
        public string dni { get; set; }
        public string fechaAlta { get; set; }
        public string fechaBaja { get; set; }
        public string motivodeBaja { get; set; }

        public Empleados(string nombre, string nombreUsuario, string passwd, string movil, string rol, string dni, string fechaDeAlta, string apellido, string apellido2)
        {
            this.nombre = nombre;
            this.nombreUsuario = nombreUsuario;
            this.passwd = passwd;
            this.tlfmovil = movil;
            this.rol = rol;
            this.dni = dni;
            this.fechaAlta = fechaDeAlta;
            this.primerApellido = apellido;
            this.segundoApellido = apellido2;

        }

        public Empleados()
        {
        }
    }
}
