using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TeleDASis
{
    /// <summary>
    /// Interaction logic for ConsultasUsuarios.xaml
    /// </summary>
    public partial class ConsultasUsuarios : Window
    {
        /// <param name="user">Valor que utilizaremos comom enlace al campo de usuarios de la base de datos</param>
        Usuario user = new Usuario();
        System.Windows.Controls.DataGrid dataGridTable;
        public ConsultasUsuarios()
        {
            InitializeComponent();
            dataGridTable = dtGConsultas;
            databaseConnector.instance.showUserTable(dataGridTable, user);

        }

        /// <summary>
        /// Este metodo cierra la ventana
        /// </summary>

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dtGConsultas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        /// <summary>
        /// Busca al empleado y te lo muesta si en DNI es correcto
        /// </summary>
        /// <param name="nombre">Valor que le asignamos para obtener el nombre del usuario</param>
        /// <param name="primerApellido">Valor que le asignamos para obtener el primer apellido del usuario</param>
        /// <param name="segundoApellido">Valor que le asignamos para obtener el segundo apellido del usuario</param>
        /// <param name="tarjetaSanitaria">Valor que le asignamos para obtener la tarjeta sanitaria del usuario</param>
        /// <param name="tlfmovil">Valor que le asignamos para obtener el movil del usuario</param>
        /// <param name="telefono">Valor que le asignamos para obtener el telefono del usuario</param>
        /// <param name="telefonofamiliar">Valor que le asignamos para obtener el telefono familiar del usuario</param>
        /// <param name="dni">Valor que le asignamos para obtener el dni del usuario</param>
        /// <param name="poblacion">Valor que le asignamos para obtener la poblacion del usuario</param>
        /// <param name="direccion">Valor que le asignamos para obtener la direccion del usuario </param>
        ///  <param name="puerta">Valor que le asignamos para obtener la puerta del usuario</param>
        /// 

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            user.nombre = txtNombre.Text;
            user.primerApellido = txtApellido1.Text;
            user.segundoApellido = txtApellido2.Text;
            user.tarjetaSanitaria = txtTarjetaSanitaria.Text;
            user.tlfmovil = txtMovil.Text;
            user.telefono = txtTelefono.Text;
            user.telefonofamiliar = txtTelFamiliar.Text;
            user.dni = txtDni.Text;
            user.poblacion = txtPoblacion.Text;
            user.direccion = txtDir.Text;
            user.puerta = txtPur.Text;
            databaseConnector.instance.showUserTable(dataGridTable,user);
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
    }
}
