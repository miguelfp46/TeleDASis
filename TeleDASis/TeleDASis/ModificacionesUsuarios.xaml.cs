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
    /// Interaction logic for ModificacionesUsuarios.xaml
    /// </summary>
    public partial class ModificacionesUsuarios : Window
    {
        Usuario user = new Usuario();

        

        public ModificacionesUsuarios()
        {
            InitializeComponent();
            tbFecha.SelectedDate = DateTime.Today;
        }

        private void cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Guardar(object sender, RoutedEventArgs e)
        {
            this.Close();
            
            
        }

        private void btComprobar_Click(object sender, RoutedEventArgs e)
        {
            user.dni = tbDNI.Text;
            tbNombre.Text = user.nombre;
            tbApellido.Text = user.primerApellido;
            tbApellido2.Text = user.segundoApellido;
            databaseConnector.instance.showUser(user.dni);
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

        public void SoloLetras(TextCompositionEventArgs e)
        {
            //se convierte a Ascci del la tecla presionada 
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            //verificamos que se encuentre en ese rango que son entre el 0 y el 9 
            if (ascci >= 65 && ascci <= 90 || ascci>=97 && ascci<=122)
                e.Handled = false;
            else e.Handled = true;
        }

        private void tbNom_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            SoloLetras(e);
        }
    }

    }

