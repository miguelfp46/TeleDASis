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
        public String nombre { get; set; }
        public String apellidos { get; set; }
        public int telefono { get; set; }
        public int telefonofamiliar { get; set; }
        public int tlfmovil { get; set; }
        public String tarjetasanitaria { get; set; }
        public String dni { get; set; }
        public String vivienda { get; set;}
        public DateTime fechaentrada { get; set; }
        public Boolean Baja { get; set; }// Para ver si esta de baja o no
        public DateTime fechabaja { get; set; }
        public String motivodeBaja { get; set; }
        public String EmpleadohaceBaja { get; set; }//relacionado con bbdd empleados modificar tipo por objeto
        

    }
}
