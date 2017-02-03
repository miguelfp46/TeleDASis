using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TeleDASis
{

    /// <summary>
    /// Interaction logic for Alta.xaml
    /// </summary>
    public partial class Alta : Window
    {
        String nombre;
        String apellido;
        String apellido2;
        String dni;
        String nTelefono;
        String nTelefonoFamiliar;
        String movil;
        String targetaSanitaria;
        String fechaDeAlta;
        int vivienda = 0;


        public Alta()
        {
            InitializeComponent();
            tbFechaDeAlta.SelectedDate = DateTime.Today;
        }


        private void btAccept_Click(object sender, RoutedEventArgs e)
        {
            VerificarDni(dni);
            //nombre = tbNombre.Text;
            //apellido = tbApellido.Text;
            //apellido2 = tbApellido2.Text;
            //dni = tbDni.Text;
            //nTelefono = tbTelefono.Text;
            //nTelefonoFamiliar = tbFamiliar.Text;
            //movil = tbMovil.Text;
            //targetaSanitaria = tbTargetaSanitaria.Text;
            //DateTime dt = tbFechaDeAlta.DisplayDate;
            //fechaDeAlta = dt.ToString("yyyy/MM/dd");
            //vivienda = int.Parse(tbVivienda.Text);
            //databaseConnector.instance.addUser(nombre, apellido, apellido2, dni, nTelefono,
            //    nTelefonoFamiliar, movil, targetaSanitaria, fechaDeAlta, vivienda);
            //this.Close();
        }
        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var picker = sender as DatePicker;
            DateTime? date = picker.SelectedDate;

            if (date == null)
            {
                this.Title = "No date";
            }
            else
            {
                this.Title = date.Value.ToShortDateString();
            }
        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Estas seguro que quieres cancelar esta operación?", "Alta",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);

            // this.Close();
        }
        public Boolean VerificarDni(string dni)
        {
            String aux = null;
            dni = dni.ToUpper();

            //ponemos la letra en mayuscula
            aux = dni.Substring(0, dni.Length - 1);
            //quitamos la letra del NIF
            if (aux.Length >= 7 && this.CadenaEsNumero(aux))
                aux = this.CalculaNif(aux);//calculamos la letra del nif para comparar con la que tenemos
            else
                return false;
            //comparamos las letras
            return (dni != aux);
        }

        private bool CadenaEsNumero(string aux)
        {
            for(int i = 0; i > 10; i++)
            {
                if (aux.Contains(i.ToString()))
                {
                    return true;
                }
                else
                    return false;
            }
            
            throw new NotImplementedException();
        }

        private String CalculaNif(String strA)
        {
            const String cCADENA = "TRWAGMYFPDXBNJZSQVHLCKE";
            const String cNUMEROS = "0123456789";
            Int32 a = 0;
            Int32 b = 0;
            Int32 c = 0;
            Int32 NIF = 0;
            StringBuilder sb = new StringBuilder();

            strA = strA.Trim();
            if (strA.Length == 0) return "";

            //dejar sólo los números
            for (int i = 0; i <= strA.Length - 1; i++)
                if (cNUMEROS.IndexOf(strA[i]) > -1) sb.Append(strA[i]);
            strA = sb.ToString();
            a = 0;
            NIF = Convert.ToInt32(strA);
            do
            {
                b = Convert.ToInt32((NIF / 24));
                c = NIF - (24 * b);
                a = a + c;
                NIF = b;
            } while (b != 0);

            b = Convert.ToInt32((a / 23));
            c = a - (23 * b);
            return strA.ToString() + cCADENA.Substring(c, 1);
        }
    }
       
}


        
    

