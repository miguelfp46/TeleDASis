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

        /// <summary>
        /// Abre el registro de llamadas
        /// </summary>
        /// <param name="rllamadas">variable que utilizamos para enlazar las ventanas</param>
        private void btRegistroLlamadas_Click(object sender, RoutedEventArgs e)
        {
            RegistrodeTodasLasLlamadas rllamadas = new RegistrodeTodasLasLlamadas();
            this.Hide();
            rllamadas.Show();
        }

        /// <summary>
        /// Abre el registro de llamadas de Agenda
        /// </summary>
        /// <param name="info">variable que utilizamos para enlazar las ventanas</param>
        private void btAgenda_Click(object sender, RoutedEventArgs e)
        {
            formLlamadaAgenda info = new formLlamadaAgenda();
            this.Hide();
            info.Show();
        }

        /// <summary>
        /// Cierra la ventana
        /// </summary>
        
        private void btVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
