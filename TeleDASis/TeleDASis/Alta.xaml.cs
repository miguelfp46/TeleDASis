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
            //tbFechaDeAlta.SelectedDate = DateTime.Today;
        }

        /// <summary>
        /// Este metodo dara de alta a los usuarios
        /// </summary>
        /// <param name="nombre">Valor que le asignamos para obtener el nombre del usuario</param>
        /// <param name="primerApellido">Valor que le asignamos para obtener el primer apellido del usuario</param>
        /// <param name="segundoApellido">Valor que le asignamos para obtener el segundo apellido del usuario</param>
        /// <param name="tarjetaSanitaria">Valor que le asignamos para obtener la tarjeta sanitaria del usuario</param>
        /// <param name="tlfmovil">Valor que le asignamos para obtener el movil del usuario</param>
        /// <param name="telefono">Valor que le asignamos para obtener el telefono del usuario</param>
        /// <param name="telefonofamiliar">Valor que le asignamos para obtener el telefono familiar del usuario</param>
        /// <param name="dni">Valor que le asignamos para obtener el dni del usuario</param>
        /// <param name="poblacion">Valor que le asignamos para obtener la poblacion del usuario</param>
        /// <param name="direccion">Valor que le asignamos para obtener la direccion del usuario </param>
        ///  <param name="puerta">Valor que le asignamos para obtener la puerta del usuario</param>
        private void btAccept_Click(object sender, RoutedEventArgs e)
        {
            user.nombre = tbNombre.Text;
            user.primerApellido = tbApellido.Text;
            user.segundoApellido = tbApellido2.Text;
            user.dni = tbDni.Text;
            user.telefono = tbTelefono.Text;
            user.telefonofamiliar = tbFamiliar.Text;
            user.tlfmovil = tbMovil.Text;
            user.tarjetaSanitaria = tbTargetaSanitaria.Text;
            user.poblacion = tbPoblacion.Text;
            user.direccion = tbDireccion.Text;
            user.puerta = tbPuerta.Text;

            if (string.IsNullOrEmpty(user.nombre) || string.IsNullOrEmpty(user.primerApellido) || string.IsNullOrEmpty(user.segundoApellido) || string.IsNullOrEmpty(user.dni) ||
                string.IsNullOrEmpty(user.telefono.ToString()) || string.IsNullOrEmpty(user.telefonofamiliar.ToString()) || string.IsNullOrEmpty(user.tlfmovil.ToString()) || string.IsNullOrEmpty(user.tarjetaSanitaria)
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

        /// <summary>
        /// Este metodo te muestra la fecha actual
        /// </summary>
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

        /// <summary>
        /// Al hacer click en el boton CANCELAR te saltara un aviso antes de poder cerrar la ventana
        /// </summary>
        

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Estas seguro que quieres cancelar esta operación?", "Alta",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);

             this.Close();
        }

        /// <summary>
        /// Este metodo restringe que tipo de caracteres puedes escribir, en este caso solo puedes escribir numeros
        /// </summary>
        /// <param name="ascci">Valor que le asignamos para obtener un int</param>
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

        /// <summary>
        /// Este metodo restringe que tipo de caracteres puedes escribir, en este caso solo puedes escribir letas
        /// </summary>
        /// <param name="ascci">Valor que le asignamos para obtener un int</param>
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


        
    

