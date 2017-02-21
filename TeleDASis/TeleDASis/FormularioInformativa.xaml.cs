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
    /// Interaction logic for FormularioInformativa.xaml
    /// </summary>
    public partial class FormularioInformativa : Window
    {
        public FormularioInformativa()
        {
            InitializeComponent();
            Fecha.SelectedDate = DateTime.Today;
        }

        public void buscarUsuarioPorTel(object sender, RoutedEventArgs e)
        {
            int Tel = int.Parse(tbTel.Text);
            Usuario usuario = databaseConnector.instance.showUser2(Tel);
            if (usuario.nombre == null)
            {
                MessageBox.Show("No se ha encontrado al usuario con el Telefono: " + Tel + ".\nVerifica que sea correcto.", "¡Tel incorrecto!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                Nom.Text = usuario.nombre;
                APELLIDO.Text = usuario.primerApellido;
                APELLIDO2.Text = usuario.segundoApellido;
            }
        }



        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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

        private void Hora_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
