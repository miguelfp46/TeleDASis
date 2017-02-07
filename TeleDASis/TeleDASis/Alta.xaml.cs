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
            //if (nombre == "" || apellido == "" || apellido2 == "" || dni == "" ||
            //    nTelefono == "" || nTelefonoFamiliar == "" || movil == "" || targetaSanitaria == ""
            //    || vivienda == 0)
            //{
            //    MessageBox.Show("¡Debes rellenar todos los campos!", "Campos vacíos", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
            //else
            //{
            //    if (databaseConnector.instance.addUser(nombre, apellido, apellido2, dni, nTelefono,
            //    nTelefonoFamiliar, movil, targetaSanitaria, fechaDeAlta, vivienda) == true)
            //    {
            //        MessageBox.Show("Se ha introducido a " + nombre + " con éxito", "Usuario añadido", MessageBoxButton.OK, MessageBoxImage.Information);
            //        this.Close();
            //    }
            //    else
            //    {
            //        MessageBox.Show("No se ha podido añadir a " + nombre + " correctamente.", "Fallo al añadir usuario", MessageBoxButton.OK, MessageBoxImage.Error);
            //    }
            //}
            dni = "";
            MessageBox.Show(Validaciones.validarNIF(dni)?"1":"0");
            
            
            
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
        
    }
       
}


        
    

