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
    /// Interaction logic for Modificación_Empleados.xaml
    /// </summary>
    public partial class Modificación_Empleados : Window
    {

        string dni;
        Empleados emp = new Empleados();

        public Modificación_Empleados()
        {
            InitializeComponent();
            tbFecha.SelectedDate = DateTime.Today;
            tbNombre.IsEnabled = false;
            tbApellido.IsEnabled = false;
            tbApellido2.IsEnabled = false;
            tbMovil.IsEnabled = false;
            tbTelefono.IsEnabled = false;
            tbpaswd.IsEnabled = false;
            tbUser.IsEnabled = false;
          
        }

        private void btComprobar_Click(object sender, RoutedEventArgs e)
        {
            dni = tbDNI.Text;
            Empleados emp = databaseConnector.instance.showEmpAll(dni);
            if (emp.nombre == null)
            {
                MessageBox.Show("No se ha encontrado al empleado con el DNI: " + emp.dni + ".\nVerifica que sea correcto.", "¡DNI incorrecto!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                tbNombre.IsEnabled = true;
                tbApellido.IsEnabled = true;
                tbApellido2.IsEnabled = true;
                tbMovil.IsEnabled = true;
                tbTelefono.IsEnabled = true;
                tbpaswd.IsEnabled = true;
                tbUser.IsEnabled = true;
               

                tbNombre.Text = emp.nombre;
                tbApellido.Text = emp.primerApellido;
                tbApellido2.Text = emp.segundoApellido;
               
                tbMovil.Text = Convert.ToString(emp.tlfmovil);
                tbTelefono.Text = Convert.ToString(emp.telefono);
                tbpaswd.Password = emp.password;
                tbUser.Text = emp.nombreUsuario;
                
            }

        }

        private void cancel(object sender, RoutedEventArgs e)
        {
            MessageBoxResult salir = MessageBox.Show("¿Seguro que quieres salir?", "Salir", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (salir == MessageBoxResult.Yes)
            {
                this.Close();
            }

        }

        public void SoloNumeros(TextCompositionEventArgs e)
        {
            //se convierte a Ascci del la tecla presionada 
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            //verificamos que se encuentre en ese rango que son entre el 0 y el 9 
            if (ascci >= 48 && ascci <= 57)
                e.Handled = false;
            else e.Handled = true;
        }

        private void tbMovil_PreviewTextInput(object sender, TextCompositionEventArgs e)
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
        //metodo guardar
        private void Guardar(object sender, RoutedEventArgs e)
        {
            emp.nombre = tbNombre.Text;
            emp.primerApellido = tbApellido.Text;
            emp.segundoApellido = tbApellido2.Text;   
            emp.tlfmovil = Convert.ToInt32(tbMovil.Text);
            emp.telefono = Convert.ToInt32(tbTelefono.Text);        
            emp.password = tbpaswd.Password;
            emp.nombreUsuario = tbUser.Text;
            emp.dni = tbDNI.Text;

            if (string.IsNullOrEmpty(emp.nombre) || string.IsNullOrEmpty(emp.primerApellido) || string.IsNullOrEmpty(emp.segundoApellido) || string.IsNullOrEmpty(emp.dni) ||
                string.IsNullOrEmpty(Convert.ToString(emp.telefono)) || string.IsNullOrEmpty(Convert.ToString(emp.tlfmovil)) || string.IsNullOrEmpty(emp.password) || string.IsNullOrEmpty(emp.nombreUsuario))
            {
                MessageBox.Show("¡Debes rellenar todos los campos!", "Campos vacíos", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (databaseConnector.instance.updateEmp(emp) == true)
                {
                    MessageBox.Show("Empleado " + emp.nombre + " actualizado correctamente.", "Actualizar usuario", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("No se ha podido actualizar el usuario.", "Fallo al actualizar", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        }
}
