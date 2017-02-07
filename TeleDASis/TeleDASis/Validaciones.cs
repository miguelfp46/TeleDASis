using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace TeleDASis
{
    class Validaciones
    {
        /// <summary> Tabla de asignación. </summary>
        public const string CORRESPONDENCIA = "TRWAGMYFPDXBNJZSQVHLCKE";
        /// Genera la letra correspondiente a un DNI.
        /// <param name="dni"> DNI a procesar. </param>
        /// <returns> Letra correspondiente al DNI. </returns>
        public static char LetraNIF(string dni)
        {
            Match match = new Regex(@"\b(\d{8})\b").Match(dni);
            if (match.Success)
                return CORRESPONDENCIA[int.Parse(dni) % 23];
            else
            {

                MessageBox.Show("El DNI debe contener 8 digitos y 1 letra.\nPor ejemplo: 12345678X","DNI incorrecto",MessageBoxButton.OK,MessageBoxImage.Error);
                return ' ';
            }
                
        }
        public static bool validarNIF(string dni)
        {
            dni = dni.ToUpper();
            string aux = "";
            char letra = ' ';
            if (dni.Length == 9)
            {
                aux = dni.Substring(dni.Length - 1, 1);
                letra = LetraNIF(dni.Substring(0, 8));
                return (char.Parse(aux) == letra);
            }
            return false;
            
        } 
    }
}
