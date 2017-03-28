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
    /// Interaction logic for FormularioRLlamadas.xaml
    /// </summary>
    public partial class FormularioRLlamadas : Window
    {
        public FormularioRLlamadas()
        {
            InitializeComponent();
        }
        
        private void btRegistroLlamadas_Click(object sender, RoutedEventArgs e)
        {
            RegistrodeTodasLasLlamadas rllamadas = new RegistrodeTodasLasLlamadas();
            rllamadas.Show();
        }

        private void btAgenda_Click(object sender, RoutedEventArgs e)
        {
            formLlamadaAgenda info = new formLlamadaAgenda();

            info.Show();
        }

        private void btVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
