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
    /// Interaction logic for LlamadaInformativa.xaml
    /// </summary>
    public partial class LlamadaInformativa : Window
    {
        public LlamadaInformativa()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            FormularioInformativa info = new FormularioInformativa();

            info.Show();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void botonsalir_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
        }

        
    }
}
