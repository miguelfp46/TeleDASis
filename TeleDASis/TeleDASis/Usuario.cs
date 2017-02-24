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
        public int telefono { get; set; }
        public int telefonofamiliar { get; set; }
        public int tlfmovil { get; set; }
        public string tarjetasanitaria { get; set; }
        public string dni { get; set; }
        public string vivienda { get; set;}
        public string poblacion { get; set; }
        public string direccion { get; set; }
        public string puerta { get; set; }
        public DateTime fechaentrada { get; set; }
        public Boolean Baja { get; set; }// Para ver si esta de baja o no
        public DateTime fechabaja { get; set; }
        public string motivodeBaja { get; set; }
        public string EmpleadohaceBaja { get; set; }//relacionado con bbdd empleados modificar tipo por objeto

		public Usuario() { }
		public Usuario(string nombre, string targetaSanitaria, int movil, int nTelefono, string dni,
				int nTelefonoFamiliar, DateTime fechaDeAlta, string apellido, string apellido2,string poblacion, string direccion,string puerta)
		{
			this.nombre = nombre;
			this.tarjetasanitaria = tarjetasanitaria;
			this.tlfmovil = movil;
			this.telefono = nTelefono;
			this.telefonofamiliar = nTelefonoFamiliar;
			this.dni = dni;
			this.fechaentrada = fechaDeAlta;
			this.primerApellido = apellido;
			this.segundoApellido = apellido2;
            this.poblacion = poblacion;
            this.direccion = direccion;
            this.puerta = puerta;	
		}
    }
}
