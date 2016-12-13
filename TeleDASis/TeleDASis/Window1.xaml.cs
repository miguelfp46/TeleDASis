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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Eliminar(object sender, RoutedEventArgs e)
        {//Esto mostrara un mensaje de aviso
            var result = MessageBox.Show("Estas seguro que quieres eliminar al Empleado?", "Eliminar", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                //Esto mustra la Window2
                Window2 MiVentana = new Window2();
                MiVentana.Owner = this;
                MiVentana.ShowDialog();
            }
        }
    }
}
