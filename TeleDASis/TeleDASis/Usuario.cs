using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleDASis
{
    class Usuario
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public string telefono { get; set; }
        public string telefonofamiliar { get; set; }
        public string tlfmovil { get; set; }
        public string tarjetaSanitaria { get; set; }
        public string dni { get; set; }
        public string vivienda { get; set;}
        public string poblacion { get; set; }
        public string direccion { get; set; }
        public string puerta { get; set; }
        public string fechaAlta { get; set; }
        public bool Baja { get; set; }// Para ver si esta de baja o no
        public string fechaBaja { get; set; }
        public string motivodeBaja { get; set; }
        public string EmpleadohaceBaja { get; set; }//relacionado con bbdd empleados modificar tipo por objeto

		public Usuario() { }
		public Usuario(string nombre, string targetaSanitaria, string movil, string nTelefono, string dni,
				string nTelefonoFamiliar, string fechaDeAlta, string apellido, string apellido2,string poblacion, string direccion,string puerta)
		{
			this.nombre = nombre;
			this.tarjetaSanitaria = tarjetaSanitaria;
			this.tlfmovil = movil;
			this.telefono = nTelefono;
			this.telefonofamiliar = nTelefonoFamiliar;
			this.dni = dni;
			this.fechaAlta = fechaDeAlta;
			this.primerApellido = apellido;
			this.segundoApellido = apellido2;
            this.poblacion = poblacion;
            this.direccion = direccion;
            this.puerta = puerta;	
		}
    }
}
