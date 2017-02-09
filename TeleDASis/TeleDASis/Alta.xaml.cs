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
        string nombre;
        string apellido;
        string apellido2;
        string dni;
        string nTelefono;
        string nTelefonoFamiliar;
        string movil;
        string targetaSanitaria;
        string fechaDeAlta;
        int vivienda = 0;


        public Alta()
        {
            InitializeComponent();
            tbFechaDeAlta.SelectedDate = DateTime.Today;
        }


        private void btAccept_Click(object sender, RoutedEventArgs e)
        {
            nombre = tbNombre.Text;
            apellido = tbApellido.Text;
            apellido2 = tbApellido2.Text;
            dni = tbDni.Text;
            nTelefono = tbTelefono.Text;
            nTelefonoFamiliar = tbFamiliar.Text;
            movil = tbMovil.Text;
            targetaSanitaria = tbTargetaSanitaria.Text;
            DateTime dt = tbFechaDeAlta.DisplayDate;
            fechaDeAlta = dt.ToString("yyyy/MM/dd");
            if(tbVivienda.Text == "")
            {
                tbVivienda.Text = "0";
            }
            vivienda = int.Parse(tbVivienda.Text);

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) || string.IsNullOrEmpty(apellido2) || string.IsNullOrEmpty(dni) ||
                string.IsNullOrEmpty(nTelefono) || string.IsNullOrEmpty(nTelefonoFamiliar) || string.IsNullOrEmpty(movil) || string.IsNullOrEmpty(targetaSanitaria)
                || string.IsNullOrEmpty(Convert.ToString(vivienda)))
            {
                MessageBox.Show("¡Debes rellenar todos los campos!", "Campos vacíos", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (Validaciones.validarNIF(dni) == false)
                {
                    MessageBox.Show("El DNI " + dni + " es incorrecto. Vuelve a introducirlo.");
                }
                else if (databaseConnector.instance.addUser(nombre, targetaSanitaria, movil, nTelefono, dni,
                nTelefonoFamiliar, fechaDeAlta, apellido, apellido2, vivienda) == true)
                {
                    MessageBox.Show("Se ha introducido a " + nombre + " con éxito", "Usuario añadido", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se ha podido añadir a " + nombre + " correctamente.", "Fallo al añadir usuario", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }                          
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
        //metodo para añadir solo numeros
        public void SoloNumeros(TextCompositionEventArgs e)
        {
            //se convierte a Ascci del la tecla presionada 
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            //verificamos que se encuentre en ese rango que son entre el 0 y el 9 
            if (ascci >= 48 && ascci <= 57)
                e.Handled = false;
            else e.Handled = true;
        }
        private void tbTelefono_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            SoloNumeros(e);
        }
       
        
    }
       
}


        
    

