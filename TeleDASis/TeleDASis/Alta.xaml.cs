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
using System.Text.RegularExpressions;
namespace TeleDASis
{

    /// <summary>
    /// Interaction logic for Alta.xaml
    /// </summary>
    public partial class Alta : Window
    {
        Usuario user = new Usuario();
        


        public Alta()
        {
            InitializeComponent();
            tbFechaDeAlta.SelectedDate = DateTime.Today;
        }


        private void btAccept_Click(object sender, RoutedEventArgs e)
        {
            user.nombre = tbNombre.Text;
            user.primerApellido = tbApellido.Text;
            user.segundoApellido = tbApellido2.Text;
            user.dni = tbDni.Text;
            user.telefono = int.Parse(tbTelefono.Text);
            user.telefonofamiliar = int.Parse(tbFamiliar.Text);
            user.tlfmovil = int.Parse(tbMovil.Text);
            user.tarjetasanitaria = tbTargetaSanitaria.Text;
            user.poblacion = tbPoblacion.Text;
            user.direccion = tbDireccion.Text;
            user.puerta = tbPuerta.Text;

            if (string.IsNullOrEmpty(user.nombre) || string.IsNullOrEmpty(user.primerApellido) || string.IsNullOrEmpty(user.segundoApellido) || string.IsNullOrEmpty(user.dni) ||
                string.IsNullOrEmpty(user.telefono.ToString()) || string.IsNullOrEmpty(user.telefonofamiliar.ToString()) || string.IsNullOrEmpty(user.tlfmovil.ToString()) || string.IsNullOrEmpty(user.tarjetasanitaria)
                || string.IsNullOrEmpty(user.poblacion) || string.IsNullOrEmpty(user.direccion) || string.IsNullOrEmpty(user.puerta))
            {
                MessageBox.Show("¡Debes rellenar todos los campos!", "Campos vacíos", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (Validaciones.validarNIF(user.dni) == false)
                {
                    MessageBox.Show("El DNI " + user.dni + " es incorrecto. Vuelve a introducirlo.","DNI incorrecto",MessageBoxButton.OK,MessageBoxImage.Error);
                }
                else
                {
                    if (databaseConnector.instance.ifExistDontCreateNewUser(user.dni))
                    {
                         MessageBox.Show("Ya existe un usuario con ese DNI");
                    }
                    else
                    {            
                        if (databaseConnector.instance.addUser(user) == true)
                        {
                            MessageBox.Show("¡Se ha introducido a " + user.nombre + " con éxito!", "Usuario añadido", MessageBoxButton.OK, MessageBoxImage.Information);
                            Limpiar();
                        }
                        else
                        {
                            MessageBox.Show("No se ha podido añadir a " + user.nombre + " correctamente, comprueba todos los campos.", "Fallo al añadir usuario", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
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

             this.Close();
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
        public void SoloLetras(TextCompositionEventArgs e)
        {
            //se convierte a Ascci del la tecla presionada 
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            //verificamos que se encuentre en ese rango que son entre el a y el z
            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122)
                e.Handled = false;
            else e.Handled = true;
        }
        private void Letras(object sender, TextCompositionEventArgs e)
        {
            SoloLetras(e);
        }
      
        public void Limpiar()
        {
            tbApellido.Clear();
            tbApellido2.Clear();
            tbDireccion.Clear();
            tbDni.Clear();
            tbFamiliar.Clear();
            tbMovil.Clear();
            tbNombre.Clear();
            tbPoblacion.Clear();
            tbPuerta.Clear();
            tbTargetaSanitaria.Clear();
            tbTelefono.Clear();
        }
    }
       
}


        
    

