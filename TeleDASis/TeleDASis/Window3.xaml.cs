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
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        Empleados emp = new Empleados();
        public Window3()
        {
            InitializeComponent();
        }

        private void btAccept_Click(object sender, RoutedEventArgs e)
        {
            emp.nombre = tbNombre.Text;
            emp.tlfmovil = Convert.ToInt32(tbMovil.Text);
            emp.dni = tbDni.Text;
            emp.primerApellido = tbApellido.Text;
            emp.segundoApellido = tbApellido2.Text;
            emp.nombreUsuario = tbuser.Text;
            emp.password = passwordBox.Password;

            if (string.IsNullOrEmpty(emp.nombre) || string.IsNullOrEmpty(emp.tlfmovil.ToString()) || string.IsNullOrEmpty(emp.dni) || string.IsNullOrEmpty(emp.primerApellido) ||
                string.IsNullOrEmpty(emp.segundoApellido) || string.IsNullOrEmpty(emp.nombreUsuario)
                || string.IsNullOrEmpty(emp.password))
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
    }
}
