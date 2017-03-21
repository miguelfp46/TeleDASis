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
    /// Interaction logic for Eliminar_Empleados.xaml
    /// </summary>
    public partial class Eliminar_Empleados : Window
    {
        Empleados emp = new Empleados();

        public Eliminar_Empleados()
        {
            InitializeComponent();
        }

        private void bAceptar_Click(object sender, RoutedEventArgs e)
        {

            emp.motivodeBaja = tbMotivo.Text;
            //cuando se llame a este metodo, se lanzara un messagebox advirtiendo que si queremos borrar el usuario.
            if (string.IsNullOrEmpty(tbDni.Text))
            {
                MessageBox.Show("Introduce un DNI para poder dar de baja al usuario", "Campo DNI vacío", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBoxResult prueba = MessageBox.Show("Esta seguro que desea dar de baja a este empleado?", "Baja", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (prueba == MessageBoxResult.Yes)
                {
                    //insertar usuario en historicobaja antes de que se borre
                    databaseConnector.instance.addDeletedEmpToHistory(emp);
                    //borra el usuario de la tabla usuarios
                    if (databaseConnector.instance.delEmp(emp.dni) == true)
                    {
                        MessageBox.Show("¡Empelado" + emp.nombre + " eliminado con éxito!", "Usuario eliminado", MessageBoxButton.OK, MessageBoxImage.Information);
                        borrarValoresDeTextBox();
                    }
                    else
                    {
                        MessageBox.Show("El Empleado " + emp.nombre + " no se ha podido eliminar. Intentalo de nuevo.", "Fallo al eliminar", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }


        }

        public void buscarEmpPorDni(object sender, RoutedEventArgs e)
        {
            emp.dni = tbDni.Text;
            emp = databaseConnector.instance.showEmp(emp.dni);
            if (emp.nombre == null)
            {
                MessageBox.Show("No se ha encontrado al empleado con el DNI: " + emp.dni + ".\nVerifica que sea correcto.", "¡DNI incorrecto!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                tbNombre.Text = emp.nombre;
                tbPrimerApellido.Text = emp.primerApellido;
                tbSegundoApellido.Text = emp.segundoApellido;

            }
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void borrarValoresDeTextBox()
        {
            tbNombre.Text = "";
            tbPrimerApellido.Text = "";
            tbSegundoApellido.Text = "";
            tbMotivo.Text = "";
            tbEmpleado.Text = "";
            tbDni.Text = "";
        }
    }
}
