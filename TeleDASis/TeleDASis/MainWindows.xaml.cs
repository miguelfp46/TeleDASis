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
    /// Interaction logic for MainWindows.xaml
    /// </summary>
    public partial class MainWindows : Window
    {
        public MainWindows()
        {
            InitializeComponent();
        }

        private void button_Copy3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void boton_reclamacion_Click(object sender, RoutedEventArgs e)
        {
            var nuevaventana = new llamadareclamacion();
            nuevaventana.Show();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            FormularioInformativa info = new FormularioInformativa();
            
            info.Show();
        }
    }
}
