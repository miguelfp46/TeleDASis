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
    /// Interaction logic for formLlamadaAgenda.xaml
    /// </summary>
    public partial class formLlamadaAgenda : Window
    {
        public formLlamadaAgenda()
        {
            InitializeComponent();
            Fecha.SelectedDate = DateTime.Today;
        }

        

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {

            this.Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }
        public void SoloNumeros(TextCompositionEventArgs e)
        {
            //se convierte a Ascci del la tecla presionada 
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            //verificamos que se encuentre en ese rango que son entre el 0 y el 9 
            if (ascci >= 48 && ascci <= 57)
                e.Handled = false;
            else e.Handled = true;
        }

        private void tbMovil_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            SoloNumeros(e);
        }
    }
}
