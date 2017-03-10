using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleDASis
{
    class Agenda
    {
        public int idAgenda { get; set; }
        public int idLlamada { get; set; }
        public int idUsuarios { get; set; }
        public string fechaAgenda { get; set; }
        public string nombreUsuario { get; set; }
        public Agenda() { }

        public Agenda(int idAgenda,int idLlamada, int idUsuarios,
                        string fechaAgenda,string nombreUsuario)
        {
            this.idAgenda = idAgenda;
            this.idLlamada = idLlamada;
            this.idUsuarios = idUsuarios;
            this.fechaAgenda = fechaAgenda;
            this.nombreUsuario = nombreUsuario;
        }
    }
    

}
