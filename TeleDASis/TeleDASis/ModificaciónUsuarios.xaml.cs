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
         
            tbNombre.IsEnabled = false;
            tbApellido.IsEnabled = false;
            tbApellido2.IsEnabled = false;
            tbTs.IsEnabled = false;
            tbMovil.IsEnabled = false;
            tbTelefono.IsEnabled = false;
            tbTelFamiliar.IsEnabled = false;
            tbPoblacion.IsEnabled = false;
            tbDireccion.IsEnabled = false;
            tbPuerta.IsEnabled = false;
            
        }

        /// <summary>
        /// Este metodo se pondra en marcha cuando se haga click en el boton cancelar,
        /// lanzara un mensaje de precaucion.
        /// </summary>
        private void cancel(object sender, RoutedEventArgs e)
        {
            MessageBoxResult salir = MessageBox.Show("¿Seguro que quieres salir?", "Salir", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(salir == MessageBoxResult.Yes)
            {
                this.Close();
            }
            
        }

        /// <summary>
        /// Este metodo guardara los datos que hayan sido modificados
        /// </summary>
        private void Guardar(object sender, RoutedEventArgs e)
        {
            usuario.nombre = tbNombre.Text;
            usuario.primerApellido = tbApellido.Text;
            usuario.segundoApellido = tbApellido2.Text;
            usuario.tarjetaSanitaria = tbTs.Text;
            usuario.tlfmovil = tbMovil.Text;
            usuario.telefono = tbTelefono.Text;
            usuario.telefonofamiliar = tbTelFamiliar.Text;
            usuario.poblacion = tbPoblacion.Text;
            usuario.direccion = tbDireccion.Text;
            usuario.puerta = tbPuerta.Text;
            usuario.dni = tbDNI.Text;

            if (string.IsNullOrEmpty(usuario.nombre) || string.IsNullOrEmpty(usuario.primerApellido) || string.IsNullOrEmpty(usuario.segundoApellido) || string.IsNullOrEmpty(usuario.dni) ||
                string.IsNullOrEmpty(Convert.ToString(usuario.telefono)) || string.IsNullOrEmpty(Convert.ToString(usuario.telefonofamiliar)) || string.IsNullOrEmpty(Convert.ToString(usuario.tlfmovil)) || string.IsNullOrEmpty(usuario.tarjetaSanitaria)
                || string.IsNullOrEmpty(usuario.poblacion) || string.IsNullOrEmpty(usuario.direccion) || string.IsNullOrEmpty(usuario.puerta))
            {
                MessageBox.Show("¡Debes rellenar todos los campos!", "Campos vacíos", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (databaseConnector.instance.updateUser(usuario) == true)
                {
                    MessageBox.Show("Usuario "+usuario.nombre+ " actualizado correctamente.", "Actualizar usuario", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("No se ha podido actualizar el usuario.", "Fallo al actualizar", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            
        }

        /// <summary>
        /// Este metodo se encarga de comprobar si los datos introducidos son correctos, de no serlo lanzara un mensaje de aviso
        /// </summary>
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
                tbNombre.IsEnabled = true;
                tbApellido.IsEnabled = true;
                tbApellido2.IsEnabled = true;
                tbTs.IsEnabled = true;
                tbMovil.IsEnabled = true;
                tbTelefono.IsEnabled = true;
                tbTelFamiliar.IsEnabled = true;
                tbPoblacion.IsEnabled = true;
                tbDireccion.IsEnabled = true;
                tbPuerta.IsEnabled = true;

                tbNombre.Text = usuario.nombre;
                tbApellido.Text = usuario.primerApellido;
                tbApellido2.Text = usuario.segundoApellido;
                tbTs.Text = usuario.tarjetaSanitaria;
                tbMovil.Text = usuario.tlfmovil;
                tbTelefono.Text = usuario.telefono;
                tbTelFamiliar.Text = usuario.telefonofamiliar;
                tbPoblacion.Text = usuario.poblacion;
                tbDireccion.Text = usuario.direccion;
                tbPuerta.Text = usuario.puerta;
            }
        }

        /// <summary>
        /// Este metodo restringe que tipo de caracteres puedes escribir, en este caso solo puedes escribir numeros
        /// </summary>
        /// <param name="ascci">Valor que le asignamos para obtener un int</param>
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

        /// <summary>
        /// Este metodo restringe que tipo de caracteres puedes escribir, en este caso solo puedes escribir letas
        /// </summary>
        /// <param name="ascci">Valor que le asignamos para obtener un int</param>
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

        private void tbNombre_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
