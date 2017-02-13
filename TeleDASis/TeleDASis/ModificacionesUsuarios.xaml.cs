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
        string dni;
        Usuario usuario = new Usuario();

        

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
            usuario.nombre = tbNombre.Text;
            usuario.primerApellido = tbApellido.Text;
            usuario.segundoApellido = tbApellido2.Text;
            usuario.tarjetasanitaria = tbTs.Text;
            usuario.tlfmovil = Convert.ToInt32(tbMovil.Text);
            usuario.telefono = Convert.ToInt32(tbTelefono.Text);
            usuario.telefonofamiliar = Convert.ToInt32(tbTelFamiliar.Text);
            usuario.vivienda = tbVivienda.Text;
            if(databaseConnector.instance.updateUser(usuario) == true)
            {
                MessageBox.Show("Va to bien");
            }
            
        }

        private void btComprobar_Click(object sender, RoutedEventArgs e)
        {
            dni = tbDNI.Text;
            Usuario usuario = databaseConnector.instance.showUserAll(dni);
            if (usuario.nombre == null)
            {
                MessageBox.Show("No se ha encontrado al usuario con el DNI: " + usuario.dni + ".\nVerifica que sea correcto.", "¡DNI incorrecto!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                tbNombre.Text = usuario.nombre;
                tbApellido.Text = usuario.primerApellido;
                tbApellido2.Text = usuario.segundoApellido;
                tbTs.Text = usuario.tarjetasanitaria;
                tbMovil.Text = Convert.ToString(usuario.tlfmovil);
                tbTelefono.Text = Convert.ToString(usuario.telefono);
                tbTelFamiliar.Text = Convert.ToString(usuario.telefonofamiliar);
                tbVivienda.Text = Convert.ToString(usuario.vivienda);

            }
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
            //verificamos que se encuentre en ese rango que son entre el a y el z
            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122)
                e.Handled = false;
            else e.Handled = true;
        }
        private void Letras(object sender, TextCompositionEventArgs e)
        {
            SoloLetras(e);
        }
    }

    
}
