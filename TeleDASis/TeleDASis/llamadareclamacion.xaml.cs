using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TeleDASis
{
    /// <summary>
    /// Interaction logic for llamadareclamacion.xaml
    /// </summary>
    public partial class llamadareclamacion : Window
    {
        private bool handle = true;
        int servicio;

        public llamadareclamacion()
        {
            InitializeComponent();
            //Fecha.SelectedDate = DateTime.Today;
            //Hora.SelectedDateFormat = DatePickerFormat.Short;
           
          
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
            //3q5zw46xerc7tvyuomi,p.`-
        }

        private void tbMovil_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            SoloNumeros(e);
        }
        private void Handle()
        {
            switch (CMB.SelectedItem.ToString().Split(new string[] { ":" }, StringSplitOptions.None).Last())
            {
                case "Ambulancia":
                    servicio = 1;
                    break;
                case "Policia":
                    servicio = 2;
                    break;
                case "Bomberos":
                    servicio = 3;
                    break;
                case "Mossos d'escuadra":
                    servicio = 4;
                    break;
                case "Mas de uno":
                    servicio = 5;
                    break;
                default:
                    servicio = 6;
                    break;


            }
        }
    }
}
