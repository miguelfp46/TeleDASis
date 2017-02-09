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
    /// Interaction logic for ModificacionesUsuarios.xaml
    /// </summary>
    public partial class ModificacionesUsuarios : Window
    {
        Usuario user = new Usuario();

        

        public ModificacionesUsuarios()
        {
            InitializeComponent();
            tbFecha.SelectedDate = DateTime.Today;
        }

        private void cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Guardar(object sender, RoutedEventArgs e)
        {
            this.Close();
            
            
        }

        private void btComprobar_Click(object sender, RoutedEventArgs e)
        {
            user.dni = tbDNI.Text;
            tbNombre.Text = user.nombre;
            tbApellido.Text = user.primerApellido;
            tbApellido2.Text = user.segundoApellido;
            databaseConnector.instance.showUser(user.dni);
        }
    }
}
