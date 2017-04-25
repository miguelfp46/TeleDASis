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
using TeleDASis;

namespace TeleDASis
{
    /// <summary>
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        Empleados emp = new Empleados();
        public Window3()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Este metodo dara de alta a los empleados
        /// </summary>
        /// <param name="nombre">Valor que le asignamos para obtener el nombre del empleado</param>
        /// <param name="primerApellido">Valor que le asignamos para obtener el primer apellido del empleado</param>
        /// <param name="segundoApellido">Valor que le asignamos para obtener el segundo apellido del empleado</param>
        /// <param name="tlfmovil">Valor que le asignamos para obtener el movil del empleado</param>
        /// <param name="telefono">Valor que le asignamos para obtener el telefono del empleado</param>
        /// <param name="dni">Valor que le asignamos para obtener el dni del empleado</param>
        /// <param name="nombreUsuario">Valor que le asignamos para obtener el nombre de usuario del empleado</param>
        /// <param name="password">Valor que le asignamos para obtener la pasword del empleado</param>
        private void btAccept_Click(object sender, RoutedEventArgs e)
        {
            emp.nombre = tbNombre.Text;
            emp.tlfmovil = tbMovil.Text;
            emp.dni = tbDni.Text;
            emp.primerApellido = tbApellido.Text;
            emp.segundoApellido = tbApellido2.Text;
            emp.nombreUsuario = tbuser.Text;
            emp.passwd = databaseConnector.instance.sha256(passwordBox.Password);
            emp.rol = tbuser_Copy.Text;

            if (string.IsNullOrEmpty(emp.nombre) || string.IsNullOrEmpty(emp.tlfmovil.ToString()) || string.IsNullOrEmpty(emp.dni) || string.IsNullOrEmpty(emp.primerApellido) ||
                string.IsNullOrEmpty(emp.segundoApellido) || string.IsNullOrEmpty(emp.nombreUsuario)
                || string.IsNullOrEmpty(emp.passwd))
            {
                MessageBox.Show("¡Debes rellenar todos los campos!", "Campos vacíos", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {//llamada al metodo de validar dni del empleado , si no es real mensaje de error , si es autentico sigue leyendo
                if (Validaciones.validarNIF(emp.dni) == false)
                {
                    MessageBox.Show("El DNI " + emp.dni + " es incorrecto. Vuelve a introducirlo.", "DNI incorrecto", MessageBoxButton.OK, MessageBoxImage.Error);
                }else
                {//si el dni del empleado ya existe , salta mensaje de error 
                    if (databaseConnector.instance.ifExistDontCreateNewEmpleado(emp.dni))
                    {
                        MessageBox.Show("Ya existe un empleado con ese DNI");
                    }else
                    {//añadimos el empleado si la condicion es cierta , sino salta mensaje de error
                        if(databaseConnector.instance.addEmple(emp) == true)
                        {
                            MessageBox.Show("¡Se ha introducido a " + emp.nombre + " con éxito!", "Empleado añadido", MessageBoxButton.OK, MessageBoxImage.Information);
                        }else
                        {
                            MessageBox.Show("No se ha podido añadir a " + emp.nombre + " correctamente, comprueba todos los campos.", "Fallo al añadir empleado", MessageBoxButton.OK, MessageBoxImage.Error);
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


    }
}
