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
    /// Interaction logic for Baja.xaml
    /// </summary>
    public partial class Baja : Window
    {

        /// <param name="user">Valor que utilizaremos comom enlace al campo de usuarios de la base de datos</param>
        Usuario user = new Usuario();
        
        public Baja()
        {
            InitializeComponent();
           
        }

        /// <summary>
        /// Este metodo cierra la ventana
        /// </summary>
        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Al hacer click en el boton aceptar este metodo se pone en funcionamiento. Antes de borrar te lanzara un mensaje de advertencia
        /// </summary>
        /// <param name="tbMotivo">Valor que le asignamos para obtener el motivo de la baja</param>
        /// <param name="tbDni">Valor que le asignamos para obtener el dni del usuario a borrar</param>
        private void bAceptar_Click(object sender, RoutedEventArgs e)
        {
            user.motivodeBaja = tbMotivo.Text;
            //cuando se llame a este metodo, se lanzara un messagebox advirtiendo que si queremos borrar el usuario.
            if (string.IsNullOrEmpty(tbDni.Text))
            {
                MessageBox.Show("Introduce un DNI para poder dar de baja al usuario","Campo DNI vacío",MessageBoxButton.OK, MessageBoxImage.Information);
            }else { 
            MessageBoxResult prueba = MessageBox.Show("Esta seguro que desea dar de baja a este usuario?", "Baja", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (prueba == MessageBoxResult.Yes)
                {
                    //insertar usuario en historicobaja antes de que se borre
                    databaseConnector.instance.addDeletedUserToHistory(user);
                    //borra el usuario de la tabla usuarios
                    if (databaseConnector.instance.delUser(user.dni) == true)
                    {
                        MessageBox.Show("¡Usuario " + user.nombre + " eliminado con éxito!", "Usuario eliminado", MessageBoxButton.OK, MessageBoxImage.Information);
                        borrarValoresDeTextBox();
                    }
                    else
                    {
                        MessageBox.Show("El usuario " + user.nombre + " no se ha podido eliminar. Intentalo de nuevo.", "Fallo al eliminar", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            
        }

        /// <summary>
        /// Guarda a los empleados en un historico
        /// </summary>
        /// <param name="history">nos lleva a la ventana de historico</param>

        public void botonHistorico_Click(object sender, RoutedEventArgs e)
        {
            HistoricoBaja history = new HistoricoBaja();
             history.Show();
        }

        /// <summary>
        /// Busca al usuario y te lo muesta si en DNI es correcto
        /// </summary>
        /// <param name="tbNombre">Valor que le asignamos para obtener el nombre del usuario</param>
        /// <param name="tbPrimerApellido">Valor que le asignamos para obtener el primer apellido del usuario</param>
        /// <param name="tbSegundoApellido">Valor que le asignamos para obtener el segundo apellido del usuario</param>
        /// <param name="tbDni">Valor que le asignamos para obtener el dni del usuario a borrar</param>
        public void buscarUsuarioPorDni(object sender, RoutedEventArgs e)
        {
            user.dni = tbDni.Text;
            user = databaseConnector.instance.showUser(user.dni);
            if (user.nombre == null)
            {
                MessageBox.Show("No se ha encontrado al usuario con el DNI: " + user.dni + ".\nVerifica que sea correcto.", "¡DNI incorrecto!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                tbNombre.Text = user.nombre;
                tbPrimerApellido.Text = user.primerApellido;
                tbSegundoApellido.Text = user.segundoApellido;
                
            }
        }

        /// <summary>
        /// Borrar al usuario seleccionado
        /// </summary>
        /// <param name="tbNombre">Valor que le asignamos para obtener el nombre del usuario</param>
        /// <param name="tbPrimerApellido">Valor que le asignamos para obtener el primer apellido del usuario</param>
        /// <param name="tbSegundoApellido">Valor que le asignamos para obtener el segundo apellido del usuario</param>
        /// <param name="tbMotivo">Valor que le asignamos para obtener el motivo de la baja</param>
        /// <param name="tbEmpleado">Valor que le asignamos para obtener el id del empleado que ha tramitado la baja</param>
        /// <param name="tbDni">Valor que le asignamos para obtener el dni del usuario a borrar</param>
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
