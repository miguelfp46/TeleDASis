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
        /// <param name="emp">Valor que utilizaremos comom enlace al campo de empleados de la base de datos</param>
        Empleados emp = new Empleados();

        public Eliminar_Empleados()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Al hacer click en el boton aceptar este metodo se pone en funcionamiento. Antes de borrar te lanzara un mensaje de advertencia
        /// </summary>
        /// <param name="tbMotivo">Valor que le asignamos para obtener el motivo de la baja</param>
        /// <param name="tbDni">Valor que le asignamos para obtener el dni del empleado a borrar</param>

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

        /// <summary>
        /// Busca al empleado y te lo muesta si en DNI es correcto
        /// </summary>
        /// <param name="tbNombre">Valor que le asignamos para obtener el nombre del Empleado</param>
        /// <param name="tbPrimerApellido">Valor que le asignamos para obtener el primer apellido del empleado</param>
        /// <param name="tbSegundoApellido">Valor que le asignamos para obtener el segundo apellido del empleado</param>
        /// <param name="tbDni">Valor que le asignamos para obtener el dni del empleado a borrar</param>

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

        /// <summary>
        /// Este metodo cierra la ventana
        /// </summary>
        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Borrar al empleado seleccionado
        /// </summary>
        /// <param name="tbNombre">Valor que le asignamos para obtener el nombre del Empleado</param>
        /// <param name="tbPrimerApellido">Valor que le asignamos para obtener el primer apellido del empleado</param>
        /// <param name="tbSegundoApellido">Valor que le asignamos para obtener el segundo apellido del empleado</param>
        /// <param name="tbMotivo">Valor que le asignamos para obtener el motivo de la baja</param>
        /// <param name="tbEmpleado">Valor que le asignamos para obtener el id del empleado que ha tramitado la baja</param>
        /// <param name="tbDni">Valor que le asignamos para obtener el dni del empleado a borrar</param>

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
