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
            cbRol.IsEnabled = false;
            tbUser.IsEnabled = false; 
        }

        /// <summary>
        /// Este metodo se encarga de comprobar si los datos introducidos son correctos, de no serlo lanzara un mensaje de aviso
        /// </summary>
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
                cbRol.IsEnabled = true;
                
                tbUser.IsEnabled = true;
               //ybvt4cre

                tbNombre.Text = emp.nombre;
                tbApellido.Text = emp.primerApellido;
                tbApellido2.Text = emp.segundoApellido;
                tbMovil.Text = emp.tlfmovil;
                switch (emp.rol)
                {
                    case "1":
                        cbRol.SelectedIndex = 0;
                        break;
                    case "2":
                        cbRol.SelectedIndex = 1;
                        break;
                    default:
                        cbRol.SelectedIndex = 1;
                        break;
                }
                tbUser.Text = emp.nombreUsuario;     
            }

        }

        /// <summary>
        /// Este metodo se pondra en marcha cuando se haga click en el boton cancelar,
        /// lanzara un mensaje de precaucion.
        /// </summary>
     
        private void cancel(object sender, RoutedEventArgs e)
        {
            MessageBoxResult salir = MessageBox.Show("¿Seguro que quieres salir?", "Salir", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (salir == MessageBoxResult.Yes)
            {
                this.Close();
            }

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

        private void tbMovil_PreviewTextInput(object sender, TextCompositionEventArgs e)
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

  
        /// <summary>
        /// Este metodo guardara los datos que hayan sido modificados
        /// </summary>
        private void Guardar(object sender, RoutedEventArgs e)
        {
            emp.nombre = tbNombre.Text;
            emp.primerApellido = tbApellido.Text;
            emp.segundoApellido = tbApellido2.Text;   
            emp.tlfmovil =tbMovil.Text;
            switch (cbRol.Text)
            {
                case "Administrador":
                    emp.rol = "1";
                    break;
                case "Teleoperador":
                    emp.rol = "2";
                    break;
                default:
                    emp.rol = "2";
                    break;
            }

            emp.nombreUsuario = tbUser.Text;
            emp.dni = tbDNI.Text;

            if (string.IsNullOrEmpty(emp.nombre) || string.IsNullOrEmpty(emp.primerApellido) || string.IsNullOrEmpty(emp.segundoApellido) || string.IsNullOrEmpty(emp.dni) ||
                string.IsNullOrEmpty(Convert.ToString(emp.rol)) || string.IsNullOrEmpty(Convert.ToString(emp.tlfmovil)) || string.IsNullOrEmpty(emp.nombreUsuario))
            {
                MessageBox.Show("¡Debes rellenar todos los campos!", "Campos vacíos", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (databaseConnector.instance.updateEmp(emp) == true)
                {
                    MessageBox.Show("Empleado " + emp.nombre + " actualizado correctamente.", "Actualizar usuario", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se ha podido actualizar el usuario.", "Fallo al actualizar", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        }
}
