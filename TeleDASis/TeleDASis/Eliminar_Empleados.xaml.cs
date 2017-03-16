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
                MessageBoxResult prueba = MessageBox.Show("Esta seguro que desea dar de baja a este usuario?", "Baja", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (prueba == MessageBoxResult.Yes)
                {
                    //insertar usuario en historicobaja antes de que se borre
                    databaseConnector.instance.addDeletedEmpToHistory(emp);
                    //borra el usuario de la tabla usuarios
                    if (databaseConnector.instance.delUser(emp.dni) == true)
                    {
                        MessageBox.Show("¡Usuario " + emp.nombre + " eliminado con éxito!", "Usuario eliminado", MessageBoxButton.OK, MessageBoxImage.Information);
                        borrarValoresDeTextBox();
                    }
                    else
                    {
                        MessageBox.Show("El usuario " + emp.nombre + " no se ha podido eliminar. Intentalo de nuevo.", "Fallo al eliminar", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }


        }

        public void buscarUsuarioPorDni(object sender, RoutedEventArgs e)
        {
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
