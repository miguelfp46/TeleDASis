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
            MessageBox.Show("Esta seguro que desea dar de baja a este usuario?", "Baja", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            tbDni.Text = dni;

          //  databaseConnector.instance.showUser(dni);
        }
    }
}
