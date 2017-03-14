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
        Usuario user = new Usuario();
        
        public Baja()
        {
            InitializeComponent();
           
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

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
        public void botonHistorico_Click(object sender, RoutedEventArgs e)
        {
            HistoricoBaja history = new HistoricoBaja();
             history.Show();
        }
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
