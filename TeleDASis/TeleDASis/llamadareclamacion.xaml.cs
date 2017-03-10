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
        Llamadas llamada = new Llamadas();
        Usuario usuario = new Usuario();

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
            switch (cbTipoLlamada.SelectedItem.ToString().Split(new string[] { ":" }, StringSplitOptions.None).Last())
            {
                case "Policia":
                    llamada.servicio = 1;
                    break;
                case "Ambulancia":
                    llamada.servicio = 2;
                    break;
                case "Bomberos":
                    llamada.servicio = 3;
                    break;
                default:
                    llamada.servicio = 4;
                    break;


            }
        }

        private void CMB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Dispatcher.BeginInvoke((Action)(() => tcTipoLLamada.SelectedIndex = cbTipoLlamada.SelectedIndex));
            tcTipoLLamada.Visibility = Visibility.Visible;
        }

        private void tcTipoLLamada_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btBuscar_Click(object sender, RoutedEventArgs e)
        {
            //buscamos a un usuario por telefono y lo cargamos.
            usuario.telefono = tbTelefono.Text;
            databaseConnector.instance.searchUserByPhone(usuario);
            tbNombre.Text = usuario.nombre;
            tbPrimerApellido.Text = usuario.primerApellido;
            tbSegundoApellido.Text = usuario.segundoApellido;
            tbDNI.Text = usuario.dni;
        }

        private void dtGConsultas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
