using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TeleDASis
{
    class Validaciones
    {
        /// <summary> Tabla de asignación. </summary>
        public const string CORRESPONDENCIA = "TRWAGMYFPDXBNJZSQVHLCKE";
        
        /// Genera la letra correspondiente a un DNI.
        /// <param name="dni"> DNI a procesar. </param>
        /// <returns> Letra correspondiente al DNI. </returns>
        static public char LetraNIF(string dni)
        {
            Match match = new Regex(@"\b(\d{8})\b").Match(dni);
            if (match.Success)
                return CORRESPONDENCIA[int.Parse(dni) % 23];
            else
                throw new ArgumentException("El DNI debe contener 8 dígitos.");
        }    }
}
