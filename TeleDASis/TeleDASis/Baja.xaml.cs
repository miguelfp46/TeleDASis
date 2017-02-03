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
        public String nombre;
        public String dni;
        public Baja()
        {
            InitializeComponent();
            FechaBaja.SelectedDate = DateTime.Today;
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void bAceptar_Click(object sender, RoutedEventArgs e)
        {
            //cuando se llame a este metodo, se lanzara un messagebox advirtiendo que si queremos borrar el usuario.
            MessageBoxResult prueba = MessageBox.Show("Esta seguro que desea dar de baja a este usuario?", "Baja", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (prueba == MessageBoxResult.Yes)
            {
                databaseConnector.instance.delUser(nombre, dni);
            }
            
        }
        public void buscarUsuarioPorDni(object sender, RoutedEventArgs e)
        {
            dni = tbDni.Text;
            Usuario usuario = databaseConnector.instance.showUser(dni);
            if (usuario.nombre == null)
            {
                MessageBox.Show("No se ha encontrado al usuario con el DNI: " + dni + ".\nVerifica que sea correcto.", "¡DNI incorrecto!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                tbNombre.Text = usuario.nombre;
                tbPrimerApellido.Text = usuario.primerApellido;
                tbSegundoApellido.Text = usuario.segundoApellido;
            }
        }
        //public string comprobarDni()
        //{

        //}

    }
}
