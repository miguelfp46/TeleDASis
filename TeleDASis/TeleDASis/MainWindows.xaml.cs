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
        
     

        private void boton_reclamacion_Click(object sender, RoutedEventArgs e)
        {
            llamadareclamacion info = new llamadareclamacion();

            info.Show();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            LlamadaInformativa info = new LlamadaInformativa();
            
            info.Show();
        }

        private void button_Copy2_Click(object sender, RoutedEventArgs e)
        {
            

           formLlamadaAgenda agenda = new formLlamadaAgenda();

            agenda.Show();
        }

        private void boton_emergencia_Click(object sender, RoutedEventArgs e)
        {
            menuLlamadaEmergencia nuevaventana = new menuLlamadaEmergencia();
            nuevaventana.Show();
        }

        private void botonModificaciones_Click(object sender, RoutedEventArgs e)
        {
            ModificacionesUsuarios modificar = new ModificacionesUsuarios();
            modificar.Show();

        }

        private void botonAlta_Click(object sender, RoutedEventArgs e)
        {
            Alta info = new Alta();

            info.Show();

        }

        private void botonBaja_Click(object sender, RoutedEventArgs e)
        {
            Baja info = new Baja();

            info.Show();
        }

        private void botonConsultas_Click(object sender, RoutedEventArgs e)
        {
            ConsultasUsuarios consultas = new ConsultasUsuarios();

            consultas.Show();
        }
    }
}
